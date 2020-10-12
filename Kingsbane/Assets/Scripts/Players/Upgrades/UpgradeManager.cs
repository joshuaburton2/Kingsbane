using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private UpgradeLibrary upgradeLibrary;

    private void Awake()
    {
        upgradeLibrary = new UpgradeLibrary();
        upgradeLibrary.InitUpgradeList();
    }
}
