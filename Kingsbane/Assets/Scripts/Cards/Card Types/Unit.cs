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

    /// <summary>
    /// 
    /// The possible status effects to apply to a unit
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// The different stat types on the unit
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// Object for storing a stat for a unit
    /// 
    /// </summary>
    public class Stat
    {
        public StatTypes Type { get; set; }
        public int Value { get; set; }
    }

    public UnitData UnitData { get { return CardData as UnitData; } }

    public List<Stat> Stats { get; set; }
    public List<Stat> GetStats { get { return Stats.Select(x => new Stat() { Type = x.Type, Value = x.Value }).ToList(); } }

    /// <summary>
    /// 
    /// The total protected of the unit
    /// 
    /// </summary>
    public int TotalProtected
    {
        get
        {
            return GetStat(StatTypes.Protected) + GetStat(StatTypes.TempProtected);
        }
    }

    public StatisticStatuses HasBuffedAttack { get { return GetStat(StatTypes.Attack) > UnitData.Attack ? StatisticStatuses.Buffed : StatisticStatuses.None; } }
    public StatisticStatuses HealthStatus(bool returnDamaged = true)
    {
        //Set return damaged to false if on a card display, as this does not display current health but the max health
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
                //Cannot cast spells if preparing, unless the unit is the hero on the first round
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

        //The following code is ignored in the menu
        if (GameManager.instance.CurrentGamePhase != GameManager.GamePhases.Menu)
        {
            Enchantments = new List<AppliedEnchantment>();
            CurrentStatusEffects = new List<StatusEffects>();
            CurrentKeywords = new List<Keywords>();

            //Adds Keywords and Empowered as enchantments from the base unit properties
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

            //Add passive enchantments to the unit
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

    /// <summary>
    /// 
    /// Converts the units resource to a given new resource
    /// 
    /// </summary>
    /// <param name="newResource"></param>
    public override void ResourceConvert(CardResources newResource)
    {
        base.ResourceConvert(newResource);

        //Extends from base by including ability conversions
        foreach (var ability in Abilities)
            ability.ConvertResource(newResource);
    }

    /// <summary>
    /// 
    /// Resets the units stats to their base. 
    /// 
    /// </summary>
    /// <param name="fullReset">If true, will reset protected as well as other stats. Otherwise maintains the current protected</param>
    private void ResetStats(bool fullReset = false)
    {
        //Sets the default protected values
        int currentTempProtected = 0;
        int currentProtected = UnitData.Protected;

        //If not a full reset, saves the protected values to input later
        if (!fullReset)
        {
            currentTempProtected = GetStat(StatTypes.TempProtected);
            currentProtected = GetStat(StatTypes.Protected);
        }

        //Sets the stats for the unit
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

    /// <summary>
    /// 
    /// IF there is a unit counter associated, refreshes it
    /// 
    /// </summary>
    public void RefreshCounter()
    {
        if (UnitCounter != null)
            UnitCounter.RefreshUnitCounter();
    }

    /// <summary>
    /// 
    /// Gets a stat of a given type
    /// 
    /// </summary>
    public int GetStat(StatTypes statType)
    {
        return Stats.Single(x => x.Type == statType).Value;
    }

    /// <summary>
    /// 
    /// Modifies or sets a stat of a particular type
    /// 
    /// </summary>
    public void ModifyStat(StatModifierTypes modifierType, StatTypes statType, int value)
    {
        switch (modifierType)
        {
            //Modify stat if for flat increase or decrease
            case StatModifierTypes.Modify:
                var currentValue = Stats.Single(x => x.Type == statType).Value;
                ModifyStat(StatModifierTypes.Set, statType, currentValue + value);
                break;
            //Set stat if for wanting to set at a fixed value
            case StatModifierTypes.Set:
                Stats.Single(x => x.Type == statType).Value = value;
                break;
            default:
                throw new Exception("Not a valid modifier type");
        }
    }

    /// <summary>
    /// 
    /// Plays the card from hand
    /// 
    /// </summary>
    public override void Play()
    {
        base.Play();

        //Need to account for deployment effects

        Deploy();
    }

    /// <summary>
    /// 
    /// To be called when the card is deployed on the field
    /// 
    /// </summary>
    public void Deploy()
    {
        //If the status of the unit is none, sets up the base status for when a unit is deployed (certain cards may already have a status set, such as prepared)
        if (Status == UnitStatuses.None)
        {
            if (Owner.Id == GameManager.instance.ActivePlayerId)
                Status = UnitStatuses.Preparing;
            else if (Owner.Id == GameManager.instance.InactivePlayerId)
                Status = UnitStatuses.Enemy;
        }

        //If created by a mana class, checks if the overload modifiers need to be updated
        if (Owner.UsedResources.Contains(CardResources.Mana))
        {
            var manaResource = (PlayerMana)Owner.Resources.Single(x => x.ResourceType == CardResources.Mana);
            manaResource.SetOverloadModifiers();
        }

        //Updates the owners global stats after being deployed
        UpdateOwnerStats();
    }

    /// <summary>
    /// 
    /// Setup for the new form of a transformed unit
    /// 
    /// </summary>
    public void Transform(bool canAction, Unit originalForm = null)
    {
        //If there is no original form, this is a permanent transformation, so requires a resource conversion
        if (originalForm == null)
        {
            ResourceConvert(Classes.GetClassData(Owner.PlayerClass).GetResourceOfType(ClassResourceType.ResourceTypes.Dominant));
        }
        else
        {
            //If not, sets the original form and adds the status effect
            OriginalTransformForm = originalForm;
            CurrentStatusEffects.Add(StatusEffects.Transformed);
        }

        //If transforming the hero and there is an original form, refreshes the hero stats with this units stats
        if (originalForm != null && originalForm.IsHero)
        {
            GameManager.instance.uiManager.RefreshHeroStats(Owner.Id, this);
        }

        //If new form can use their actions straight away, refreshes their actions
        if (canAction)
        {
            RefreshActions();
        }

        //Refreshes the unit counter
        RefreshCounter();
    }

    /// <summary>
    /// 
    /// To be called on the original transform form to reset the actions
    /// 
    /// </summary>
    private void ReturnToOriginalFromActionReset()
    {
        //Sets the required status
        if (Status == UnitStatuses.Enemy)
            Status = UnitStatuses.Enemy;
        else
            Status = UnitStatuses.Preparing;

        //Resets their actions to their base
        ActionsLeft = 0;
        AbilityUsesLeft = 0;
        RemainingSpeed = 0;

        RefreshCounter();
    }

    /// <summary>
    /// 
    /// Returns the unit to its original form
    /// 
    /// </summary>
    public void ReturnToOriginalForm()
    {
        //Can only be applied to a transformed unit
        if (HasStatusEffect(StatusEffects.Transformed))
        {
            //Saves the current cell for later. Required as the unit counter is removed, so will not be able to access the cell later
            var currentCell = UnitCounter.Cell;
            RemoveUnit();
            //Creates the original form in the current cell
            GameManager.instance.effectManager.CreateUnitCounter(OriginalTransformForm, currentCell);

            //Sets the actions of the origianl form
            OriginalTransformForm.ReturnToOriginalFromActionReset();

            //If the original form is hero, resets the hero stats display
            if (OriginalTransformForm.IsHero)
            {
                GameManager.instance.uiManager.RefreshHeroStats(Owner.Id, OriginalTransformForm);
            }

            //If the player has Shapeshifters Mask passive, heals the unit
            if (Owner.HasSpecialPassive(SpecialPassiveEffects.ShapeshiftersMask, out Passive shapeshiftersMaskPassive))
            {
                OriginalTransformForm.HealUnit(shapeshiftersMaskPassive.SpecialPassiveProperty);
            }
        }
        else
            throw new Exception("Cannot return a non-transformed unit to its original form.");
    }

    /// <summary>
    /// 
    /// Updates the owners globl stats based on the properties of the unit
    /// 
    /// </summary>
    /// <param name="isAdded">To be false if the unit is being removed from the field. Otherwise true is being added to the field</param>
    public void UpdateOwnerStats(bool isAdded = true)
    {
        if (isAdded)
        {
            //If the unit is being added to the field, adds the empowered and summon stats to the player if required
            if (GetStat(StatTypes.Empowered) > 0)
                Owner.ModifyEmpowered(GetStat(StatTypes.Empowered));
            if (HasKeyword(Keywords.Summon))
                Owner.AddSummon(UnitCounter);
        }
        else
        {
            //If the unit is being removed from the field, removes the empowered and summon stats from the player if required
            if (GetStat(StatTypes.Empowered) > 0)
                Owner.ModifyEmpowered(-GetStat(StatTypes.Empowered));
            if (HasKeyword(Keywords.Summon))
                Owner.RemoveSummon(UnitCounter);
        }

        GameManager.instance.uiManager.RefreshUI();
    }

    /// <summary>
    /// 
    /// Checks if the unit can occupy the given cell
    /// 
    /// </summary>
    /// <param name="newCell">The cell to be checked</param>
    /// <param name="isLanding">True if the unit is landing in this cell</param>
    /// <param name="ignoreOccupant">True if ignorning the current occupant of the cell</param>
    /// <param name="ignoreFriendlyUnits">True if ignoring friendly units currently occuping the cell</param>
    /// <returns>True if can occupy the cell. False otherwise</returns>
    public bool CheckOccupancy(Cell newCell, bool isLanding = false, bool ignoreOccupant = false, bool ignoreFriendlyUnits = true)
    {
        //Structure units can occupy any tile, so always returns true
        if (!HasKeyword(Keywords.Structure))
        {
            //Sets the list of terrains each type of unit can occupy
            var flyingInAccessableTerrains = new List<TerrainTypes> { TerrainTypes.TallObstacle };
            var eteherealInAccessableTerrains = new List<TerrainTypes> { TerrainTypes.Chasm };
            var inAccessableTerrains = new List<TerrainTypes> { TerrainTypes.Obstacle, TerrainTypes.Impassable, TerrainTypes.TallObstacle, TerrainTypes.Chasm };

            var canOccupy = false;
            //Determines if the target cell has an occupant or not, using the ignore properties to check if cases need to be ignored
            var hasCellOccupant = ignoreOccupant || newCell.occupantCounter != null && (ignoreFriendlyUnits || !ignoreFriendlyUnits && newCell.occupantCounter.Unit.Status == UnitStatuses.Enemy);

            //For each type of unit case, sets the can occupy variable. If it is already set as true, this means the unit can occupy the tile, even if the later cases would be set to false

            //Determines if can occupy for currently airborne units that are not landing
            if (HasStatusEffect(StatusEffects.Airborne) && !isLanding)
            {
                //Checks the terrain types, then the occupant
                //If there is an occupant and the occupant is airborne, unit cannot pass through the tile
                canOccupy = canOccupy || !flyingInAccessableTerrains.Contains(newCell.terrainType) && (!hasCellOccupant ||
                    hasCellOccupant && !newCell.occupantCounter.Unit.HasStatusEffect(StatusEffects.Airborne));
            }
            //Determines can occupy for ethereal units
            if (HasKeyword(Keywords.Ethereal))
            {
                //Checks the terrain types, then the occupant
                //If there is an occupant and the occupant is ethereal, unit cannot pass through the tile
                canOccupy = canOccupy || !eteherealInAccessableTerrains.Contains(newCell.terrainType) && (!hasCellOccupant ||
                    hasCellOccupant && !newCell.occupantCounter.Unit.HasKeyword(Keywords.Ethereal));
            }
            //Determines can occupy for all other units, or units which are landing
            if (!HasStatusEffect(StatusEffects.Airborne) || isLanding)
            {
                //Checks the terrain types, then the occupant.
                //Regular units cannot pass through any units if there is an occupant
                canOccupy = canOccupy || !inAccessableTerrains.Contains(newCell.terrainType) && !hasCellOccupant;
            }

            return canOccupy;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// 
    /// Copies the stats of another card to this card
    /// 
    /// </summary>
    public override void CopyCardStats(Card copyFrom)
    {
        base.CopyCardStats(copyFrom);

        var copyUnit = (Unit)copyFrom;

        //Extension for units also copies the enchantments
        foreach (var enchantment in copyUnit.Enchantments)
            AddEnchantment(enchantment.Enchantment);
    }

    /// <summary>
    /// 
    /// Start of turn for a unit
    /// 
    /// </summary>
    public void StartOfTurn()
    {
        //Case for if the owner is active player
        if (Owner.IsActivePlayer)
        {
            //Refreshes the units action if the current phase is gameplay, or if the unit has prepared. If the current round is the first round, does not want to refresh actions
            //As this will cause the hero to be able to take actions on the first turn
            if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay && (GameManager.instance.CurrentRound != 1 || HasKeyword(Keywords.Prepared)))
            {
                RefreshActions();
            }
            else
            {
                //If the above cases are not true, unit is preparing
                Status = UnitStatuses.Preparing;
            }

            //Ignores the following unless the phase is gameplay, as if not in this phase, certain objects will not be set up yet
            if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            {
                //Removes any temporary protected the unit has
                ModifyStat(StatModifierTypes.Set, StatTypes.TempProtected, 0);
                //Remove any enchantments which are to be removed at start of owners turn
                RemoveEnchantmentsOfStatus(new List<UnitEnchantment.EnchantmentStatus>() { UnitEnchantment.EnchantmentStatus.StartOfOwnersTurn });
                //Passive updates for wound resistant
                if (IsHero && Owner.HasSpecialPassive(SpecialPassiveEffects.WoundResistant))
                {
                    if (Owner.UsedResources.Contains(CardResources.Energy))
                    {
                        var playerEnergy = (PlayerEnergy)Owner.Resources.Single(x => x.ResourceType == CardResources.Energy);
                        HealUnit(playerEnergy.BaseEnergyGain);
                    }
                }
                //Passive check for restorative blessing
                if (Owner.HasSpecialPassive(SpecialPassiveEffects.RestorativeBlessing, out Passive restorativeBlessingPassive))
                {
                    HealUnit(restorativeBlessingPassive.SpecialPassiveProperty);
                }
            }
        }
        else
        {
            //Set the units status to enemy if their owner is not the active player
            Status = UnitStatuses.Enemy;
            //Remove enchantments for start of opponents turn
            RemoveEnchantmentsOfStatus(new List<UnitEnchantment.EnchantmentStatus>() { UnitEnchantment.EnchantmentStatus.StartOfOpponentTurn });
        }

        //Refreshes the unit counter after start of turn updates
        RefreshCounter();
    }

    /// <summary>
    /// 
    /// Refreshes the units actions
    /// 
    /// </summary>
    private void RefreshActions()
    {
        //Sets the start status and allows the unit to move between flying or landing if required
        Status = UnitStatuses.Start;
        if (HasKeyword(Keywords.Flying))
            CanFlyOrLand = true;

        //Sets the unit speed
        RemainingSpeed = GetStat(StatTypes.Speed);

        //Sets the actions and abilities based on the keywords of the unit. Only gives ability uses if they have an ability
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

        //If the unit has been forced to lose their next action, their actions are modified by 1 and the property is reset
        if (LoseNextAction)
        {
            ModifyActions(-1);
            LoseNextAction = false;
        }
    }

    /// <summary>
    /// 
    /// End of turn updates for the unit
    /// 
    /// </summary>
    public bool EndOfTurn(bool isActive)
    {
        //If the unit is required to be destroyed because of ethereal properties, returns true
        if (CheckEtherealEndOfTurn())
            return true;

        //Removes enchantments of a particular status as required
        if (isActive)
        {
            RemoveEnchantmentsOfStatus(new List<UnitEnchantment.EnchantmentStatus>() { UnitEnchantment.EnchantmentStatus.EndOfOwnersTurn, UnitEnchantment.EnchantmentStatus.AfterAttack });
        }
        else
        {
            RemoveEnchantmentsOfStatus(new List<UnitEnchantment.EnchantmentStatus>() { UnitEnchantment.EnchantmentStatus.EndOfOpponentTurn, UnitEnchantment.EnchantmentStatus.AfterAttack });
        }

        //Refreshes the unit counter
        UnitCounter.RefreshUnitCounter();

        //Destroys the hero if their passive active Magis Fury has been activated
        if (IsHero && ((Hero)this).ActiveMagisFury.HasValue && !((Hero)this).ActiveMagisFury.Value)
        {
            RemoveUnit(true);
        }

        //Returns false as the unit is not to be destroyed
        return false;
    }

    /// <summary>
    /// 
    /// Checks if an ethereal unit needs to be destroyed if they are within invalid tiles
    /// 
    /// </summary>
    /// <returns></returns>
    public bool CheckEtherealEndOfTurn()
    {
        if (HasKeyword(Keywords.Ethereal))
        {
            var etherealDestroyTerrains = new List<TerrainTypes> { TerrainTypes.Impassable, TerrainTypes.Obstacle, TerrainTypes.TallObstacle };
            return etherealDestroyTerrains.Contains(UnitCounter.Cell.terrainType);
        }

        return false;
    }

    /// <summary>
    /// 
    /// Uses a units speed
    /// 
    /// </summary>
    /// <param name="usedSpeed">The amount of speed to use</param>
    /// <param name="isDisengage">If true, will use the units action when they move</param>
    public void UseSpeed(int usedSpeed, bool isDisengage = false)
    {
        //Cannot use 0 speed
        if (usedSpeed == 0)
        {
            throw new Exception("Cannot Use 0 Speed");
        }
        else
        {
            //Determines the units new remaining speed
            RemainingSpeed -= usedSpeed;
            //If disengaging, modifies the units action
            if (isDisengage)
                ModifyActions(-1);
            else
                //If normal movement, sets the units status to middle
                Status = UnitStatuses.Middle;

            //Refreshes the unit counter
            RefreshCounter();
        }
    }

    /// <summary>
    /// 
    /// Modifies the units action
    /// 
    /// </summary>
    /// <param name="value">The number of actions to modify by</param>
    public void ModifyActions(int value)
    {
        //Updates to the new number of actions
        ActionsLeft += value;
        //Sets the status of the unit based on the actions left
        if (ActionsLeft == 0)
            //If the unit has no actions left, they cannot do anything for the rest of the turn
            Status = UnitStatuses.Finished;
        else if (value <= 0)
            //If reducing the units actions, sets the status to middle
            Status = UnitStatuses.Middle;
        else if (value > 0)
            //If increasing the units actions and the unit is already finished, sets the status to middle
            if (Status == UnitStatuses.Finished)
                Status = UnitStatuses.Middle;

        RefreshCounter();
    }

    /// <summary>
    /// 
    /// Determine if the unit is eligible to attack the target unit
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// Use the units attack on a target unit
    /// 
    /// </summary>
    public void TriggerAttack(Unit targetUnit, bool useAction = true, bool forceMelee = false)
    {
        //If the attack requires an action to use, modifies their action
        if (useAction)
            ModifyActions(-1);
        //Attacking will always unstealth the unit
        Unstealth();

        //Checks if the target routs
        var targetRouted = targetUnit.CheckRouting();

        //Saves if the unit or the target dies
        bool unitDead = false;
        var targetDead = false;

        //If the target does not rout, then performs a normal attack
        if (!targetRouted)
        {
            //Saves the targets statistics, as they will be removed if the target dies
            var targetStunned = targetUnit.HasStatusEffect(StatusEffects.Stunned);
            var targetAttack = targetUnit.GetStat(StatTypes.Attack);
            var targetHealth = targetUnit.CurrentHealth;
            var targetKeywords = targetUnit.CurrentKeywords;
            //Checks if the target dies due to damage from the attacking units attack
            targetDead = targetUnit.DamageUnit(Owner, GetStat(StatTypes.Attack), CurrentKeywords);
            //If the attack is a melee attack and the target isn't stunned, damages the attacker back
            if ((GetStat(StatTypes.Range) == 0 || forceMelee) && !targetStunned)
            {
                //Checks if the unit has Overwhelm
                bool hasOverwhelm = HasKeyword(Keywords.Overwhelm);
                //If the target dies and the unit has Overwhelm, or the unit does not have Overwhelm, damages the attacker with the targets attack
                if (!targetDead && hasOverwhelm || !hasOverwhelm)
                {
                    unitDead = DamageUnit(targetUnit.Owner, targetAttack, targetKeywords);
                }
            }

            //If the target dies and the attacker does not die, checks if the unit gains unleash stats
            if (targetDead && !unitDead)
            {
                TriggerUnleash(targetAttack, targetHealth);
            }
        }
        //If the target routs, removes the routing unit
        else
        {
            targetUnit.RemoveUnit();
        }

        //Remove any after attack enchantments
        RemoveEnchantmentsOfStatus(new List<UnitEnchantment.EnchantmentStatus>() { UnitEnchantment.EnchantmentStatus.AfterAttack });

        //Refreshes the counters which are still active on the field
        if (!unitDead)
            RefreshCounter();
        if (!targetDead && !targetRouted)
            targetUnit.RefreshCounter();
    }

    /// <summary>
    /// 
    /// Checks if the unit routs when it is attacked
    /// 
    /// </summary>
    /// <returns></returns>
    public bool CheckRouting()
    {
        //Unit can only rout if they have routing
        if (HasKeyword(Keywords.Routing))
        {
            //Determines if the unit routs based on their missing health
            var missingHealth = GetStat(StatTypes.MaxHealth) - CurrentHealth;
            var randomValue = UnityEngine.Random.Range(0, GetStat(StatTypes.MaxHealth));
            return randomValue < missingHealth;
        }

        return false;
    }

    /// <summary>
    /// 
    /// Checks if the unit gains stats from Unleash
    /// 
    /// </summary>
    public void TriggerUnleash(int targetAttack, int targetHealth)
    {
        //Only triggers if the attacker has Unleash
        if (HasKeyword(Keywords.Unleash))
        {
            //Creates a new Unleash enchantment
            var unleashEnchantment = new UnitEnchantment()
            {
                Source = "Unleash",
                Status = UnitEnchantment.EnchantmentStatus.Permanent,
            };

            var modifier = Owner.HasSpecialPassive(SpecialPassiveEffects.FeralNature) ? 2 : 1; //If the unit has passive Feral Nature, adds a double modifier for the stats
            //Adds the modifiers to the enchantment
            unleashEnchantment.AddStatModifier(StatTypes.Attack, StatModifierTypes.Modify, targetAttack * modifier);
            unleashEnchantment.AddStatModifier(StatTypes.MaxHealth, StatModifierTypes.Modify, targetHealth * modifier);

            //Adds the unleash enchantment to the unit
            AddEnchantment(unleashEnchantment);
        }
    }

    /// <summary>
    /// 
    /// Damages the unit
    /// 
    /// </summary>
    /// <param name="sourcePlayer">The player which the damage is originating from. Required for Lifebond triggers</param>
    /// <param name="damageValue">The value of damage</param>
    /// <param name="keywords">The keywords which are applied to the damage</param>
    /// <returns></returns>
    public bool DamageUnit(Player sourcePlayer, int damageValue, List<Keywords> keywords = null)
    {
        //Storing if the unit is killed by the damage
        var isDead = false;

        //Cannot deal damage to immune or indestructible units
        if (!HasStatusEffect(StatusEffects.Immune) && !HasStatusEffect(StatusEffects.Indestructible))
        {
            //Sets up an empty list of keywords if there are no keywords for the damage
            if (keywords == null)
                keywords = new List<Keywords>();

            //If damage is piercing, ignore protected and deal damage directly to health
            if (keywords.Contains(Keywords.Piercing))
            {
                CurrentHealth -= damageValue;
                //Removes the unit if the damage is deadly
                if (keywords.Contains(Keywords.Deadly))
                {
                    //If the target is a hero, redeploys it instead of removing it
                    if (IsHero)
                        Redeploy();
                    else
                        RemoveUnit(true);
                    isDead = true;
                }
                //Removes the unit if their health
                else if (CurrentHealth <= 0)
                {
                    RemoveUnit(true);
                    isDead = true;
                }
                //If the damage is lifebond, heals the damage source's healer
                if (keywords.Contains(Keywords.Lifebond))
                    sourcePlayer.Hero.HealUnit(damageValue);
            }
            else
            {
                //If the owner has Lunar Eclipse active, and the unit has protected, reduces the damage to 1
                if (Owner.HasSpecialPassive(SpecialPassiveEffects.LunarEclipse) && TotalProtected > 0)
                    damageValue = 1;

                //Applies damage to temp protected first
                ModifyStat(StatModifierTypes.Modify, StatTypes.TempProtected, -damageValue);
                //If the temporary protected goes below 0, this means there is no temp protected remaining, so deals damage to their base protected
                if (GetStat(StatTypes.TempProtected) < 0)
                {
                    //Applies damage to protected next. The damage is equal to the negative temp protected
                    ModifyStat(StatModifierTypes.Modify, StatTypes.Protected, GetStat(StatTypes.TempProtected));
                    //Resets the temporary protected back to 0
                    ModifyStat(StatModifierTypes.Set, StatTypes.TempProtected, 0);
                    //As above, if negative protected, this means there is no protected remaing, so applies damage to health
                    if (GetStat(StatTypes.Protected) < 0)
                    {
                        //Reduces health by the negative protected value
                        CurrentHealth += GetStat(StatTypes.Protected);

                        //If the damage is lifebond, damage, only heals the enemy hero for the amount of damage they deal to the units health
                        if (keywords.Contains(Keywords.Lifebond))
                            sourcePlayer.Hero.HealUnit(-GetStat(StatTypes.Protected));

                        //Determines if the damage is deadly
                        if (keywords.Contains(Keywords.Deadly))
                        {
                            //If the unit is a hero, redeploy it instead of removing it
                            if (IsHero)
                                Redeploy();
                            else
                                RemoveUnit(true);
                            isDead = true;
                        }
                        //Destroys the unit if their health is below 0
                        else if (CurrentHealth <= 0)
                        {
                            RemoveUnit(true);
                            isDead = true;
                        }

                        //Resets the units protected back to 0
                        ModifyStat(StatModifierTypes.Set, StatTypes.Protected, 0);
                    }
                }
            }

            //Refreshes the unit counter
            RefreshCounter();

            //If the unit doesnt die and the unit has special passive Pain Driven Warriors and if the unit has no protected (as this would mean damage would be dealt to their health),
            //Then heals it as per the passive rules
            if (!isDead && Owner.HasSpecialPassive(SpecialPassiveEffects.PainDrivenWarriors, out Passive painDrivenWarriors) && TotalProtected == 0)
            {
                HealUnit(painDrivenWarriors.SpecialPassiveProperty);
            }
        }

        return isDead;
    }

    /// <summary>
    /// 
    /// Heals the unit for a given value
    /// 
    /// </summary>
    public void HealUnit(int? healValue)
    {
        //If the heal value has a value, heals the unit for that amount
        if (healValue.HasValue)
        {
            //Stores any excess health the unit will gain from the heal
            var excessHeal = CurrentHealth + healValue.Value - GetStat(StatTypes.MaxHealth);
            //Sets the current health, capping out at the units max health
            CurrentHealth = Mathf.Min(GetStat(StatTypes.MaxHealth), CurrentHealth + healValue.Value);

            if (IsHero && Owner.HasSpecialPassive(SpecialPassiveEffects.DivineProtection) && excessHeal > 0)
                AddProtected(excessHeal);
        }
        //If there is no value for the healing value, then regenerates the unit back to full health
        else
            CurrentHealth = GetStat(StatTypes.MaxHealth);

        RefreshCounter();
    }

    /// <summary>
    /// 
    /// Add a given value of protected to the unit
    /// 
    /// </summary>
    public void AddProtected(int value, bool isTemporary = false)
    {
        //Adds protected or temp protected based on the given parameters
        if (isTemporary)
            ModifyStat(StatModifierTypes.Modify, StatTypes.TempProtected, value);
        else
            ModifyStat(StatModifierTypes.Modify, StatTypes.Protected, value);
        RefreshCounter();
    }

    /// <summary>
    /// 
    /// Removes a unit from the field
    /// 
    /// </summary>
    /// <param name="isDestroy">If true, destroys the unit on removal. If false, then just removes the unit counter</param>
    public void RemoveUnit(bool isDestroy = false)
    {
        //If the unit is transformed and is being destroyed, return the unit to its original form
        if (HasStatusEffect(StatusEffects.Transformed) && isDestroy)
        {
            ReturnToOriginalForm();
        }
        else
        {
            //Cannot destroys an indestructible unit, but can remove it
            if (!isDestroy || isDestroy && !HasStatusEffect(StatusEffects.Indestructible))
            {
                //Case if destroying a hero
                if (IsHero && isDestroy)
                {
                    //Sets the hero to half their max health and redeploy
                    if (Owner.DeathDefiant)
                    {
                        int halfHealth = GetStat(StatTypes.MaxHealth) / 2;
                        CurrentHealth = halfHealth;
                        Redeploy();
                        Owner.DeathDefiant = false;
                    }
                    //If the hero has an active Magis Fury, does not kill them and adds required properties
                    else if (((Hero)this).ActiveMagisFury.HasValue && ((Hero)this).ActiveMagisFury.Value)
                    {
                        ((Hero)this).ActiveMagisFury = false;
                        CurrentHealth = 1;
                        AddProtected(10);
                        Owner.ModifyEmpowered(3);
                        RefreshCounter();
                        GameManager.instance.uiManager.RefreshUI();
                    }
                    //Otherwise if the hero dies, triggers the loss of their hero
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
                    //If the unit has any Spymaster Luren Cards associated with them, returns the cards
                    if (SpymasterLurenCards.Any())
                        GameManager.instance.effectManager.ReturnLurenCards(this);

                    //Updates owner stats and removes the counter
                    UpdateOwnerStats(false);
                    GameManager.instance.effectManager.RemoveUnitCounter(UnitCounter);

                    //If the unit is being destroyed, return any captured cards and adds the unit to the graveyard
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

    /// <summary>
    /// 
    /// Checks if the unit can use the given ability
    /// 
    /// </summary>
    public bool CanUseAbility(Ability ability)
    {
        //Determines if the ability can be used based on resources, then actions, then if they have ability uses
        var canSpendResources = Resource.CanSpendResources(Owner, ability.ResourceCost);
        var canSpendAction = ability.CostsAction ? CanAction : true;
        var canUseability = AbilityUsesLeft > 0;

        //If all properties are true, unit can use their ability
        return canSpendResources && canSpendAction && canUseability;
    }

    /// <summary>
    /// 
    /// Modifies the units ability uses
    /// 
    /// </summary>
    public void ModifyAbilities(int value)
    {
        AbilityUsesLeft += value;
    }

    /// <summary>
    /// 
    /// Have the unit use the given ability
    /// 
    /// </summary>
    public void UseAbility(Ability ability)
    {
        //Modify the owners resources
        Owner.ModifyResources(ability.ResourceCost);

        //Modifies the properties of the unit by using the ability
        ModifyAbilities(-1);
        ModifyActions(ability.CostsAction ? -1 : 0);
        //Using an ability unstealths the unit
        Unstealth();

        RefreshCounter();
    }

    /// <summary>
    /// 
    /// Adds an enchantment to the unit
    /// 
    /// </summary>
    public void AddEnchantment(UnitEnchantment enchantment)
    {
        //Checks if the enchantment is valid
        if (enchantment.ValidEnchantment)
        {
            //Creates the new applied enchantment. Required to make a new object, as if Unit Enchantment is changed, this will modify all other instances
            // of the enchantment. Applied Enchantment is unique to each applied unit
            var newEnchantment = new AppliedEnchantment() { Enchantment = enchantment };

            //If the enchantment adds flying, also adds airborne to the enchantment
            if (newEnchantment.Enchantment.Keywords.Contains(Keywords.Flying))
            {
                if (!HasStatusEffect(StatusEffects.Airborne))
                {
                    if (!newEnchantment.Enchantment.StatusEffects.Contains(StatusEffects.Airborne))
                        newEnchantment.Enchantment.StatusEffects.Add(StatusEffects.Airborne);
                    if (Status != UnitStatuses.Preparing)
                        CanFlyOrLand = true;
                }
            }
            //If the enchantment adds the stealth keyword, also adds the stealthed status effect
            if (newEnchantment.Enchantment.Keywords.Contains(Keywords.Stealth))
                if (!newEnchantment.Enchantment.StatusEffects.Contains(StatusEffects.Stealthed))
                    newEnchantment.Enchantment.StatusEffects.Add(StatusEffects.Stealthed);

            //If the enchantment adds swiftstike and specifal swiftstrike keywords and the unit is not preparing, updates their actions.
            //Also checks the unit doesnt already have the keyword- if they do doesn't add actions
            if (Status != UnitStatuses.Preparing && Status != UnitStatuses.None)
            {
                if (newEnchantment.Enchantment.Keywords.Contains(Keywords.SpecialSwiftstrike))
                {
                    //If moving from normal to special swiftstrike, adds 2 actions (so they have 3 actions total)
                    if (!HasKeyword(Keywords.Swiftstrike) && !HasKeyword(Keywords.SpecialSwiftstrike))
                        ModifyActions(2);
                    //If already has swiftstrike and adding special swiftstrike, adds 1 action (to 3 actions total)
                    else if (HasKeyword(Keywords.Swiftstrike))
                        ModifyActions(1);
                }
                //If moving from normal to swiftstrike, adds 1 action (to 3 actions total)
                else if (newEnchantment.Enchantment.Keywords.Contains(Keywords.Swiftstrike))
                    if (!HasKeyword(Keywords.Swiftstrike) && !HasKeyword(Keywords.SpecialSwiftstrike))
                        ModifyActions(1);
            }

            //Adds the enchantment to the list, then updates the units enchantments
            Enchantments.Add(newEnchantment);
            UpdateEnchantments();

            //If the enchantment adds preparing, and the unit is not already prepared, then refreshes their actions
            if (HasKeyword(Keywords.Prepared) && (Status == UnitStatuses.Preparing || Status == UnitStatuses.None))
                RefreshActions();

            //Updates the counter
            RefreshCounter();
        }
        else
        {
            throw new Exception("Enchantment is not valid to add to unit");
        }
    }

    /// <summary>
    /// 
    /// Remove any enchantments of a particular status type
    /// 
    /// </summary>
    public void RemoveEnchantmentsOfStatus(List<UnitEnchantment.EnchantmentStatus> enchantmentStatuses)
    {
        //Obtains all enchantments to remove
        var removeEnchantments = Enchantments.Where(x => enchantmentStatuses.Contains(x.Enchantment.Status));

        //Removes all status effects given from the remove enchantments
        foreach (var statusEffectList in removeEnchantments.Select(x => x.Enchantment.StatusEffects))
        {
            CurrentStatusEffects.RemoveAll(x => statusEffectList.Contains(x));
        }

        //Remove all required enchantments
        Enchantments.RemoveAll(x => removeEnchantments.Contains(x));

        //Update the enchantments
        UpdateEnchantments();
    }

    /// <summary>
    /// 
    /// Update the units enchantments
    /// 
    /// </summary>
    public void UpdateEnchantments()
    {
        //Function works by reseting the unit to its base then adding each enchantment again. This is required to deal with enchantments being removed from the list
        //May also be needed in future in case enchantments are reactivated, but not utilised currently

        //Resets the units stats to their base state
        ResetStats();
        CurrentKeywords.Clear();

        //Orders the enchantment list so that overload passive is applied last. This is to ensure that the attack reduction from the passive is
        //applied across all active enchantments
        var enchantments = new List<AppliedEnchantment>(Enchantments);
        var overloadEnchantment = enchantments.SingleOrDefault(x => x.Enchantment.Status == UnitEnchantment.EnchantmentStatus.OverloadPassive);
        if (overloadEnchantment != null)
        {
            enchantments.Remove(overloadEnchantment);
            enchantments.Add(overloadEnchantment);
        }

        //Loops through each enchantment. Orders by the enchantment status so that passives enchantments are applied last
        foreach (var enchantment in enchantments)
        {
            //Only adds an enchantment if it is of a valid status
            if (enchantment.Enchantment.Status != UnitEnchantment.EnchantmentStatus.None)
            {
                //Only adds active enchantments to the unit stats
                if (enchantment.IsActive)
                {
                    //For Overload Passives, need to get the current attack modifier
                    if (enchantment.Enchantment.Status == UnitEnchantment.EnchantmentStatus.OverloadPassive)
                    {
                        //Gets the total overload value from the mana resource
                        var totalOverload = 0;
                        if (Owner.UsedResources.Contains(CardResources.Mana))
                            totalOverload = ((PlayerMana)Owner.Resources.Single(x => x.ResourceType == CardResources.Mana)).TotalOverload;

                        //Gets the current attack of the unit
                        var currentAttack = GetStat(StatTypes.Attack);

                        //Determine the attack modifier, which is capped so the units attack cannot be reduced below 1
                        int attackModifier;
                        //If the attack is greater than 0, than 0, needs to determine the attack modifier
                        if (currentAttack > 0)
                            //Sets the attack modifier to be equal to the total overload or so the attack is set to 1
                            attackModifier = Mathf.Min(totalOverload, currentAttack - 1);
                        //If the attack is 0, sets the attack modifier to 0 (prevents attack from going negative)
                        else
                            attackModifier = 0;

                        //Updates the stat modifier for the overload enchantment
                        enchantment.Enchantment.AddStatModifier(StatTypes.Attack, StatModifierTypes.Modify, -attackModifier);
                    }

                    //Loops through each stat modifier in the enchantment
                    foreach (var statModifier in enchantment.Enchantment.StatModifiers)
                    {
                        //Modifies the stat associated with the modifier
                        ModifyStat(statModifier.ModType, statModifier.StatType, statModifier.Value);

                        //If the enchantment has already been applied, do not need to update the current health and speed of the unit
                        if (!enchantment.IsApplied)
                        {
                            switch (statModifier.ModType)
                            {
                                case StatModifierTypes.Modify:
                                    //If modifying the max health, need to also modify the current health of the unit
                                    if (statModifier.StatType == StatTypes.MaxHealth)
                                    {
                                        //If the stat modifier is positive, then increases the current health by the same value
                                        if (statModifier.Value >= 0)
                                            CurrentHealth += statModifier.Value;
                                        //If the stat modifier is negative, do not need to reduce the current health, but sets it to itself to cap the value at max health
                                        else
                                            CurrentHealth = CurrentHealth;
                                    }
                                    //If modifying the speed, need to also modify the remaining speed. Only to be done if the unit is not preparing or an enemy
                                    if (statModifier.StatType == StatTypes.Speed && (Status != UnitStatuses.Preparing || Status != UnitStatuses.Enemy))
                                    {
                                        //If the stat modifier is positive, then increase the remaining speed by the same value
                                        if (statModifier.Value >= 0)
                                            RemainingSpeed += statModifier.Value;
                                        //If the stat modifier is negative, do not need to reduce the reamining speed, but sets it to itself to cap the value at its speed
                                        else
                                            RemainingSpeed = RemainingSpeed;
                                        //If the unit can move and is not an enemy or in the start status, sets it to the middle status
                                        if (CanMove && Status != UnitStatuses.Enemy && Status != UnitStatuses.Start)
                                            Status = UnitStatuses.Middle;
                                    }
                                    break;
                                case StatModifierTypes.Set:
                                    //If setting the max health, need to also set the current health to its max
                                    if (statModifier.StatType == StatTypes.MaxHealth)
                                        CurrentHealth = GetStat(StatTypes.MaxHealth);
                                    //If setting the speed, need to also set the remaining speed to its max, as long as the unit is not preparing or an enemy
                                    if (statModifier.StatType == StatTypes.Speed && (Status != UnitStatuses.Preparing || Status != UnitStatuses.Enemy))
                                    {
                                        RemainingSpeed = GetStat(StatTypes.Speed);
                                        //If the unit can move and is not an enemy or in the start status, sets it to the middle status
                                        if (CanMove && Status != UnitStatuses.Enemy && Status != UnitStatuses.Start)
                                            Status = UnitStatuses.Middle;
                                    }
                                    break;
                                default:
                                    break;
                            }

                            //If the enchantment adds empowered and the unit is already deployed, adds empowered to the owners stats
                            if (statModifier.StatType == StatTypes.Empowered && IsDeployed)
                                Owner.ModifyEmpowered(statModifier.Value);
                        }
                    }

                    //Adds the keywords from the enchantment to the unit
                    foreach (var keyword in enchantment.Enchantment.Keywords)
                    {
                        if (!HasKeyword(keyword))
                            CurrentKeywords.Add(keyword);
                    }

                    //Adds the status effects from the enchantment to the unit
                    foreach (var statusEffect in enchantment.Enchantment.StatusEffects)
                    {
                        //If the enchantment already is applied, then do not need to add the status effect
                        if (!enchantment.IsApplied)
                        {
                            if (!HasStatusEffect(statusEffect))
                                CurrentStatusEffects.Add(statusEffect);
                        }
                    }

                    //Once all modifiers from the enchantment have been added, confirm the application
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
        //If the units attack is below 0, then sets it back to 0
        if (GetStat(StatTypes.Attack) < 0)
            ModifyStat(StatModifierTypes.Set, StatTypes.Attack, 0);

        //Need to check warden in case enchantments have added or removed the keyword
        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            GameManager.instance.CheckWarden();

        RefreshCounter();
    }

    /// <summary>
    /// 
    /// Deletes an enchantment
    /// 
    /// </summary>
    public void DeleteEnchantment(AppliedEnchantment enchantment)
    {
        Enchantments.Remove(enchantment);
        CurrentStatusEffects.RemoveAll(x => enchantment.Enchantment.StatusEffects.Contains(x));
        UpdateEnchantments();
    }

    /// <summary>
    /// 
    /// Root the unit so it cannot move until end of owners turn
    /// 
    /// </summary>
    public void RootUnit()
    {
        //Creates a root enchantment for the unit
        var enchantment = new UnitEnchantment()
        {
            Status = UnitEnchantment.EnchantmentStatus.EndOfOwnersTurn,
            Source = "Root",
            StatusEffects = new List<StatusEffects>() { StatusEffects.Rooted }
        };
        AddEnchantment(enchantment);
    }

    /// <summary>
    /// 
    /// Stun the unit so it cannot move or take actions until end of owners turn
    /// 
    /// </summary>
    public void StunUnit()
    {
        //Create a stun enchantment for the unit
        var enchantment = new UnitEnchantment()
        {
            Status = UnitEnchantment.EnchantmentStatus.EndOfOwnersTurn,
            Source = "Stun",
            StatusEffects = new List<StatusEffects>() { StatusEffects.Stunned }
        };
        AddEnchantment(enchantment);
    }

    /// <summary>
    /// 
    /// Sets a unit to be immune so they cannot take damage
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// Sets a unit to be indestructible so they cannot take damage or be destroyed
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// Checks if the unit is warded
    /// 
    /// </summary>
    public bool CheckWarden()
    {
        //Removes Warded from the unit in case it is not currently warded due to map changes
        if (CurrentStatusEffects.Contains(StatusEffects.Warded))
        {
            CurrentStatusEffects.Remove(StatusEffects.Warded);
            UnitCounter.RefreshUnitCounter();
        }

        //The unit cannot be warded if they have stalker or if the current terrain is surveyed
        if (!HasKeyword(Keywords.Stalker) && !UnitCounter.Cell.IsSurveyed(Owner.Id))
        {
            //Loops through each adjacent cell and checks if there is a unit occupying them
            foreach (var adjCell in UnitCounter.Cell.adjCells)
            {
                if (adjCell.occupantCounter != null)
                {
                    //Gets the adjacent unit
                    var adjUnit = adjCell.occupantCounter.Unit;
                    //Can only be warded by units under the opponents control
                    if (adjUnit.Owner.Id != Owner.Id)
                    {
                        //Checks if the adjacent unit has Warden
                        if (adjUnit.HasKeyword(Keywords.Warden))
                        {
                            //Warden units do not take effect if they are stunned
                            if (!adjUnit.HasStatusEffect(StatusEffects.Stunned))
                            {
                                //Checks if the units have matching keywords, as ethereal units avoid warden from non-ethereal units, and the same with flying
                                if (CheckWardenMatchingKeywords(adjUnit, Keywords.Ethereal) && CheckWardenMatchingKeywords(adjUnit, Keywords.Flying))
                                {
                                    //If all above conditions are met, unit is warded and need to refresh the counter
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

    /// <summary>
    /// 
    /// Check if a unit has matching keyword for the purposes of Warden matching
    /// 
    /// </summary>
    private bool CheckWardenMatchingKeywords(Unit adjUnit, Keywords keyword)
    {
        return !HasKeyword(keyword) || HasKeyword(keyword) && adjUnit.HasKeyword(keyword);
    }

    /// <summary>
    /// 
    /// Move a unit between being airborne or not
    /// 
    /// </summary>
    public void FlyOrLand()
    {
        if (HasKeyword(Keywords.Flying))
        {
            //Lands the unit if it is already airborne
            if (HasStatusEffect(StatusEffects.Airborne))
            {
                //Check if the unit is able to land in its current tile
                if (CheckOccupancy(UnitCounter.Cell, true, true))
                {
                    CanFlyOrLand = false;
                    CurrentStatusEffects.Remove(StatusEffects.Airborne);
                }
            }
            //Puts the unit airborne if it is already landed
            else
            {
                CanFlyOrLand = false;
                CurrentStatusEffects.Add(StatusEffects.Airborne);
            }

            RefreshCounter();
        }
        else
        {
            throw new Exception("Cannot fly or land a non-flying unit");
        }
    }

    /// <summary>
    /// 
    /// Removes stealth status from the unit
    /// 
    /// </summary>
    public void Unstealth()
    {
        if (HasStatusEffect(StatusEffects.Stealthed))
            CurrentStatusEffects.Remove(StatusEffects.Stealthed);

        RefreshCounter();
    }

    /// <summary>
    /// 
    /// Spellbind a unit to remove all enchantments and text
    /// 
    /// </summary>
    public void Spellbind()
    {
        //If a transformed unit is spellbound, return it to its original form and spellbind the original form
        if (HasStatusEffect(StatusEffects.Transformed))
        {
            ReturnToOriginalForm();
            OriginalTransformForm.Spellbind();
        }
        else
        {
            //If a summon unit is spellbound, it is destroyed
            if (HasKeyword(Keywords.Summon))
            {
                RemoveUnit(true);
            }
            else
            {
                //Loops through each enchantment except for passive enchantments (as these cannot be spellbound) and sets it to inactive
                foreach (var enchantment in Enchantments)
                    if (enchantment.Enchantment.Status != UnitEnchantment.EnchantmentStatus.Passive
                        && enchantment.Enchantment.Status != UnitEnchantment.EnchantmentStatus.OverloadPassive)
                        enchantment.IsActive = false;

                //Updates the owner stats to remove empowered/summon properties
                UpdateOwnerStats(false);
                //Clear imprison and confiscate cards, as these cannot be returned after spellbound
                ConfiscatedCards.Clear();
                ImprisonedUnits.Clear();
                //Clear any status effects and adds the spellbound status effect
                CurrentStatusEffects.Clear();
                CurrentStatusEffects.Add(StatusEffects.Spellbound);
                //Need to update enchantments after being spellbound
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

    /// <summary>
    /// 
    /// Switch the owner of the unit to a new owner
    /// 
    /// </summary>
    /// <param name="isTemporary">True or false if is temporary. If it is null, this means the unit is returning to its original owner</param>
    public void SwitchOwner(Player newOwner, bool? isTemporary = null)
    {
        //Sets the temporary mind control property. If null, makes the value false (as it is returning to its original owner)
        TemporaryMindControlled = isTemporary.HasValue ? isTemporary.Value : false;
        //Removes the unit from the original owner
        Owner.DeployedUnits.Remove(UnitCounter);
        UpdateOwnerStats(false);

        //Adds the unit to the new owner
        Owner = newOwner;
        Owner.DeployedUnits.Add(UnitCounter);
        UpdateOwnerStats();

        //Is temporary is null, that means it is returning to its original owner, so initialises the original resource cost
        if (isTemporary == null)
        {
            ResourceConvertedTo = null;
            ResourceInit();
        }
        //If taking control of the unit, converts the resource to the new owners dominant resource
        else
        {
            ResourceConvert(Classes.GetClassData(newOwner.PlayerClass).GetResourceOfType(ClassResourceType.ResourceTypes.Dominant));
        }

        //Removes the overload passive enchantment if it exists
        Enchantments.RemoveAll(x => x.Enchantment.Status == UnitEnchantment.EnchantmentStatus.OverloadPassive);
        //If the new owner is a mana class, adds a new overload enchantment. Updates enchantments in both cases
        if (Owner.UsedResources.Contains(CardResources.Mana))
            ModifyOverloadEnchantment();
        else
            UpdateEnchantments();

        //If the new owner is the active player, updates the status accordingly
        if (newOwner.IsActivePlayer)
        {
            //If the mind control is temporary or the unit is prepared, refreshes their action. Otherwise is preparing
            if (isTemporary.HasValue && isTemporary.Value || HasKeyword(Keywords.Prepared))
            {
                RefreshActions();
            }
            else
            {
                Status = UnitStatuses.Preparing;
            }
        }
        //If the new owner is the inactive player, sets the status to enemy
        else
        {
            Status = UnitStatuses.Enemy;
        }

        //Refresh the counter and checks the warden status as the owner of units changes
        RefreshCounter();
        GameManager.instance.CheckWarden();
    }

    /// <summary>
    /// 
    /// Triggers a madness effect, where a unit attacks a random adjacent unit
    /// 
    /// </summary>
    public void TriggerMadness()
    {
        //Gets the adjacent units. If there are none, does not continue with the madness trigger
        var adjacentUnits = UnitCounter.Cell.adjCells.Where(x => x.occupantCounter != null).Select(x => x.occupantCounter.Unit).ToList();

        if (adjacentUnits.Any())
        {
            //Randomly selects an adjacent unit to attack
            var randUnit = UnityEngine.Random.Range(0, adjacentUnits.Count());
            TriggerAttack(adjacentUnits[randUnit], false, true);
            //If the unit is able to use its action, reduce its action for the attack. Otherwise it loses its next action
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

    /// <summary>
    /// 
    /// Returns the deployed unit to the players hand
    /// 
    /// </summary>
    public void ReturnToHand()
    {
        //Can only return a deployed unit to hand
        if (IsDeployed)
        {
            //If a transformed unit is returned to hand, they are instead returned to original form, then returns the original form to hand instead
            if (HasStatusEffect(StatusEffects.Transformed))
            {
                ReturnToOriginalForm();
                OriginalTransformForm.ReturnToHand();
            }
            //Token units cannot be returned to hand, so are destroyed instead
            else if (HasKeyword(Keywords.Token))
            {
                RemoveUnit(true);
            }
            else
            {
                //Hero's cannot be returned to hand, so are redeployed instead
                if (IsHero)
                {
                    Redeploy();
                }
                else
                {
                    //If normal unit and returning to hand, removes the counter, resets the card and adds the unit to owners hand
                    RemoveUnit();
                    InitCard(CardData, Owner);
                    Owner.AddToHand(this);
                }
            }
        }
        else
        {
            throw new Exception("Cannot return a non-deployed unit to the owners hand");
        }
    }

    /// <summary>
    /// 
    /// Redeploys the unit
    /// 
    /// </summary>
    public void Redeploy()
    {
        //Removes the unit and adds it to the owners redeploy list
        RemoveUnit();
        Owner.AddToRedeploy(this);
    }

    /// <summary>
    /// 
    /// Modifies the overload enchantment
    /// 
    /// </summary>
    public void ModifyOverloadEnchantment(PlayerMana manaResource = null)
    {
        string overloadSourceString = "Overload Reduction";

        //Can only add overload enchantments to mana player classes
        if (Owner.UsedResources.Contains(CardResources.Mana))
        {
            //If not provided the mana resource, finds it from the owner
            if (manaResource == null)
                manaResource = (PlayerMana)Owner.Resources.Single(x => x.ResourceType == CardResources.Mana);

            //Gets the overload enchantment
            var overloadEnchantment = Enchantments.Select(x => x.Enchantment).SingleOrDefault(x => x.Status == UnitEnchantment.EnchantmentStatus.OverloadPassive);
            var isNew = false;
            //If the enchantment does not exist creates a new enchantment
            if (overloadEnchantment == null)
            {
                overloadEnchantment = new UnitEnchantment() { Status = UnitEnchantment.EnchantmentStatus.OverloadPassive, Source = overloadSourceString };
                isNew = true;
            }

            //Adds the stat modifier to be total overload (the value does not actually do anything, just is a placeholder, actual value is determined in update enchantments)
            overloadEnchantment.AddStatModifier(StatTypes.Attack, StatModifierTypes.Modify, manaResource.TotalOverload);

            //If is a new enchantment, adds the enchantment. Otherwise updates enchantments
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

    /// <summary>
    /// 
    /// Captures a card with this unit
    /// 
    /// </summary>
    public void CaptureCard(Card confiscatedCard = null, Unit imprisonedUnit = null)
    {
        //Cannot be given no capture
        if (confiscatedCard == null && imprisonedUnit == null)
            throw new Exception("Cannot capture no cards");
        if (confiscatedCard != null && imprisonedUnit != null)
            throw new Exception("Cannot confiscate and imprison at the same time");

        //Adds a confiscate card, removing the card from the opponents hand
        if (confiscatedCard != null)
        {
            ConfiscatedCards.Add(confiscatedCard);
            confiscatedCard.Owner.Hand.RemoveCard(confiscatedCard);
        }

        //Adds an imprison card, removing the unit from the field
        if (imprisonedUnit != null)
        {
            ImprisonedUnits.Add(imprisonedUnit);
            imprisonedUnit.RemoveUnit();
        }
    }

    /// <summary>
    /// 
    /// Return any capture cards on the unit
    /// 
    /// </summary>
    public void ReturnCaptureCards()
    {
        //Returns each confiscate card to the enemy hand
        foreach (var card in ConfiscatedCards)
            card.Owner.AddToHand(card);
        //Redeploys each imprison card
        foreach (var unit in ImprisonedUnits)
            unit.Owner.AddToRedeploy(unit);
        
        //Clears the confiscate and imprison list
        ConfiscatedCards.Clear();
        ImprisonedUnits.Clear();
    }
}
