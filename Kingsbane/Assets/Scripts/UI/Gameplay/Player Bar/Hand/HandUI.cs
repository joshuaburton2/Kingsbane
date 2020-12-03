using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandUI : MonoBehaviour
{
    [SerializeField]
    private GameObject handList;
    [SerializeField]
    private GameObject handContainerPrefab;
    [SerializeField]
    private float scalingFactor;

    private List<HandContainer> containerList;

    public void DisplayCardList(List<Card> cardList)
    {

    }

    public void DisplayUpgradeList(List<UpgradeData> upgradeList)
    {
        containerList = new List<HandContainer>();
        GameManager.DestroyAllChildren(handList);

        int index = 0;
        foreach (var upgrade in upgradeList)
        {
            var upgradeContainer = Instantiate(handContainerPrefab, handList.transform);
            upgradeContainer.name = $"Container- {upgrade.Name}";
            var handContainer = upgradeContainer.GetComponentInChildren<HandContainer>();
            containerList.Add(handContainer);
            var upgradeName = $"Name- {upgrade.Name}";
            handContainer.InitHandContainer(this, index, upgradeData: upgrade, containerName: upgradeName, scalingFactor: scalingFactor);

            index++;
        }
    }

    public void SelectDisplay(int selectedIndex)
    {
        foreach (var container in containerList)
        {
            if (selectedIndex != container.handIndex)
            {
                container.SelectDisplay(false);
            }
        }
    }
}
