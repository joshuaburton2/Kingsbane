using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour
{
    [SerializeField]
    private GameObject handList;
    [SerializeField]
    private GameObject handContainerPrefab;

    public void DisplayCardList(List<Card> cardList)
    {

    }

    public void DisplayUpgradeList(List<UpgradeData> upgradeList)
    {
        GameManager.DestroyAllChildren(handList);

        foreach (var upgrade in upgradeList)
        {
            var upgradeContainer = Instantiate(handContainerPrefab, handList.transform);
            upgradeContainer.name = $"Container- {upgrade.Name}";
            var handContainer = upgradeContainer.GetComponentInChildren<HandContainer>();
            var upgradeName = $"Name- {upgrade.Name}";
        }
    }
}
