﻿using System.Collections;
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
        Immune,
        Indestructible,
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
        public int Value { get; set; }
    }

    public UnitData UnitData { get { return CardData as UnitData; } }

    public List<Stat> Stats { get; set; }
    public List<Stat> GetStats { get { return Stats.Select(x => new Stat() { Type = x.Type, Value = x.Value }).ToList(); } }

    public int? TotalProtected
    {
        get
        {
            return GetStat(StatTypes.Protected) + GetStat(StatTypes.TempProtected);
        }
    }

    public StatisticStatuses HasBuffedAttack { get { return GetStat(StatTypes.Attack) > UnitData.Attack ? StatisticStatuses.Buffed : StatisticStatuses.None; } }
    public StatisticStatuses HealthStatus(bool returnDamaged = true)
    {
        if (CurrentHealth == GetStat(StatTypes.MaxHealth) && GetStat(StatTypes.MaxHealth) > UnitData.Health || GetStat(StatTypes.MaxHealth) > UnitData.Health && !returnDamaged)
            return StatisticStatuses.Buffed;
        return CurrentHealth < GetStat(StatTypes.MaxHealth) ? StatisticStatuses.Debuffed : StatisticStatuses.None;
    }
    public StatisticStatuses HasBuffedRange { get { return GetStat(StatTypes.Range) > UnitData.Range ? StatisticStatuses.Buffed : StatisticStatuses.None; } }
    public StatisticStatuses HasBuffedSpeed { get { return GetStat(StatTypes.Speed) > UnitData.Speed ? StatisticStatuses.Buffed : StatisticStatuses.None; } }

    public UnitStatuses Status { get; set; }
    public int CurrentHealth { get { return currentHealth; } set { currentHealth = Mathf.Min(GetStat(StatTypes.MaxHealth), value); } }
    private int currentHealth;
    public int RemainingSpeed { get { return remainingSpeed; } set { remainingSpeed = Mathf.Min(GetStat(StatTypes.Speed), value); } }
    private int remainingSpeed;
    public int ActionsLeft { get; set; }
    public int AbilityUsesLeft { get; set; }
    public bool CanMove { get { return ActionsLeft > 0 && RemainingSpeed > 0 && !HasStatusEffect(StatusEffects.Rooted) && !HasStatusEffect(StatusEffects.Stunned) && Status != UnitStatuses.Preparing; } }
    public bool CanAction { get { return ActionsLeft > 0 && !HasStatusEffect(StatusEffects.Stunned) && Status != UnitStatuses.Preparing; } }
    public bool LoseNextAction { get; set; }
    public bool CanAttack { get { return CanAction && GetStat(StatTypes.Attack) > 0; } }
    public bool CanCastSpell
    {
        get
        {
            return (Status != UnitStatuses.Enemy &&
                ((Status == UnitStatuses.Preparing && IsHero && GameManager.instance.CurrentRound == 1) || Status != UnitStatuses.Preparing))
                && !HasStatusEffect(StatusEffects.Stunned)
                && (HasKeyword(Keywords.Conduit) || IsHero);
        }
    }
    public bool CanFlyOrLand { get; set; }
    public bool TemporaryMindControlled { get; set; }

    public List<AppliedEnchantment> Enchantments { get; set; }
    public List<StatusEffects> CurrentStatusEffects { get; set; }
    public List<Keywords> BaseKeywords { get { return UnitData.Keywords; } }
    public List<Keywords> CurrentKeywords { get; set; }
    public Unit OriginalTransformForm { get; set; }

    public List<UnitTags> UnitTags { get { return UnitData.UnitTag; } }
    public string UnitTag { get { return string.Join(" ", UnitTags.Select(x => x.ToString())); } }

    public List<AbilityData> DefaultAbilities { get { return UnitData.Abilities; } }
    public List<Ability> Abilities { get; set; }
    public bool HasAbilities { get { return Abilities.Count > 0; } }

    public UnitCounter UnitCounter { get; set; }
    public bool IsDeployed { get { return UnitCounter != null; } }

    public List<Card> ConfiscatedCards { get; set; }
    public List<Unit> ImprisonedUnits { get; set; }

    public List<Card> SpymasterLurenCards { get; set; }

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
        CurrentHealth = GetStat(StatTypes.MaxHealth);
        RemainingSpeed = 0;
        TemporaryMindControlled = false;
        LoseNextAction = false;
        
        ConfiscatedCards = new List<Card>();
        ImprisonedUnits = new List<Unit>();

        SpymasterLurenCards = new List<Card>();

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

            if (Owner != null)
            {
                foreach (var passive in Owner.Passives)
                {
                    if (passive.Enchantment != null)
                        if (passive.PassiveApplies(this))
                            AddEnchantment(passive.Enchantment);
                }
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
        int currentTempProtected = 0;
        int currentProtected = UnitData.Protected;

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

    public void RefreshCounter()
    {
        if (UnitCounter != null)
            UnitCounter.RefreshUnitCounter();
    }

    public int GetStat(StatTypes statType)
    {
        return Stats.Single(x => x.Type == statType).Value;
    }

    public void ModifyStat(StatModifierTypes modifierType, StatTypes statType, int value)
    {
        switch (modifierType)
        {
            case StatModifierTypes.Modify:
                var currentValue = Stats.Single(x => x.Type == statType).Value;
                ModifyStat(StatModifierTypes.Set, statType, currentValue + value);
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

        if (Owner.UsedResources.Contains(CardResources.Mana))
        {
            var manaResource = (PlayerMana)Owner.Resources.Single(x => x.ResourceType == CardResources.Mana);
            manaResource.SetOverloadModifiers();
        }

        UpdateOwnerStats();
    }

    public void Transform(bool canAction, Unit originalForm = null)
    {
        if (originalForm == null)
        {
            ResourceConvert(Classes.GetClassData(Owner.PlayerClass).GetResourceOfType(ClassResourceType.ResourceTypes.Dominant));
        }
        else
        {
            OriginalTransformForm = originalForm;
            CurrentStatusEffects.Add(StatusEffects.Transformed);
        }

        if (originalForm != null && originalForm.IsHero)
        {
            GameManager.instance.uiManager.RefreshHeroStats(Owner.Id, this);
        }

        if (canAction)
        {
            RefreshActions();
        }


        RefreshCounter();
    }

    private void ReturnToOriginalFromActionReset()
    {
        if (Status == UnitStatuses.Enemy)
            Status = UnitStatuses.Enemy;
        else
            Status = UnitStatuses.Preparing;

        ActionsLeft = 0;
        AbilityUsesLeft = 0;
        RemainingSpeed = 0;

        RefreshCounter();
    }

    public void ReturnToOriginalForm()
    {
        if (HasStatusEffect(StatusEffects.Transformed))
        {
            var currentCell = UnitCounter.Cell;
            RemoveUnit();
            GameManager.instance.effectManager.CreateUnitCounter(OriginalTransformForm, currentCell);

            OriginalTransformForm.ReturnToOriginalFromActionReset();

            if (OriginalTransformForm.IsHero)
            {
                GameManager.instance.uiManager.RefreshHeroStats(Owner.Id, OriginalTransformForm);
            }

            if (Owner.HasSpecialPassive(SpecialPassiveEffects.ShapeshiftersMask, out Passive shapeshiftersMaskPassive))
            {
                OriginalTransformForm.HealUnit(shapeshiftersMaskPassive.SpecialPassiveProperty);
            }
        }
        else
            throw new Exception("Cannot return a non-transformed unit to its original form.");
    }

    public void UpdateOwnerStats(bool isAdded = true)
    {
        if (isAdded)
        {
            if (GetStat(StatTypes.Empowered) > 0)
                Owner.ModifyEmpowered(GetStat(StatTypes.Empowered));
            if (HasKeyword(Keywords.Summon))
                Owner.AddSummon(UnitCounter);
        }
        else
        {
            if (GetStat(StatTypes.Empowered) > 0)
                Owner.ModifyEmpowered(-GetStat(StatTypes.Empowered));
            if (HasKeyword(Keywords.Summon))
                Owner.RemoveSummon(UnitCounter);
        }

        GameManager.instance.uiManager.RefreshUI();
    }

    public bool CheckOccupancy(Cell newCell, bool isLanding = false)
    {
        var flyingInAccessableTerrains = new List<TerrainTypes> { TerrainTypes.TallObstacle };
        var eteherealInAccessableTerrains = new List<TerrainTypes> { TerrainTypes.Chasm };
        var inAccessableTerrains = new List<TerrainTypes> { TerrainTypes.Obstacle, TerrainTypes.Impassable, TerrainTypes.TallObstacle, TerrainTypes.Chasm };

        var canOccupy = false;

        if (!HasKeyword(Keywords.Structure))
        {
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
        }
        else
        {
            return true;
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
            if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay && (GameManager.instance.CurrentRound != 1 || HasKeyword(Keywords.Prepared)))
            {
                RefreshActions();
            }
            else
            {
                Status = UnitStatuses.Preparing;
            }

            if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            {
                ModifyStat(StatModifierTypes.Set, StatTypes.TempProtected, 0);
                RemoveEnchantmentsOfStatus(new List<UnitEnchantment.EnchantmentStatus>() { UnitEnchantment.EnchantmentStatus.StartOfOwnersTurn });
                if (IsHero && Owner.HasSpecialPassive(SpecialPassiveEffects.WoundResistant))
                {
                    if (Owner.UsedResources.Contains(CardResources.Energy))
                    {
                        var playerEnergy = (PlayerEnergy)Owner.Resources.Single(x => x.ResourceType == CardResources.Energy);
                        HealUnit(playerEnergy.BaseEnergyGain);
                    }
                }

                if (Owner.HasSpecialPassive(SpecialPassiveEffects.RestorativeBlessing, out Passive restorativeBlessingPassive))
                {
                    HealUnit(restorativeBlessingPassive.SpecialPassiveProperty);
                }
            }
        }
        else
        {
            Status = UnitStatuses.Enemy;
            RemoveEnchantmentsOfStatus(new List<UnitEnchantment.EnchantmentStatus>() { UnitEnchantment.EnchantmentStatus.StartOfOpponentTurn });
        }

        RefreshCounter();
    }

    private void RefreshActions()
    {
        Status = UnitStatuses.Start;
        if (HasKeyword(Keywords.Flying))
            CanFlyOrLand = true;

        RemainingSpeed = GetStat(StatTypes.Speed);

        if (HasKeyword(Keywords.SpecialSwiftstrike))
        {
            ActionsLeft = 3;
            AbilityUsesLeft = HasAbilities ? 3 : 0;
        }
        else if (HasKeyword(Keywords.Swiftstrike))
        {
            ActionsLeft = 2;
            AbilityUsesLeft = HasAbilities ? 1 : 0;
        }
        else
        {
            ActionsLeft = 1;
            AbilityUsesLeft = HasAbilities ? 1 : 0;
        }

        if (LoseNextAction)
        {
            ModifyActions(-1);
            LoseNextAction = false;
        }
    }

    public bool EndOfTurn(bool isActive)
    {
        if (CheckEtherealEndOfTurn())
            return true;

        if (isActive)
        {
            RemoveEnchantmentsOfStatus(new List<UnitEnchantment.EnchantmentStatus>() { UnitEnchantment.EnchantmentStatus.EndOfOwnersTurn, UnitEnchantment.EnchantmentStatus.AfterAttack });
        }
        else
        {
            RemoveEnchantmentsOfStatus(new List<UnitEnchantment.EnchantmentStatus>() { UnitEnchantment.EnchantmentStatus.EndOfOpponentTurn, UnitEnchantment.EnchantmentStatus.AfterAttack });
        }

        UnitCounter.RefreshUnitCounter();

        if (IsHero && ((Hero)this).ActiveMagisFury.HasValue && !((Hero)this).ActiveMagisFury.Value)
        {
            RemoveUnit(true);
        }

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

    public void UseSpeed(int usedSpeed, bool isDisengage)
    {
        if (usedSpeed == 0)
        {
            throw new Exception("Cannot Use 0 Speed");
        }
        else
        {
            RemainingSpeed -= usedSpeed;
            if (isDisengage)
                ModifyActions(-1);
            else
                Status = UnitStatuses.Middle;

            RefreshCounter();
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

        RefreshCounter();
    }

    public bool CanAttackTarget(Unit targetUnit)
    {
        //Currently not working and will need more work, as this does not account for attacks external to the action attack (e.g. attacks through spells). As such commented out

        if (!CanAttack)
            return false;

        if (Owner.Id == targetUnit.Owner.Id)
            return false;

        if (targetUnit.HasStatusEffect(StatusEffects.Airborne) && GetStat(StatTypes.Range) == 0)
            return false;

        if (targetUnit.HasStatusEffect(StatusEffects.Stealthed) && Name != "Scout Regiment") //Hardcoded to account for scout regiment being able to target stealth units. FIX
            return false;

        return true;
    }

    public void TriggerAttack(Unit targetUnit, bool useAction = true, bool forceMelee = false)
    {
        if (useAction)
            ModifyActions(-1);
        Unstealth();

        var targetRouted = targetUnit.CheckRouting();

        bool unitDead = false;
        var targetDead = false;

        if (!targetRouted)
        {
            var targetHealth = targetUnit.CurrentHealth;

            var targetStunned = targetUnit.HasStatusEffect(StatusEffects.Stunned);
            targetDead = targetUnit.DamageUnit(Owner, GetStat(StatTypes.Attack), CurrentKeywords);
            if ((GetStat(StatTypes.Range) == 0 || forceMelee) && !targetStunned)
            {
                bool hasOverwhelm = HasKeyword(Keywords.Overwhelm);
                if (!targetDead && hasOverwhelm || !hasOverwhelm)
                {
                    unitDead = DamageUnit(targetUnit.Owner, targetUnit.GetStat(StatTypes.Attack), targetUnit.CurrentKeywords);
                }
            }

            if (targetDead && !unitDead)
            {
                CheckUnleash(targetUnit.GetStat(StatTypes.Attack), targetHealth);
            }
        }
        else
        {
            targetUnit.RemoveUnit();
        }

        RemoveEnchantmentsOfStatus(new List<UnitEnchantment.EnchantmentStatus>() { UnitEnchantment.EnchantmentStatus.AfterAttack });

        if (!unitDead)
            RefreshCounter();
        if (!targetDead && !targetRouted)
            targetUnit.RefreshCounter();
    }

    public bool CheckRouting()
    {
        if (HasKeyword(Keywords.Routing))
        {
            var missingHealth = GetStat(StatTypes.MaxHealth) - CurrentHealth;
            var randomValue = UnityEngine.Random.Range(0, GetStat(StatTypes.MaxHealth));
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

            var modifier = Owner.HasSpecialPassive(SpecialPassiveEffects.FeralNature) ? 2 : 1;
            unleashEnchantment.AddStatModifier(StatTypes.Attack, StatModifierTypes.Modify, targetAttack * modifier);
            unleashEnchantment.AddStatModifier(StatTypes.MaxHealth, StatModifierTypes.Modify, targetHealth * modifier);

            AddEnchantment(unleashEnchantment);
        }
    }

    public bool DamageUnit(Player sourcePlayer, int damageValue, List<Keywords> keywords = null)
    {
        var isDead = false;

        if (!HasStatusEffect(StatusEffects.Immune) && !HasStatusEffect(StatusEffects.Indestructible))
        {
            if (keywords == null)
                keywords = new List<Keywords>();

            if (keywords.Contains(Keywords.Piercing))
            {
                CurrentHealth -= damageValue;
                if (CurrentHealth <= 0 || keywords.Contains(Keywords.Deadly))
                {
                    RemoveUnit(true);
                    isDead = true;
                }
                if (keywords.Contains(Keywords.Lifebond))
                    sourcePlayer.Hero.HealUnit(damageValue);
            }
            else
            {
                if (TotalProtected.HasValue)
                {
                    if (Owner.HasSpecialPassive(SpecialPassiveEffects.LunarEclipse) && TotalProtected.Value > 0)
                        damageValue = 1;

                    ModifyStat(StatModifierTypes.Modify, StatTypes.TempProtected, -damageValue);
                    if (GetStat(StatTypes.TempProtected) < 0)
                    {
                        ModifyStat(StatModifierTypes.Modify, StatTypes.Protected, GetStat(StatTypes.TempProtected));
                        ModifyStat(StatModifierTypes.Set, StatTypes.TempProtected, 0);
                        if (GetStat(StatTypes.Protected) < 0)
                        {
                            CurrentHealth += GetStat(StatTypes.Protected);

                            if (keywords.Contains(Keywords.Lifebond))
                                sourcePlayer.Hero.HealUnit(-GetStat(StatTypes.Protected));

                            if (keywords.Contains(Keywords.Deadly))
                            {
                                if (IsHero)
                                    Redeploy();
                                else
                                    RemoveUnit(true);
                                isDead = true;
                            }
                            else if (CurrentHealth <= 0)
                            {
                                RemoveUnit(true);
                                isDead = true;
                            }

                            ModifyStat(StatModifierTypes.Set, StatTypes.Protected, 0);
                        }
                    }
                }
            }

            RefreshCounter();

            if (!isDead && Owner.HasSpecialPassive(SpecialPassiveEffects.PainDrivenWarriors, out Passive painDrivenWarriors))
            {
                HealUnit(painDrivenWarriors.SpecialPassiveProperty);
            }
        }

        return isDead;
    }

    public void HealUnit(int? healValue)
    {
        if (healValue.HasValue)
        {
            var excessHeal = CurrentHealth + healValue.Value - GetStat(StatTypes.MaxHealth);
            CurrentHealth = Mathf.Min(GetStat(StatTypes.MaxHealth), CurrentHealth + healValue.Value);

            if (IsHero && Owner.HasSpecialPassive(SpecialPassiveEffects.DivineProtection) && excessHeal > 0)
                AddProtected(excessHeal);
        }
        else
            CurrentHealth = GetStat(StatTypes.MaxHealth);

        RefreshCounter();
    }

    public void AddProtected(int value, bool isTemporary = false)
    {
        if (isTemporary)
            ModifyStat(StatModifierTypes.Modify, StatTypes.TempProtected, value);
        else
            ModifyStat(StatModifierTypes.Modify, StatTypes.Protected, value);
        RefreshCounter();
    }

    public void RemoveUnit(bool isDestroy = false)
    {
        if (HasStatusEffect(StatusEffects.Transformed) && isDestroy)
        {
            ReturnToOriginalForm();
        }
        else
        {
            if (!isDestroy || isDestroy && !HasStatusEffect(StatusEffects.Indestructible))
            {
                if (IsHero && isDestroy)
                {
                    if (Owner.DeathDefiant)
                    {
                        int halfHealth = GetStat(StatTypes.MaxHealth) / 2;
                        HealUnit(null);
                        DamageUnit(Owner, halfHealth);
                        Redeploy();
                        Owner.DeathDefiant = false;
                    }
                    else if (((Hero)this).ActiveMagisFury.HasValue && ((Hero)this).ActiveMagisFury.Value)
                    {
                        ((Hero)this).ActiveMagisFury = false;
                        CurrentHealth = 1;
                        AddProtected(10);
                        Owner.ModifyEmpowered(3);
                        RefreshCounter();
                        GameManager.instance.uiManager.RefreshUI();
                    }
                    else
                    {
                        Owner.TriggerHeroLoss();
                        GameManager.instance.effectManager.RemoveUnitCounter(UnitCounter);
                        UpdateOwnerStats(false);
                        GameManager.instance.uiManager.RefreshUI();
                        GameManager.instance.CheckWarden();
                    }
                }
                else
                {
                    if (SpymasterLurenCards.Any())
                        GameManager.instance.effectManager.ReturnLurenCards(this);

                    UpdateOwnerStats(false);
                    GameManager.instance.effectManager.RemoveUnitCounter(UnitCounter);

                    if (isDestroy)
                    {
                        ReturnCaptureCards();
                        if (!HasKeyword(Keywords.Token))
                        {
                            Owner.AddToGraveyard(this);
                        }
                    }

                    GameManager.instance.uiManager.RefreshUI();
                    GameManager.instance.CheckWarden();
                }
            }
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

        RefreshCounter();
    }

    public void AddEnchantment(UnitEnchantment enchantment)
    {
        if (enchantment.ValidEnchantment)
        {
            var newEnchantment = new AppliedEnchantment() { Enchantment = enchantment };
            if (newEnchantment.Enchantment.Keywords.Contains(Keywords.Flying))
            {
                if (!HasStatusEffect(StatusEffects.Airborne))
                {
                    newEnchantment.Enchantment.StatusEffects.Add(StatusEffects.Airborne);
                    if (Status != UnitStatuses.Preparing)
                        CanFlyOrLand = true;
                }
            }
            if (newEnchantment.Enchantment.Keywords.Contains(Keywords.Stealth))
                newEnchantment.Enchantment.StatusEffects.Add(StatusEffects.Stealthed);

            if (Status != UnitStatuses.Preparing && Status != UnitStatuses.None)
            {
                if (newEnchantment.Enchantment.Keywords.Contains(Keywords.SpecialSwiftstrike))
                {
                    if (!HasKeyword(Keywords.Swiftstrike) && !HasKeyword(Keywords.SpecialSwiftstrike))
                        ModifyActions(2);
                    else if (HasKeyword(Keywords.Swiftstrike))
                        ModifyActions(1);
                }
                else if (newEnchantment.Enchantment.Keywords.Contains(Keywords.Swiftstrike))
                    if (!HasKeyword(Keywords.Swiftstrike) && !HasKeyword(Keywords.SpecialSwiftstrike))
                        ModifyActions(1);
            }

            Enchantments.Add(newEnchantment);
            UpdateEnchantments();

            if (HasKeyword(Keywords.Prepared) && (Status == UnitStatuses.Preparing || Status == UnitStatuses.None))
                RefreshActions();

            RefreshCounter();
        }
        else
        {
            throw new Exception("Enchantment is not valid to add to unit");
        }
    }

    public void RemoveEnchantmentsOfStatus(List<UnitEnchantment.EnchantmentStatus> enchantmentStatuses)
    {
        var removeEnchantments = Enchantments.Where(x => enchantmentStatuses.Contains(x.Enchantment.Status));

        foreach (var statusEffectList in removeEnchantments.Select(x => x.Enchantment.StatusEffects))
        {
            CurrentStatusEffects.RemoveAll(x => statusEffectList.Contains(x));
        }

        Enchantments.RemoveAll(x => removeEnchantments.Contains(x));

        UpdateEnchantments();

        RefreshCounter();
    }

    public void UpdateEnchantments()
    {
        ResetStats();
        CurrentKeywords.Clear();

        foreach (var enchantment in Enchantments.OrderBy(x => x.Enchantment.Status))
        {
            if (enchantment.Enchantment.Status != UnitEnchantment.EnchantmentStatus.None)
            {
                if (enchantment.IsActive)
                {
                    if (enchantment.Enchantment.Status == UnitEnchantment.EnchantmentStatus.OverloadPassive)
                    {
                        var totalOverload = 0;
                        if (Owner.UsedResources.Contains(CardResources.Mana))
                            totalOverload = ((PlayerMana)Owner.Resources.Single(x => x.ResourceType == CardResources.Mana)).TotalOverload;

                        var currentAttack = GetStat(StatTypes.Attack);

                        int attackModifier;
                        if (currentAttack > 0)
                            attackModifier = Mathf.Min(totalOverload, currentAttack - 1);
                        else
                            attackModifier = 0;

                        enchantment.Enchantment.AddStatModifier(StatTypes.Attack, StatModifierTypes.Modify, -attackModifier);
                    }

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
                                    {
                                        RemainingSpeed += statModifier.Value;
                                        if (CanMove && Status != UnitStatuses.Enemy && Status != UnitStatuses.Start)
                                            Status = UnitStatuses.Middle;
                                    }
                                    break;
                                case StatModifierTypes.Set:
                                    if (statModifier.StatType == StatTypes.MaxHealth)
                                        CurrentHealth = GetStat(StatTypes.MaxHealth);
                                    if (statModifier.StatType == StatTypes.Speed && (Status != UnitStatuses.Preparing || Status != UnitStatuses.Enemy))
                                    {
                                        RemainingSpeed = GetStat(StatTypes.Speed);
                                        if (CanMove && Status != UnitStatuses.Enemy && Status != UnitStatuses.Start)
                                            Status = UnitStatuses.Middle;
                                    }
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
                            if (!HasStatusEffect(statusEffect))
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
        if (GetStat(StatTypes.Attack) < 0)
            ModifyStat(StatModifierTypes.Set, StatTypes.Attack, 0);

        GameManager.instance.CheckWarden();

        RefreshCounter();
    }

    public void DeleteEnchantment(AppliedEnchantment enchantment)
    {
        Enchantments.Remove(enchantment);
        CurrentStatusEffects.RemoveAll(x => enchantment.Enchantment.StatusEffects.Contains(x));
        UpdateEnchantments();
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

    public void ImmuneUnit()
    {
        var enchantment = new UnitEnchantment()
        {
            Status = UnitEnchantment.EnchantmentStatus.Permanent,
            Source = "Immune",
            StatusEffects = new List<StatusEffects>() { StatusEffects.Immune }
        };
        AddEnchantment(enchantment);
    }

    public void IndestructibleUnit()
    {
        var enchantment = new UnitEnchantment()
        {
            Status = UnitEnchantment.EnchantmentStatus.Permanent,
            Source = "Indestructible",
            StatusEffects = new List<StatusEffects>() { StatusEffects.Indestructible }
        };
        AddEnchantment(enchantment);
    }

    public bool CheckWarden()
    {
        if (CurrentStatusEffects.Contains(StatusEffects.Warded))
        {
            CurrentStatusEffects.Remove(StatusEffects.Warded);
            UnitCounter.RefreshUnitCounter();
        }

        if (!HasKeyword(Keywords.Stalker) && !UnitCounter.Cell.IsSurveyed(Owner.Id))
        {
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
                                    RefreshCounter();
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
                CanFlyOrLand = false;
                CurrentStatusEffects.Remove(StatusEffects.Airborne);
            }
        }
        else
        {
            CanFlyOrLand = false;
            CurrentStatusEffects.Add(StatusEffects.Airborne);
        }

        RefreshCounter();
    }

    public void Unstealth()
    {
        if (HasStatusEffect(StatusEffects.Stealthed))
            CurrentStatusEffects.Remove(StatusEffects.Stealthed);

        RefreshCounter();
    }

    public void Spellbind()
    {
        if (HasStatusEffect(StatusEffects.Transformed))
        {
            ReturnToOriginalForm();
            OriginalTransformForm.Spellbind();
        }
        else
        {
            if (HasKeyword(Keywords.Summon))
            {
                RemoveUnit(true);
            }
            else
            {
                foreach (var enchantment in Enchantments)
                    if (enchantment.Enchantment.Status != UnitEnchantment.EnchantmentStatus.Passive)
                        enchantment.IsActive = false;

                UpdateOwnerStats(false);
                ConfiscatedCards.Clear();
                ImprisonedUnits.Clear();
                CurrentStatusEffects.Clear();
                CurrentStatusEffects.Add(StatusEffects.Spellbound);
                UpdateEnchantments();
            }
        }
    }

    /// <summary>
    ///
    /// DEPRICATED: DO NOT USE
    ///
    /// </summary>
    public void RestoreEnchantments()
    {
        if (CurrentStatusEffects.Contains(StatusEffects.Spellbound))
        {
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
        UpdateOwnerStats(false);

        Owner = newOwner;
        Owner.DeployedUnits.Add(UnitCounter);
        UpdateOwnerStats();

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

        RefreshCounter();
        GameManager.instance.CheckWarden();
    }

    public void TriggerMadness()
    {
        var adjacentUnits = UnitCounter.Cell.adjCell.Where(x => x.occupantCounter != null).Select(x => x.occupantCounter.Unit).ToList();

        if (adjacentUnits.Count() != 0)
        {
            var randUnit = UnityEngine.Random.Range(0, adjacentUnits.Count());
            TriggerAttack(adjacentUnits[randUnit], false, true);
            if (CanAction)
            {
                ModifyActions(-1);
            }
            else
            {
                LoseNextAction = true;
            }
        }
    }

    public void ReturnToHand()
    {
        if (HasStatusEffect(StatusEffects.Transformed))
        {
            ReturnToOriginalForm();
            OriginalTransformForm.ReturnToHand();
        }
        else if (HasKeyword(Keywords.Token))
        {
            RemoveUnit(true);
        }
        else
        {
            if (IsHero)
            {
                Redeploy();
            }
            else
            {
                RemoveUnit();
                InitCard(CardData, Owner);
                Owner.AddToHand(this);
            }
        }
    }

    public void Redeploy(bool destroyCounter = true)
    {
        if (destroyCounter)
            RemoveUnit();
        Owner.AddToRedeploy(this);
    }

    public void ModifyOverloadEnchantment(PlayerMana manaResource = null)
    {
        string overloadSourceString = "Overload Reduction";

        if (Owner.UsedResources.Contains(CardResources.Mana))
        {
            if (manaResource == null)
                manaResource = (PlayerMana)Owner.Resources.Single(x => x.ResourceType == CardResources.Mana);

            var overloadEnchantment = Enchantments.Select(x => x.Enchantment).SingleOrDefault(x => x.Source == overloadSourceString);
            var isNew = false;
            if (overloadEnchantment == null)
            {
                overloadEnchantment = new UnitEnchantment() { Status = UnitEnchantment.EnchantmentStatus.OverloadPassive, Source = overloadSourceString };
                isNew = true;
            }

            overloadEnchantment.AddStatModifier(StatTypes.Attack, StatModifierTypes.Modify, manaResource.TotalOverload);

            if (isNew)
                AddEnchantment(overloadEnchantment);
            else
                UpdateEnchantments();
        }
        else
        {
            throw new Exception("Cannot modify overload enchantment for a non-mana class");
        }
    }

    public void CaptureCard(Card confiscatedCard = null, Unit imprisonedUnit = null)
    {
        if (confiscatedCard == null && imprisonedUnit == null)
            throw new Exception("Cannot capture no cards");

        if (confiscatedCard != null)
        {
            ConfiscatedCards.Add(confiscatedCard);
            confiscatedCard.Owner.Hand.RemoveCard(confiscatedCard);
        }

        if (imprisonedUnit != null)
        {
            ImprisonedUnits.Add(imprisonedUnit);
            imprisonedUnit.RemoveUnit();
        }
    }

    public void ReturnCaptureCards()
    {
        foreach (var card in ConfiscatedCards)
            card.Owner.AddToHand(card);
        foreach (var unit in ImprisonedUnits)
            unit.Owner.AddToRedeploy(unit);

        ConfiscatedCards.Clear();
        ImprisonedUnits.Clear();
    }
}
