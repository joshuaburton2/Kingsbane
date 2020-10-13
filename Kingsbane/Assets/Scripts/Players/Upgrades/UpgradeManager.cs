using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    private UpgradeLibrary upgradeLibrary;

    private void Awake()
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
}
