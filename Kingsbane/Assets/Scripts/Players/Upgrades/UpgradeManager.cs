using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using CategoryEnums;
using System;

public class UpgradeManager : MonoBehaviour
{
    private UpgradeLibrary upgradeLibrary;

    private const float defaultUpgradeScaling = 0.37f;

    [Header("Upgrade Prefabs")]
    [SerializeField]
    GameObject upgradeObject;

    /// <summary>
    /// 
    /// Loading upgrade library- to be called on initialisation of game
    /// 
    /// </summary>
    public void LoadLibrary()
    {
        upgradeLibrary = new UpgradeLibrary();
        upgradeLibrary.InitUpgradeList();
    }

    /// <summary>
    /// 
    /// Gets an upgrade of a particular ID value
    /// 
    /// </summary>
    public UpgradeData GetUpgrade(int id)
    {
        return upgradeLibrary.UpgradeList.FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// 
    /// Creates an upgrade card on a canvas
    /// 
    /// </summary>
    public GameObject CreateUpgrade(UpgradeData upgrade, Transform parent, DeckData currentDeck = null, float scaling = defaultUpgradeScaling)
    {
        var createdUpgrade = Instantiate(upgradeObject, parent);
        createdUpgrade.transform.localScale = new Vector3(scaling, scaling, 1.0f);
        createdUpgrade.GetComponent<UpgradeDisplay>().InitDisplay(upgrade, currentDeck);
        return createdUpgrade;
    }

    /// <summary>
    /// 
    /// Gets an upgrade tier of a particular tag (either hero or ability upgrades)
    /// 
    /// </summary>
    public UpgradeData GetUpgrade(UpgradeTags upgradeTag, TierLevel tierLevel)
    {
        //Only hero and ability upgrades are valid to be selected using this method
        if (upgradeTag == UpgradeTags.HeroUpgrade || upgradeTag == UpgradeTags.AbilityUpgrade)
        {
            //Tier 0 and default doesn't have a valid upgrade
            if (tierLevel != TierLevel.Tier0 || tierLevel != TierLevel.Default)
            {
                //Gets the valid tag
                var validUpdgrades = upgradeLibrary.UpgradeList.Where(x => x.UpgradeTag == upgradeTag);
                return validUpdgrades.FirstOrDefault(x => x.TierLevel == tierLevel);
            }
            else
            {
                throw new Exception("Not a valid tier level");
            }
        }
        else
        {
            throw new Exception("Not a valid upgrade tag");
        }
    }

    /// <summary>
    /// 
    /// Gets the list of all the upgrades available to be purchased by a particular class (ignoring honour points)
    /// 
    /// </summary>
    public List<UpgradeData> GetAvailableUpgrades(DeckData deck)
    {
        var availableUpgrades = new List<UpgradeData>();

        //Loops through each upgrade and checks how many of the required conditions it meets for the deck
        foreach (var upgrade in upgradeLibrary.UpgradeList)
        {
            //If the deck already has the upgrade, it cannot be added again
            if (deck.UpgradeList.Select(x => x.Id).Contains(upgrade.Id))
            {
                //If the upgrade is not repeatable and in the deck already, it cannot be added again
                if (!upgrade.IsRepeatable)
                {
                    continue;
                }
            }

            //numMetConditions tracks how many active conditions the upgrade has met
            var numMetConditions = 0;
            //numActiveConditions tracks how many conditions are required to be checked on the upgrade
            var numActiveConditions = 0;

            if (upgrade.ResourcePrerequisites.Count != 0)
            {
                numActiveConditions++;
                //If the deck utilises any of the required resources, then it meets the resource prerequisite (the deck is not required to meet all resource prerequisites)
                if (upgrade.ResourcePrerequisites.Intersect(deck.DeckResources).Any())
                {
                    numMetConditions++;
                }
            }

            if (upgrade.ClassPrerequisites.Count != 0)
            {
                numActiveConditions++;
                //If the deck's class is in the class prerequisite list for the upgrade, then it meets the class condition
                if (upgrade.ClassPrerequisites.Contains(deck.DeckClass))
                {
                    numMetConditions++;
                }
            }

            if (upgrade.UpgradePrerequisites.Count != 0)
            {
                numActiveConditions++;
                //If the upgrades the deck already has are all in the upgrade prerequisites for the upgrade, then the count of the intersection will equal 
                //the count of the upgrade prerequisite list. This is because any of the upgrades in the upgrade prerequisites will be removed in the intersection
                //if they are not in the deck
                if (upgrade.UpgradePrerequisites.Intersect(deck.UpgradeList).Count() == upgrade.UpgradePrerequisites.Count())
                {
                    numMetConditions++;
                }
            }

            //Filters out repeatable resource upgrades which cannot be purchased due to restrictions
            if (upgrade.UpgradeTag == UpgradeTags.StimulateLearning)
            {
                if (deck.PlayerResources.Select(x => x.ResourceType).Contains(CardResources.Knowledge))
                {
                    numActiveConditions++;
                    var playerKnowledge = (PlayerKnowledge)deck.PlayerResources.FirstOrDefault(x => x.ResourceType == CardResources.Knowledge);
                    if (playerKnowledge.Stagnation != 0)
                    {
                        numMetConditions++;
                    }
                }
            }
            if (upgrade.UpgradeTag == UpgradeTags.RestorePower)
            {
                if (deck.PlayerResources.Select(x => x.ResourceType).Contains(CardResources.Mana))
                {
                    numActiveConditions++;
                    var playerMana = (PlayerMana)deck.PlayerResources.FirstOrDefault(x => x.ResourceType == CardResources.Mana);
                    if (playerMana.CurrentOverload != 0)
                    {
                        numMetConditions++;
                    }
                }
            }

            //If all conditions are met by the upgrade
            if (numMetConditions == numActiveConditions)
            {
                availableUpgrades.Add(upgrade);
            }
        }

        return availableUpgrades;
    }

    /// <summary>
    /// 
    /// Updates a deck with the effects of the given upgrade- may require a rework, don't like the switch statement
    /// 
    /// </summary>
    public void UpdateUpgradeEffect(UpgradeData upgrade, DeckData deckData)
    {
        PlayerResource playerResource;

        switch (upgrade.UpgradeTag)
        {
            case UpgradeTags.HeroUpgrade:
                var newHeroTier = upgrade.TierLevel;

                if (deckData.HeroTier < newHeroTier)
                {
                    deckData.HeroTier = newHeroTier;
                    deckData.HeroCard = GameManager.instance.libraryManager.GetHero(deckData.DeckClass, newHeroTier, deckData.AbilityTier);
                }
                break;
            case UpgradeTags.AbilityUpgrade:
                var newAbilityTier = upgrade.TierLevel;

                if (deckData.AbilityTier < newAbilityTier)
                {
                    deckData.AbilityTier = newAbilityTier;
                    deckData.HeroCard = GameManager.instance.libraryManager.GetHero(deckData.DeckClass, deckData.HeroTier, newAbilityTier);
                }
                break;
            case UpgradeTags.ClaimBounty:
                playerResource = deckData.GetPlayerResource(CardResources.Gold);
                if (playerResource.TierLevel < upgrade.TierLevel)
                {
                    playerResource.SetTierLevel(upgrade.TierLevel);
                }
                break;
            case UpgradeTags.DevotedFollowers:
                playerResource = deckData.GetPlayerResource(CardResources.Devotion);
                if (playerResource.TierLevel < upgrade.TierLevel)
                {
                    playerResource.SetTierLevel(upgrade.TierLevel);
                }
                break;
            case UpgradeTags.ManaReserves:
                playerResource = deckData.GetPlayerResource(CardResources.Mana);
                if (playerResource.TierLevel < upgrade.TierLevel)
                {
                    playerResource.SetTierLevel(upgrade.TierLevel);
                }
                break;
            case UpgradeTags.StrengthofArms:
                playerResource = deckData.GetPlayerResource(CardResources.Energy);
                if (playerResource.TierLevel < upgrade.TierLevel)
                {
                    playerResource.SetTierLevel(upgrade.TierLevel);
                }
                break;
            case UpgradeTags.WellofKnowledge:
                playerResource = deckData.GetPlayerResource(CardResources.Knowledge);
                if (playerResource.TierLevel < upgrade.TierLevel)
                {
                    playerResource.SetTierLevel(upgrade.TierLevel);
                }
                break;
            case UpgradeTags.WildGrowth:
                playerResource = deckData.GetPlayerResource(CardResources.Wild);
                if (playerResource.TierLevel < upgrade.TierLevel)
                {
                    playerResource.SetTierLevel(upgrade.TierLevel);
                }
                break;
            case UpgradeTags.LastingPrayers:
                playerResource = deckData.GetPlayerResource(CardResources.Devotion);
                ((PlayerDevotion)playerResource).IncreaseLastingPrayer();
                break;
            case UpgradeTags.BattleSurges:
                playerResource = deckData.GetPlayerResource(CardResources.Energy);
                ((PlayerEnergy)playerResource).AddSurges();
                break;
            case UpgradeTags.EmergencyReserves:
                playerResource = deckData.GetPlayerResource(CardResources.Gold);
                ((PlayerGold)playerResource).UpgradeIncreaseGold();
                break;
            case UpgradeTags.StimulateLearning:
                playerResource = deckData.GetPlayerResource(CardResources.Knowledge);
                ((PlayerKnowledge)playerResource).ReduceIgnorance();
                break;
            case UpgradeTags.RestorePower:
                playerResource = deckData.GetPlayerResource(CardResources.Mana);
                ((PlayerMana)playerResource).ReduceOverload();
                break;
            case UpgradeTags.CycleofNature:
                playerResource = deckData.GetPlayerResource(CardResources.Wild);
                ((PlayerWild)playerResource).BaseCycleWild();
                break;
            default:
                break;
        }
    }
}
