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

    public List<UnitEnchantment> Enchantments { get; set; }
    public List<StatusEffects> CurrentStatusEffects { get; set; }
    public List<BaseUnitKeywords> BaseKeywords { get { return UnitData.Keywords; } }
    public List<BaseUnitKeywords> CurrentKeywords { get; set; }

    public List<UnitTags> UnitTags { get { return UnitData.UnitTag; } }
    public string UnitTag { get { return string.Join(" ", UnitTags.Select(x => x.ToString())); } }

    public List<AbilityData> Abilities { get { return UnitData.Abilities; } }

    public UnitCounter UnitCounter { get; set; }

    public override void InitCard(CardData _cardData, Player owner)
    {
        base.InitCard(_cardData, owner);

        ResetStats();

        Enchantments = new List<UnitEnchantment>();
        CurrentStatusEffects = new List<StatusEffects>();
        CurrentKeywords = new List<BaseUnitKeywords>();

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

    private void ResetStats()
    {
        var maxStats = 8;
        Stats = new List<Stat>(maxStats)
        {
            new Stat(){ Type = StatTypes.Attack, Value = UnitData.Attack },
            new Stat(){ Type = StatTypes.MaxHealth, Value = UnitData.Health },
            new Stat(){ Type = StatTypes.Protected, Value = UnitData.Protected },
            new Stat(){ Type = StatTypes.TempProtected, Value = 0 },
            new Stat(){ Type = StatTypes.Range, Value = UnitData.Range },
            new Stat(){ Type = StatTypes.Speed, Value = UnitData.Speed },
            new Stat(){ Type = StatTypes.Empowered, Value = UnitData.Empowered },
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
                if (statType == StatTypes.MaxHealth)
                    CurrentHealth += value.Value;
                if (statType == StatTypes.Speed && (Status != UnitStatuses.Preparing || Status != UnitStatuses.Enemy))
                    RemainingSpeed += value.Value;
                break;
            case StatModifierTypes.Set:
                Stats.Single(x => x.Type == statType).Value = value;
                if (statType == StatTypes.MaxHealth)
                    CurrentHealth = GetStat(StatTypes.MaxHealth).Value;
                if (statType == StatTypes.Speed && (Status != UnitStatuses.Preparing || Status != UnitStatuses.Enemy))
                    RemainingSpeed = GetStat(StatTypes.Speed).Value;
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
                if (GameManager.instance.CurrentRound != 1)
                {
                    Status = UnitStatuses.Start;

                    RemainingSpeed = GetStat(StatTypes.Speed).Value;
                    ActionsLeft = 1;
                    AbilityUsesLeft = 1;
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

        UnitCounter.RefreshUnitCounter();
    }

    public void TriggerAttack(Unit targetUnit)
    {
        ModifyActions(-1);

        targetUnit.DamageUnit(GetStat(StatTypes.Attack).Value, CurrentKeywords.Contains(BaseUnitKeywords.Piercing));
        if (GetStat(StatTypes.Range).Value == 0)
            DamageUnit(targetUnit.GetStat(StatTypes.Attack).Value, CurrentKeywords.Contains(BaseUnitKeywords.Piercing));

        RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus.AfterAttack);

        UnitCounter.RefreshUnitCounter();
        targetUnit.UnitCounter.RefreshUnitCounter();
    }

    public void DamageUnit(int damageValue, bool isPiercing)
    {
        if (isPiercing)
        {
            CurrentHealth -= damageValue;
            if (CurrentHealth <= 0)
                DestroyUnit();
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
                        ModifyStat(StatModifierTypes.Set, StatTypes.Protected, 0);
                    }
                }

                if (CurrentHealth <= 0)
                    DestroyUnit();
            }
        }

        UnitCounter.RefreshUnitCounter();
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
        Enchantments.Add(enchantment);
        UpdateEnchantments();

        if (CurrentKeywords.Contains(BaseUnitKeywords.Flying))
            CurrentStatusEffects.Add(StatusEffects.Flying);
        if (CurrentKeywords.Contains(BaseUnitKeywords.Stealth))
            CurrentStatusEffects.Add(StatusEffects.Stealthed);

        if (UnitCounter != null)
            UnitCounter.RefreshUnitCounter();
    }

    public void RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus enchantmentStatus)
    {
        var removeEnchantments = Enchantments.Where(x => x.Status == enchantmentStatus);

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
            if (enchantment.Status != UnitEnchantment.EnchantmentStatus.None)
            {
                if (enchantment.IsActive)
                {
                    foreach (var statModifier in enchantment.StatModifiers)
                    {
                        ModifyStat(statModifier.ModType, statModifier.StatType, statModifier.Value);
                    }

                    foreach (var keyword in enchantment.Keywords)
                    {
                        if (!CurrentKeywords.Contains(keyword))
                            CurrentKeywords.Add(keyword);
                    }

                    foreach (var statusEffect in enchantment.StatusEffects)
                    {
                        if (!CurrentStatusEffects.Contains(statusEffect))
                            CurrentStatusEffects.Add(statusEffect);
                    }
                }
            }
            else
            {
                throw new Exception("Not a valid enchantment");
            }
        }

        if (UnitCounter != null)
            UnitCounter.RefreshUnitCounter();
    }
}
