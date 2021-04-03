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
        None, //Status for when the card is not in play
        Start, //Status for start of turn
        Preparing, //Status for just played
        Middle, //Status for still actions, movement or abilities to use
        Finished, //Status for all actions spent
        Enemy, //Status for enemy cards
    }

    public enum StatusEffects
    {
        None,
        Airborne,
        Rooted,
        Spellbound,
        Stealthed,
        Stunned,
        Transformed,
        Warded,
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

    public UnitData UnitData { get { return CardData as UnitData; } }

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
    public StatisticStatuses HealthStatus
    {
        get
        {
            if (CurrentHealth == GetStat(StatTypes.MaxHealth) && GetStat(StatTypes.MaxHealth) > UnitData.Health)
                return StatisticStatuses.Buffed;
            return CurrentHealth < GetStat(StatTypes.MaxHealth) ? StatisticStatuses.Debuffed : StatisticStatuses.None;
        }
    }
    public StatisticStatuses HasBuffedRange { get { return GetStat(StatTypes.Range) > UnitData.Range ? StatisticStatuses.Buffed : StatisticStatuses.None; } }
    public StatisticStatuses HasBuffedSpeed { get { return GetStat(StatTypes.Speed) > UnitData.Speed ? StatisticStatuses.Buffed : StatisticStatuses.None; } }

    public UnitStatuses Status { get; set; }
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = Mathf.Min(GetStat(StatTypes.MaxHealth).Value, value); } }
    private int currentHealth;
    public int RemainingSpeed { get { return remainingSpeed; } set { remainingSpeed = Mathf.Min(GetStat(StatTypes.Speed).Value, value); } }
    private int remainingSpeed;
    public int ActionsLeft { get; set; }
    public int AbilityUsesLeft { get; set; }
    public bool CanMove { get { return ActionsLeft > 0 && RemainingSpeed > 0 && !HasStatusEffect(StatusEffects.Rooted) && !HasStatusEffect(StatusEffects.Stunned); } }
    public bool CanAction { get { return ActionsLeft > 0 && !HasStatusEffect(StatusEffects.Stunned); } }
    public bool CanFlyOrLand { get; set; }
    public bool TemporaryMindControlled { get; set; }

    public List<AppliedEnchantment> Enchantments { get; set; }
    public List<StatusEffects> CurrentStatusEffects { get; set; }
    public List<Keywords> BaseKeywords { get { return UnitData.Keywords; } }
    public List<Keywords> CurrentKeywords { get; set; }

    public List<UnitTags> UnitTags { get { return UnitData.UnitTag; } }
    public string UnitTag { get { return string.Join(" ", UnitTags.Select(x => x.ToString())); } }

    public List<AbilityData> DefaultAbilities { get { return UnitData.Abilities; } }
    public List<Ability> Abilities { get; set; }

    public UnitCounter UnitCounter { get; set; }
    public bool IsDeployed { get { return UnitCounter != null; } }

    public bool HasKeyword(Keywords keyword)
    {
        return CurrentKeywords.Contains(keyword);
    }

    public bool HasStatusEffect(StatusEffects statusEffect)
    {
        return CurrentStatusEffects.Contains(statusEffect);
    }

    public override void InitCard(CardData _cardData, Player owner)
    {
        base.InitCard(_cardData, owner);

        ResetStats(true);
        AbilityInit();

        Status = UnitStatuses.None;
        CurrentHealth = GetStat(StatTypes.MaxHealth).Value;
        TemporaryMindControlled = false;

        if (GameManager.instance.CurrentGamePhase != GameManager.GamePhases.Menu)
        {
            Enchantments = new List<AppliedEnchantment>();
            CurrentStatusEffects = new List<StatusEffects>();
            CurrentKeywords = new List<Keywords>();

            if (BaseKeywords.Count > 0 || UnitData.Empowered > 0)
            {
                var keywordEnchantment = new UnitEnchantment()
                {
                    Source = "Base Keywords",
                    Status = UnitEnchantment.EnchantmentStatus.Base,
                };
                keywordEnchantment.Keywords = BaseKeywords.ToList();
                if (UnitData.Empowered > 0)
                    keywordEnchantment.AddStatModifier(StatTypes.Empowered, StatModifierTypes.Modify, UnitData.Empowered);

                AddEnchantment(keywordEnchantment);
            }
        }
    }

    /// <summary>
    /// 
    /// Initialises the abilities on the unit. To be called when the card is created
    /// 
    /// </summary>
    protected void AbilityInit()
    {
        Abilities = new List<Ability>();
        foreach (var abilityData in DefaultAbilities)
        {
            var ability = new Ability(abilityData, this);
            Abilities.Add(ability);
        }
    }

    public override void ResourceConvert(CardResources newResource)
    {
        base.ResourceConvert(newResource);

        foreach (var ability in Abilities)
            ability.ConvertResource(newResource);
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
            new Stat() { Type = StatTypes.Empowered, Value = 0 },
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

        Deploy();
    }

    public void Deploy()
    {
        if (Status == UnitStatuses.None)
        {
            if (Owner.Id == GameManager.instance.ActivePlayerId)
                Status = UnitStatuses.Preparing;
            else if (Owner.Id == GameManager.instance.InactivePlayerId)
                Status = UnitStatuses.Enemy;
        }

        if (GetStat(StatTypes.Empowered).Value > 0)
            Owner.ModifyEmpowered(GetStat(StatTypes.Empowered).Value);
        if (HasKeyword(Keywords.Summon))
            Owner.AddSummon(UnitCounter);
    }

    public bool CheckOccupancy(Cell newCell, bool isLanding = false)
    {
        var flyingInAccessableTerrains = new List<TerrainTypes> { TerrainTypes.TallObstacle };
        var eteherealInAccessableTerrains = new List<TerrainTypes> { TerrainTypes.Chasm };
        var inAccessableTerrains = new List<TerrainTypes> { TerrainTypes.Obstacle, TerrainTypes.Impassable, TerrainTypes.TallObstacle, TerrainTypes.Chasm };

        var canOccupy = false;

        if (HasStatusEffect(StatusEffects.Airborne) && !isLanding)
        {
            canOccupy = canOccupy || !flyingInAccessableTerrains.Contains(newCell.terrainType);
        }
        if (HasKeyword(Keywords.Ethereal))
        {
            canOccupy = canOccupy || !eteherealInAccessableTerrains.Contains(newCell.terrainType);
        }
        if (!HasStatusEffect(StatusEffects.Airborne) || isLanding)
        {
            canOccupy = canOccupy || !inAccessableTerrains.Contains(newCell.terrainType);
        }

        return canOccupy;
    }

    public override void CopyCardStats(Card copyFrom)
    {
        base.CopyCardStats(copyFrom);

        var copyUnit = (Unit)copyFrom;

        foreach (var enchantment in copyUnit.Enchantments)
            AddEnchantment(enchantment.Enchantment);
    }

    public void StartOfTurn()
    {
        if (Owner.IsActivePlayer)
        {
            if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Mulligan)
            {
                Status = UnitStatuses.Preparing;
            }
            else if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            {
                if (GameManager.instance.CurrentRound != 1 || HasKeyword(Keywords.Prepared))
                {
                    RefreshActions();
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

    private void RefreshActions()
    {
        Status = UnitStatuses.Start;
        if (HasKeyword(Keywords.Flying))
            CanFlyOrLand = true;

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

    public bool EndOfTurn(bool isActive)
    {
        if (CheckEtherealEndOfTurn())
            return true;

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

        if (true)
        {

        }

        UnitCounter.RefreshUnitCounter();

        return false;
    }

    public bool CheckEtherealEndOfTurn()
    {
        if (HasKeyword(Keywords.Ethereal))
        {
            var etherealDestroyTerrains = new List<TerrainTypes> { TerrainTypes.Impassable, TerrainTypes.Obstacle, TerrainTypes.TallObstacle };
            return etherealDestroyTerrains.Contains(UnitCounter.Cell.terrainType);
        }

        return false;
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

    public void UseDisengageSpeed(int usedSpeed)
    {
        if (usedSpeed == 0)
        {
            throw new Exception("Cannot Use 0 Speed");
        }
        else
        {
            RemainingSpeed -= usedSpeed;
            ModifyActions(-1);

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
        Unstealth();

        var targetRouted = targetUnit.CheckRouting();

        if (!targetRouted)
        {
            var targetHealth = targetUnit.CurrentHealth;
            bool unitDead = false;
            var targetDead = targetUnit.DamageUnit(Owner, GetStat(StatTypes.Attack).Value, CurrentKeywords);
            if (GetStat(StatTypes.Range).Value == 0)
            {
                bool hasOverwhelm = HasKeyword(Keywords.Overwhelm);
                if (!targetDead && hasOverwhelm || !hasOverwhelm)
                {
                    unitDead = DamageUnit(targetUnit.Owner, targetUnit.GetStat(StatTypes.Attack).Value, targetUnit.CurrentKeywords);
                }
            }

            if (targetDead && !unitDead)
            {
                CheckUnleash(targetUnit.GetStat(StatTypes.Attack).Value, targetHealth);
            }
        }
        else
        {
            targetUnit.RemoveUnit();
        }

        RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus.AfterAttack);

        if (HasStatusEffect(StatusEffects.Stealthed))
            CurrentStatusEffects.Remove(StatusEffects.Stealthed);

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
                RemoveUnit(true);
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
                            RemoveUnit(true);
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

    public void RemoveUnit(bool isDestroy = false)
    {
        GameManager.instance.effectManager.RemoveUnitCounter(UnitCounter);

        if (isDestroy)
        {
            Owner.AddToGraveyard(this);

            if (GetStat(StatTypes.Empowered).Value > 0)
                Owner.ModifyEmpowered(-GetStat(StatTypes.Empowered).Value);
            if (HasKeyword(Keywords.Summon))
                Owner.RemoveSummon(UnitCounter);

            UnitCounter.Cell.gameplayUI.RefreshPlayerBar(Owner.Id);
        }
    }

    public bool CanUseAbility(Ability ability)
    {
        var canSpendResources = Resource.CanSpendResources(Owner, ability.ResourceCost);
        var canSpendAction = ability.CostsAction ? CanAction : true;
        var canUseability = AbilityUsesLeft > 0;

        return canSpendResources && canSpendAction && canUseability;
    }

    public void ModifyAbilities(int value)
    {
        AbilityUsesLeft += value;
    }

    public void UseAbility(Ability ability)
    {
        Owner.ModifyResources(ability.ResourceCost);

        ModifyAbilities(-1);
        ModifyActions(ability.CostsAction ? -1 : 0);
        Unstealth();

        UnitCounter.RefreshUnitCounter();
    }

    public void AddEnchantment(UnitEnchantment enchantment)
    {
        if (enchantment.ValidEnchantment)
        {
            var newEnchantment = new AppliedEnchantment() { Enchantment = enchantment };
            if (newEnchantment.Enchantment.Keywords.Contains(Keywords.Flying))
            {
                newEnchantment.Enchantment.StatusEffects.Add(StatusEffects.Airborne);
                CanFlyOrLand = true;
            }
            if (newEnchantment.Enchantment.Keywords.Contains(Keywords.Stealth))
                newEnchantment.Enchantment.StatusEffects.Add(StatusEffects.Stealthed);

            Enchantments.Add(newEnchantment);
            UpdateEnchantments();

            if (HasKeyword(Keywords.Prepared) && (Status == UnitStatuses.Preparing || Status == UnitStatuses.None))
                RefreshActions();

            if (UnitCounter != null)
                UnitCounter.RefreshUnitCounter();
        }
        else
        {
            throw new Exception("Enchantment is not valid to add to unit");
        }
    }

    public void RemoveEnchantmentsOfStatus(UnitEnchantment.EnchantmentStatus enchantmentStatus)
    {
        var removeEnchantments = Enchantments.Where(x => x.Enchantment.Status == enchantmentStatus);

        foreach (var statusEffectList in removeEnchantments.Select(x => x.Enchantment.StatusEffects))
        {
            CurrentStatusEffects.RemoveAll(x => statusEffectList.Contains(x));
        }

        Enchantments.RemoveAll(x => removeEnchantments.Contains(x));

        UpdateEnchantments();

        if (UnitCounter != null)
            UnitCounter.RefreshUnitCounter();
    }

    private void UpdateEnchantments()
    {
        ResetStats();
        CurrentKeywords.Clear();

        foreach (var enchantment in Enchantments.OrderByDescending(x => x.Enchantment.Status))
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

                            if (statModifier.StatType == StatTypes.Empowered && IsDeployed)
                                Owner.ModifyEmpowered(statModifier.Value);
                        }
                    }

                    foreach (var keyword in enchantment.Enchantment.Keywords)
                    {
                        if (!HasKeyword(keyword))
                            CurrentKeywords.Add(keyword);
                    }

                    foreach (var statusEffect in enchantment.Enchantment.StatusEffects)
                    {
                        if (!enchantment.IsApplied)
                        {
                            if (!CurrentStatusEffects.Contains(statusEffect))
                                CurrentStatusEffects.Add(statusEffect);
                        }
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

        GameManager.instance.CheckWarden();

        if (UnitCounter != null)
            UnitCounter.RefreshUnitCounter();
    }

    public void RootUnit()
    {
        var enchantment = new UnitEnchantment()
        {
            Status = UnitEnchantment.EnchantmentStatus.EndOfOwnersTurn,
            Source = "Root",
            StatusEffects = new List<StatusEffects>() { StatusEffects.Rooted }
        };
        AddEnchantment(enchantment);
    }

    public void StunUnit()
    {
        var enchantment = new UnitEnchantment()
        {
            Status = UnitEnchantment.EnchantmentStatus.EndOfOwnersTurn,
            Source = "Stun",
            StatusEffects = new List<StatusEffects>() { StatusEffects.Stunned }
        };
        AddEnchantment(enchantment);
    }

    public bool CheckWarden()
    {
        if (!HasKeyword(Keywords.Stalker))
        {
            if (CurrentStatusEffects.Contains(StatusEffects.Warded))
            {
                CurrentStatusEffects.Remove(StatusEffects.Warded);
                UnitCounter.RefreshUnitCounter();
            }

            foreach (var adjCell in UnitCounter.Cell.adjCell)
            {

                if (adjCell.occupantCounter != null)
                {
                    var adjUnit = adjCell.occupantCounter.Unit;
                    if (adjUnit.Owner.Id != Owner.Id)
                    {
                        if (adjUnit.HasKeyword(Keywords.Warden))
                        {
                            if (!adjUnit.HasStatusEffect(StatusEffects.Stunned))
                            {
                                if (CheckWardenMatchingKeywords(adjUnit, Keywords.Ethereal) && CheckWardenMatchingKeywords(adjUnit, Keywords.Flying))
                                {
                                    CurrentStatusEffects.Add(StatusEffects.Warded);
                                    UnitCounter.RefreshUnitCounter();
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
        }

        return false;
    }

    private bool CheckWardenMatchingKeywords(Unit adjUnit, Keywords keyword)
    {
        return !HasKeyword(keyword) || HasKeyword(keyword) && adjUnit.HasKeyword(keyword);
    }

    public void FlyOrLand()
    {
        if (HasStatusEffect(StatusEffects.Airborne))
        {
            if (CheckOccupancy(UnitCounter.Cell, true))
            {
                Debug.Log(UnitCounter.Cell.terrainType);
                CanFlyOrLand = false;
                CurrentStatusEffects.Remove(StatusEffects.Airborne);
            }
        }
        else
        {
            CanFlyOrLand = false;
            CurrentStatusEffects.Add(StatusEffects.Airborne);
        }

        UnitCounter.RefreshUnitCounter();
    }

    public void Unstealth()
    {
        if (HasStatusEffect(StatusEffects.Stealthed))
            CurrentStatusEffects.Remove(StatusEffects.Stealthed);

        UnitCounter.RefreshUnitCounter();
    }

    public void Spellbind()
    {
        foreach (var enchantment in Enchantments)
            if (enchantment.Enchantment.Status != UnitEnchantment.EnchantmentStatus.Passive)
                enchantment.IsActive = false;

        CurrentStatusEffects.Clear();
        CurrentStatusEffects.Add(StatusEffects.Spellbound);
        UpdateEnchantments();
    }

    public void RestoreEnchantments()
    {
        if (CurrentStatusEffects.Contains(StatusEffects.Spellbound))
        {
            var damageValue = GetStat(StatTypes.MaxHealth).Value - CurrentHealth;
            var missingSpeed = GetStat(StatTypes.Speed).Value - RemainingSpeed;

            foreach (var enchantment in Enchantments)
            {
                if (!enchantment.IsActive)
                {
                    enchantment.IsActive = true;
                    enchantment.IsApplied = false;
                }
            }

            CurrentStatusEffects.Remove(StatusEffects.Spellbound);
            UpdateEnchantments();
        }
    }

    public void SwitchOwner(Player newOwner, bool isTemporary)
    {
        TemporaryMindControlled = isTemporary;
        Owner.DeployedUnits.Remove(UnitCounter);
        Owner = newOwner;
        Owner.DeployedUnits.Add(UnitCounter);

        ResourceConvert(Classes.GetClassData(newOwner.PlayerClass).GetResourceOfType(ClassResourceType.ResourceTypes.Dominant));

        if (newOwner.IsActivePlayer)
        {
            if (isTemporary || HasKeyword(Keywords.Prepared))
            {
                RefreshActions();
            }
            else
            {
                Status = UnitStatuses.Preparing;
            }
        }
        else
        {
            Status = UnitStatuses.Enemy;
        }

        UnitCounter.RefreshUnitCounter();
    }
}
