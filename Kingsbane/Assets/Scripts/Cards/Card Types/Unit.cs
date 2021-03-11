using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CategoryEnums;
using System;
using System.Linq;

public class Unit : Card
{
    public enum UnitStatuses //The possible action statuses of the unit
    {
        Start, //Status for start of turn
        Preparing, //Status for just played
        Middle, //Status for still actions, movement or abilities to use
        Finished, //Status for all actions spent
        Enemy, //Status for enemy cards
    }

    public enum StatusEffects
    {
        None,
        Flying,
        Rooted,
        Spellbound,
        Stealthed,
        Stunned,
        Transformed,
    }

    public enum StatTypes
    {
        Default,
        Attack,
        MaxHealth,
        Range,
        Speed,
        Empowered,
        Protected,
        TempProtected,
    }

    public class Stat
    {
        public StatTypes Type { get; set; }
        public int? Value { get; set; }
    }

    public UnitData UnitData { get { return cardData as UnitData; } }

    public List<Stat> Stats { get; set; }
    public List<Stat> GetStats { get { return Stats.Select(x => new Stat() { Type = x.Type, Value = x.Value }).ToList(); } }

    public int? TotalProtected
    {
        get
        {
            if (GetStat(StatTypes.Protected).HasValue && GetStat(StatTypes.TempProtected).HasValue)
                return GetStat(StatTypes.Protected) + GetStat(StatTypes.TempProtected);
            else
                return null;
        }
    }

    public StatisticStatuses HasBuffedAttack { get { return GetStat(StatTypes.Attack) > UnitData.Attack ? StatisticStatuses.Buffed : StatisticStatuses.None; } }
    public StatisticStatuses UnitIsDamaged { get { return CurrentHealth < GetStat(StatTypes.MaxHealth) ? StatisticStatuses.Damaged : StatisticStatuses.None; } }
    public StatisticStatuses HasBuffedRange { get { return GetStat(StatTypes.Range) > UnitData.Range ? StatisticStatuses.Buffed : StatisticStatuses.None; } }
    public StatisticStatuses HasBuffedSpeed { get { return GetStat(StatTypes.Speed) > UnitData.Speed ? StatisticStatuses.Buffed : StatisticStatuses.None; } }

