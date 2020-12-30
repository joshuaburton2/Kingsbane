using TMPro;
using UnityEngine;
using CategoryEnums;

public class UpgradeDetailUI : MonoBehaviour
{
    [SerializeField]
    GameObject upgradeParent;
    [SerializeField]
    GameObject heroUpgradeArea;
    [SerializeField]
    GameObject currentHeroParent;
    [SerializeField]
    GameObject newHeroParent;
    [SerializeField]
    TextMeshProUGUI tagText;
    [SerializeField]
    float upgradeScaling;

    /// <summary>
    /// 
    /// Initialise the Card Detail display
    /// 
    /// </summary>
    public void ShowUpgradeDetails(UpgradeData upgradeData, DeckData currentDeck)
    {
        //Reset all cards on the display
        GameManager.DestroyAllChildren(upgradeParent);
        GameManager.DestroyAllChildren(currentHeroParent);
        GameManager.DestroyAllChildren(newHeroParent);

        //Creates the main card on the display
        GameObject mainUpgrade = GameManager.instance.upgradeManager.CreateUpgrade(upgradeData, upgradeParent.transform, currentDeck, upgradeScaling);
        mainUpgrade.name = $"Main Upgrade- {upgradeData.Name}";

        tagText.text = $"Upgrade Tag: {upgradeData.UpgradeTag}";

        //Checks if the card is a hero modifier
        if ((upgradeData.UpgradeTag == UpgradeTags.AbilityUpgrade || upgradeData.UpgradeTag == UpgradeTags.HeroUpgrade)
            && currentDeck != null)
        {
            heroUpgradeArea.SetActive(true);

            TierLevel currentHeroTier = currentDeck.HeroTier;
            TierLevel currentAbilityTier = currentDeck.AbilityTier;

            TierLevel newHeroTier = currentHeroTier;
            TierLevel newAbilityTier = currentAbilityTier;

            //Gets the new hero tier levels for abilities or heroes
            if (upgradeData.UpgradeTag == UpgradeTags.AbilityUpgrade)
                newAbilityTier = upgradeData.TierLevel;
            else
                newHeroTier = upgradeData.TierLevel;

            //Gets the related hero card
            var currentHeroCard = GameManager.instance.libraryManager.GetHero(currentDeck.DeckClass, currentHeroTier, currentAbilityTier);
            CreateHeroCard(currentHeroCard, currentHeroParent.transform);
            var newHeroCard = GameManager.instance.libraryManager.GetHero(currentDeck.DeckClass, newHeroTier, newAbilityTier);
            CreateHeroCard(newHeroCard, newHeroParent.transform);
        }
        else
        {
            heroUpgradeArea.SetActive(false);
        }
    }

    private void CreateHeroCard(CardData heroCard, Transform parent)
    {
        ////Initialises a parent of the related card to handle scaling of the card display in the grid display object
        //GameObject heroCardParent = new GameObject($"Hero Card- {heroCard.Name}", typeof(RectTransform));
        //heroCardParent.transform.parent = parent;
        ////Unsure why this happens, but parent scales to a strange scaling. Following line resets this
        //heroCardParent.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        GameManager.instance.libraryManager.CreateCardObject(heroCard, parent);
    }

    /// <summary>
    /// 
    /// Button click event for closing the panel
    /// 
    /// </summary>
    public void CloseUpgradeDetail()
    {
        gameObject.SetActive(false);
    }
}
