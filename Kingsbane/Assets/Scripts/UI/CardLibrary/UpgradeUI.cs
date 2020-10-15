using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField]
    GameObject availableUpgradesArea;
    [SerializeField]
    GameObject upgradesToAddArea;
    [SerializeField]
    DeckListUI deckListUI;

    [Header("Object Prefabs")]
    [SerializeField]
    GameObject upgradeListObject;

    public void InitUpgradeUI()
    {
        GameManager.DestroyAllChildren(upgradesToAddArea.transform);
        GameManager.DestroyAllChildren(availableUpgradesArea.transform);

        var selectedDeck = GameManager.instance.deckManager.GetPlayerDeck(deckListUI.DeckEditId.Value);
        var availableUpgrades = GameManager.instance.upgradeManager.GetAvailableUpgrades(selectedDeck);

        foreach (var upgrade in availableUpgrades)
        {
            var newUpgradeObject = Instantiate(upgradeListObject, availableUpgradesArea.transform);
            newUpgradeObject.GetComponent<UpgradeListObject>().InitUpgradeListObject(upgrade, this);

            newUpgradeObject.name = $"Upgrade: {upgrade.Name}";
        }
    }
}