    public UnitStatuses Status { get; set; }
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = Mathf.Min(GetStat(StatTypes.MaxHealth).Value, value); } }
    private int currentHealth;
    public int RemainingSpeed { get { return remainingSpeed; } set { remainingSpeed = Mathf.Min(GetStat(StatTypes.Speed).Value, value); } }
    private int remainingSpeed;
    public int ActionsLeft { get; set; }
    public int AbilityUsesLeft { get; set; }
    public bool CanMove { get { return ActionsLeft > 0 && RemainingSpeed > 0; } }
    public bool CanAction { get { return ActionsLeft > 0; } }

    public List<AppliedEnchantment> Enchantments { get; set; }
    public List<StatusEffects> CurrentStatusEffects { get; set; }
    public List<Keywords> BaseKeywords { get { return UnitData.Keywords; } }
    public List<Keywords> CurrentKeywords { get; set; }

    public List<UnitTags> UnitTags { get { return UnitData.UnitTag; } }
    public string UnitTag { get { return string.Join(" ", UnitTags.Select(x => x.ToString())); } }

    public List<AbilityData> Abilities { get { return UnitData.Abilities; } }

    public UnitCounter UnitCounter { get; set; }

    public bool HasKeyword(Keywords keyword)
    {
        return CurrentKeywords.Contains(keyword);
    }

    public override void InitCard(CardData _cardData, Player owner)
    {
        base.InitCard(_cardData, owner);

        ResetStats(true);

        Enchantments = new List<AppliedEnchantment>();
        CurrentStatusEffects = new List<StatusEffects>();
        CurrentKeywords = new List<Keywords>();

        Status = UnitStatuses.Preparing;
        CurrentHealth = GetStat(StatTypes.MaxHealth).Value;

        if (BaseKeywords.Count > 0 || GetStat(StatTypes.Empowered) > 0)
        {
            var keywordEnchantment = new UnitEnchantment()
            {
                Source = "Base Keywords",
                Status = UnitEnchantment.EnchantmentStatus.Base,
            };
            keywordEnchantment.Keywords = BaseKeywords.ToList();
            if (GetStat(StatTypes.Empowered) > 0)
                keywordEnchantment.AddStatModifier(StatTypes.Empowered, StatModifierTypes.Modify, GetStat(StatTypes.Empowered).Value);

            AddEnchantment(keywordEnchantment);
        }
    }

    private void ResetStats(bool fullReset = false)
    {
        int? currentTempProtected = 0;
        int? currentProtected = UnitData.Protected;

        if (!fullReset)
        {
            currentTempProtected = GetStat(StatTypes.TempProtected);
            currentProtected = GetStat(StatTypes.Protected);
        }

        var maxStats = 8;
        Stats = new List<Stat>(maxStats)
        {
            new Stat() { Type = StatTypes.Attack, Value = UnitData.Attack },
            new Stat() { Type = StatTypes.MaxHealth, Value = UnitData.Health },
            new Stat() { Type = StatTypes.TempProtected, Value = currentTempProtected },
            new Stat() { Type = StatTypes.Protected, Value = currentProtected },
            new Stat() { Type = StatTypes.Range, Value = UnitData.Range },
            new Stat() { Type = StatTypes.Speed, Value = UnitData.Speed },
            new Stat() { Type = StatTypes.Empowered, Value = UnitData.Empowered },
        };
    }

    public int? GetStat(StatTypes statType)
    {
        return Stats.Single(x => x.Type == statType).Value;
    }

    public void ModifyStat(StatModifierTypes modifierType, StatTypes statType, int? value)
    {
        switch (modifierType)
        {
            case StatModifierTypes.Modify:
                var currentValue = Stats.Single(x => x.Type == statType).Value;
                ModifyStat(StatModifierTypes.Set, statType, currentValue.Value + value);
                break;
            case StatModifierTypes.Set:
                Stats.Single(x => x.Type == statType).Value = value;
                break;
            default:
                throw new Exception("Not a valid modifier type");
        }
    }

    public override void Play()
    {
        base.Play();

        Status = UnitStatuses.Preparing;
    }

    public void StartOfTurn(bool isActive)
    {
        if (isActive)
        {
            if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Mulligan)
            {
                Status = UnitStatuses.Preparing;
            }
            else if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            {
                if (GameManager.instance.CurrentRound != 1 || HasKeyword(Keywords.Prepared))
                {
                    Status = UnitStatuses.Start;

                    RemainingSpeed = GetStat(StatTypes.Speed).Value;

                    if (HasKeyword(Keywords.Swiftstrike))
                    {
                        ActionsLeft = 2;
                        AbilityUsesLeft = 1;
                    }
                    else if (HasKeyword(Keywords.SpecialSwiftstrike))
                    {
                        ActionsLeft = 3;
                        AbilityUsesLeft = 3;
                    }
                    else
                    {
                        ActionsLeft = 1;
                        AbilityUsesLeft = 1;
                    }
                }
                else
                {
                    Status = UnitStatuses.Preparing;
                }

                ModifyStat(StatModifierTypes.Set, StatTypes.TempProtected, 0);
                RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus.StartOfOwnersTurn);
            }
        }
        else
        {
            Status = UnitStatuses.Enemy;
            RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus.StartOfOpponentTurn);
        }

        UnitCounter.RefreshUnitCounter();
    }

    public void EndOfTurn(bool isActive)
    {
        if (isActive)
        {
            RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus.EndOfOwnersTurn);
            RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus.AfterAttack);
        }
        else
        {
            RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus.EndOfOpponentTurn);
            RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus.AfterAttack);
        }

        UnitCounter.RefreshUnitCounter();
    }

    public void UseSpeed(int usedSpeed)
    {
        if (usedSpeed == 0)
        {
            throw new Exception("Cannot Use 0 Speed");
        }
        else
        {
            RemainingSpeed -= usedSpeed;
            Status = UnitStatuses.Middle;

            UnitCounter.RefreshUnitCounter();
            GameManager.instance.effectManager.RefreshEffectManager();
        }
    }

    public void ModifyActions(int value)
    {
        ActionsLeft += value;
        if (ActionsLeft == 0)
            Status = UnitStatuses.Finished;
        else if (value <= 0)
            Status = UnitStatuses.Middle;
        else if (value > 0)
            if (Status == UnitStatuses.Finished)
                Status = UnitStatuses.Middle;

        UnitCounter.RefreshUnitCounter();
    }

    public void TriggerAttack(Unit targetUnit)
    {
        ModifyActions(-1);

        var targetRouted = targetUnit.CheckRouting();

        if (!targetRouted)
        {
            var targetHealth = targetUnit.CurrentHealth;
            bool unitDead = false;
            var targetDead = targetUnit.DamageUnit(Owner, GetStat(StatTypes.Attack).Value, CurrentKeywords);
            if (GetStat(StatTypes.Range).Value == 0)
            {
                if (!targetDead && HasKeyword(Keywords.Overwhelm))
                {
                    unitDead = DamageUnit(targetUnit.Owner, targetUnit.GetStat(StatTypes.Attack).Value, targetUnit.CurrentKeywords);
                }
            }

            if (targetDead && !unitDead)
            {
                CheckUnleash(targetUnit.GetStat(StatTypes.Attack).Value, targetHealth);
            }

            RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus.AfterAttack);
        }
        else
        {
            targetUnit.RemoveUnit();
        }

        UnitCounter.RefreshUnitCounter();
        targetUnit.UnitCounter.RefreshUnitCounter();
    }

    public bool CheckRouting()
    {
        if (HasKeyword(Keywords.Routing))
        {
            var missingHealth = GetStat(StatTypes.MaxHealth) - CurrentHealth;
            var randomValue = UnityEngine.Random.Range(0, GetStat(StatTypes.MaxHealth).Value);
            return randomValue < missingHealth;
        }

        return false;
    }

    public void CheckUnleash(int targetAttack, int targetHealth)
    {
        if (HasKeyword(Keywords.Unleash))
        {
            var unleashEnchantment = new UnitEnchantment()
            {
                Source = "Unleash",
                Status = UnitEnchantment.EnchantmentStatus.Permanent,
            };
            unleashEnchantment.AddStatModifier(StatTypes.Attack, StatModifierTypes.Modify, targetAttack);
            unleashEnchantment.AddStatModifier(StatTypes.MaxHealth, StatModifierTypes.Modify, targetHealth);

            AddEnchantment(unleashEnchantment);
        }
    }

    public bool DamageUnit(Player sourcePlayer, int damageValue, List<Keywords> keywords)
    {
        if (keywords.Contains(Keywords.Piercing))
        {
            CurrentHealth -= damageValue;
            if (CurrentHealth <= 0 || keywords.Contains(Keywords.Deadly))
                DestroyUnit();
            if (keywords.Contains(Keywords.Lifebond))
                sourcePlayer.Hero.HealUnit(damageValue);
        }
        else
        {
            if (TotalProtected.HasValue)
            {
                ModifyStat(StatModifierTypes.Modify, StatTypes.TempProtected, -damageValue);
                if (GetStat(StatTypes.TempProtected) < 0)
                {
                    ModifyStat(StatModifierTypes.Modify, StatTypes.Protected, GetStat(StatTypes.TempProtected).Value);
                    ModifyStat(StatModifierTypes.Set, StatTypes.TempProtected, 0);
                    if (GetStat(StatTypes.Protected) < 0)
                    {
                        CurrentHealth += GetStat(StatTypes.Protected).Value;
                        if (CurrentHealth <= 0 || keywords.Contains(Keywords.Deadly))
                            DestroyUnit();
                        if (keywords.Contains(Keywords.Lifebond))
                            sourcePlayer.Hero.HealUnit(-GetStat(StatTypes.Protected));

                        ModifyStat(StatModifierTypes.Set, StatTypes.Protected, 0);
                    }
                }


            }
        }

        UnitCounter.RefreshUnitCounter();
        return CurrentHealth <= 0;
    }

    public void HealUnit(int? healValue)
    {
        if (healValue.HasValue)
            CurrentHealth = Mathf.Min(GetStat(StatTypes.MaxHealth).Value, CurrentHealth + healValue.Value);
        else
            CurrentHealth = GetStat(StatTypes.MaxHealth).Value;

        UnitCounter.RefreshUnitCounter();
    }

    public void AddProtected(int? value, bool isTemporary)
    {
        if (isTemporary)
        {
            if (value.HasValue)
            {
                if (GetStat(StatTypes.TempProtected).HasValue)
                    ModifyStat(StatModifierTypes.Modify, StatTypes.TempProtected, value.Value);
            }
            else
                ModifyStat(StatModifierTypes.Set, StatTypes.TempProtected, null);
        }
        else
        {
            if (value.HasValue)
            {
                if (GetStat(StatTypes.Protected).HasValue)
                    ModifyStat(StatModifierTypes.Modify, StatTypes.Protected, value.Value);
            }
            else
            {
                ModifyStat(StatModifierTypes.Set, StatTypes.Protected, null);
            }
        }
        UnitCounter.RefreshUnitCounter();
    }

    public void DestroyUnit()
    {
        GameManager.instance.effectManager.RemoveUnit(UnitCounter);
        Owner.AddToGraveyard(this);

        UnitCounter.Cell.gameplayUI.RefreshPlayerBar(Owner.Id);
    }

    public void RemoveUnit()
    {
        GameManager.instance.effectManager.RemoveUnit(UnitCounter);

        UnitCounter.Cell.gameplayUI.RefreshPlayerBar(Owner.Id);
    }

    public bool CanUseAbility(AbilityData ability)
    {
        var canSpendResources = Resource.CanSpendResources(Owner, ability.Resources);
        var canSpendAction = ability.CostsAction ? CanAction : true;
        var canUseability = AbilityUsesLeft > 0;

        return canSpendResources && canSpendAction && canUseability;
    }

    public void ModifyAbilities(int value)
    {
        AbilityUsesLeft += value;
    }

    public void UseAbility(AbilityData ability)
    {
        Owner.ModifyResources(ability.Resources.Select(x => new Resource(x.ResourceType, x.Value * -1)).ToList());

        ModifyAbilities(-1);
        ModifyActions(ability.CostsAction ? -1 : 0);

        UnitCounter.RefreshUnitCounter();
    }

    public void AddEnchantment(UnitEnchantment enchantment)
    {
        Enchantments.Add(new AppliedEnchantment() { Enchantment = enchantment });
        UpdateEnchantments();

        if (HasKeyword(Keywords.Flying))
            CurrentStatusEffects.Add(StatusEffects.Flying);
        if (HasKeyword(Keywords.Stealth))
            CurrentStatusEffects.Add(StatusEffects.Stealthed);

        if (UnitCounter != null)
            UnitCounter.RefreshUnitCounter();
    }

    public void RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus enchantmentStatus)
    {
        var removeEnchantments = Enchantments.Where(x => x.Enchantment.Status == enchantmentStatus);

        Enchantments.RemoveAll(x => removeEnchantments.Contains(x));

        UpdateEnchantments();
    }

    private void UpdateEnchantments()
    {
        ResetStats();
        CurrentKeywords.Clear();
        CurrentStatusEffects.Clear();

        foreach (var enchantment in Enchantments)
        {
            if (enchantment.Enchantment.Status != UnitEnchantment.EnchantmentStatus.None)
            {
                if (enchantment.IsActive)
                {
                    foreach (var statModifier in enchantment.Enchantment.StatModifiers)
                    {
                        ModifyStat(statModifier.ModType, statModifier.StatType, statModifier.Value);

                        if (!enchantment.IsApplied)
                        {
                            switch (statModifier.ModType)
                            {
                                case StatModifierTypes.Modify:
                                    if (statModifier.StatType == StatTypes.MaxHealth)
                                        CurrentHealth += statModifier.Value;
                                    if (statModifier.StatType == StatTypes.Speed && (Status != UnitStatuses.Preparing || Status != UnitStatuses.Enemy))
                                        RemainingSpeed += statModifier.Value;
                                    break;
                                case StatModifierTypes.Set:
                                    if (statModifier.StatType == StatTypes.MaxHealth)
                                        CurrentHealth = GetStat(StatTypes.MaxHealth).Value;
                                    if (statModifier.StatType == StatTypes.Speed && (Status != UnitStatuses.Preparing || Status != UnitStatuses.Enemy))
                                        RemainingSpeed = GetStat(StatTypes.Speed).Value;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    foreach (var keyword in enchantment.Enchantment.Keywords)
                    {
                        if (!HasKeyword(keyword))
                            CurrentKeywords.Add(keyword);
                    }

                    foreach (var statusEffect in enchantment.Enchantment.StatusEffects)
                    {
                        if (!CurrentStatusEffects.Contains(statusEffect))
                            CurrentStatusEffects.Add(statusEffect);
                    }

                    enchantment.IsApplied = true;
                }
            }
            else
            {
                throw new Exception("Not a valid enchantment");
            }
        }

        //Resets the health and speed to cap them out at their max
        CurrentHealth = currentHealth;
        RemainingSpeed = remainingSpeed;

        if (UnitCounter != null)
            UnitCounter.RefreshUnitCounter();
    }
}
