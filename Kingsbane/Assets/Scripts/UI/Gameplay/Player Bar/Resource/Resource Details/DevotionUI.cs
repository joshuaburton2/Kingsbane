using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DevotionUI : ResourceDetailUI
{
    //Converts the player resource to devotion
    private PlayerDevotion ResourceDevotion { get { return (PlayerDevotion)playerResource; } }

    [SerializeField]
    private TMP_InputField prayerInput;
    [SerializeField]
    private TMP_InputField lastingPrayerInput;
    [SerializeField]
    private TextMeshProUGUI prayerButtonText;

    /// <summary>
    /// 
    /// Refreshes the resource details
    /// 
    /// </summary>
    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        propertyText.text = $"Lasting Prayer: {ResourceDevotion.LastingPrayer}";
        prayerInput.text = "";
        lastingPrayerInput.text = "";
        prayerButtonText.text = $"Prayer (+{ResourceDevotion.PrayerModifier})";
    }

    /// <summary>
    /// 
    /// Button click event for triggering prayer effects
    /// 
    /// </summary>
    public void PrayerButton()
    {
        if(int.TryParse(prayerInput.text, out int prayerVal))
            ResourceDevotion.TriggerPrayer(prayerVal);

        RefreshResourceDetailUI();
    }

    /// <summary>
    /// 
    /// Button click event for setting the lasting prayer
    /// 
    /// </summary>
    public void LastingPrayerButton()
    {
        if (int.TryParse(lastingPrayerInput.text, out int lastingPrayerVal))
            ResourceDevotion.SetLastingPrayer(lastingPrayerVal);

        RefreshResourceDetailUI();
    }
}
