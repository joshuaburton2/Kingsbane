using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManaUI : ResourceDetailUI
{
    //Converts the player resource to mana
    private PlayerMana ResourceMana { get { return (PlayerMana)playerResource; } }

    [SerializeField]
    private TMP_InputField manaInput;
    [SerializeField]
    private TextMeshProUGUI empoweredText;
    [SerializeField]
    private TextMeshProUGUI summonText;

    [Header("Extra Properties Area")]
    [SerializeField]
    private GameObject extraPropertyArea;
    [SerializeField]
    private TextMeshProUGUI extraEmpoweredText;
    [SerializeField]
    private TextMeshProUGUI extraSummonText;

    private new void Update()
    {
        base.Update();

        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            if (GameManager.instance.effectManager.IsUILocked && extraPropertyArea.activeSelf)
                extraPropertyArea.SetActive(false);
    }

    /// <summary>
    /// 
    /// Refreshes the resource details
    /// 
    /// </summary>
    public override void RefreshResourceDetailUI()
    {
        base.RefreshResourceDetailUI();

        propertyText.text = $"Overload: {ResourceMana.TotalOverload}";
        manaInput.text = "";

        UpdateExtraPropertyText();
        extraPropertyArea.SetActive(false);
    }

    /// <summary>
    /// 
    /// Button click event for increasing mana
    /// 
    /// </summary>
    public void ManaButton()
    {
        if (int.TryParse(manaInput.text, out int manaVal))
            ResourceMana.ModifyValue(manaVal);

        playerBar.RefreshPlayerBar();
    }

    private void UpdateExtraPropertyText()
    {
        var empoweredString = $"Empowered: +{ResourceMana.CurrentEmpowered}";
        empoweredText.text = empoweredString;
        extraEmpoweredText.text = empoweredString;

        var summonString = $"Summon: {ResourceMana.CurrentSummons}/{ResourceMana.SummonCapcity}";
        summonText.text = summonString;
        extraSummonText.text = summonString;
    }

    public void OpenExtraPropertyArea()
    {
        extraPropertyArea.SetActive(!extraPropertyArea.activeSelf);
    }

    public void IncreaseEmpowered()
    {
        ResourceMana.ModifyEmpowered(1);
        UpdateExtraPropertyText();
    }

    public void DecreaseEmpowered()
    {
        ResourceMana.ModifyEmpowered(-1);
        UpdateExtraPropertyText();
    }

    public void IncreaseSummons()
    {
        ResourceMana.ModifyCurrentSummons(1);
        UpdateExtraPropertyText();
    }

    public void DecreaseSummons()
    {
        ResourceMana.ModifyCurrentSummons(-1);
        UpdateExtraPropertyText();
    }

    public void IncreaseSummonCapacity()
    {
        ResourceMana.ModifySummonCapacity(1);
        UpdateExtraPropertyText();
    }
}
