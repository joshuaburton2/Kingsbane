using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraveyardExtensionEffect : EffectExtensionUI
{
    [Header("Card Selection Fields")]
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TMP_InputField nameInput;
    [SerializeField]
    private TMP_Dropdown tagDropdown;
    [SerializeField]
    private TMP_Dropdown typeDropdown;
    [SerializeField]
    private Toggle isDeployToggle;
    [SerializeField]
    private Toggle activeOwnerToggle;

    [Header("Required Fields")]
    [SerializeField]
    private TMP_InputField numToCreateInput;
    [SerializeField]
    private GameObject isCopyArea;
    [SerializeField]
    private Toggle isCopyToggle;
    [SerializeField]
    private GameObject createdByArea;
    [SerializeField]
    private TMP_InputField createdByInput;
    [SerializeField]
    private Toggle isChoiceToggle;

    private const string DEFAULT_DROPDOWN_STRING = "Any";
    private string defaultTitleText;

    public override void RefreshEffectExtension(EffectUI _effectUI)
    {
        base.RefreshEffectExtension(_effectUI);

        defaultTitleText = "Graveyard";

        ClearFields();
    }
    private void ClearFields()
    {
        GeneralUIExtensions.InitDropdownOfType(tagDropdown, new List<Tags> { Tags.Default }, DEFAULT_DROPDOWN_STRING, true);
        GeneralUIExtensions.InitDropdownOfType(typeDropdown, new List<CardTypes> { CardTypes.Default }, DEFAULT_DROPDOWN_STRING);

        nameInput.text = "";
        numToCreateInput.text = "";
        createdByInput.text = "";

        titleText.text = defaultTitleText;
        createdByInput.placeholder.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);

        activeOwnerToggle.isOn = true;
        isDeployToggle.isOn = false;
        isCopyToggle.isOn = false;
        isChoiceToggle.isOn = false;

        IsDeployToggleState();
    }

    public void ConfirmButton()
    {
        if (isDeployToggle.isOn || !isCopyToggle.isOn || isCopyToggle.isOn && !string.IsNullOrWhiteSpace(createdByInput.text))
        {
            var player = GameManager.instance.GetPlayer(activeOwnerToggle.isOn);

            var filter = new CardListFilter()
            {
                Name = nameInput.text,
            };

            if (tagDropdown.captionText.text != DEFAULT_DROPDOWN_STRING)
                filter.Tag = (Tags)Enum.Parse(typeof(Tags), tagDropdown.captionText.text.Replace(" ", ""));
            if (typeDropdown.captionText.text != DEFAULT_DROPDOWN_STRING)
                filter.CardType = (CardTypes)Enum.Parse(typeof(CardTypes), typeDropdown.captionText.text.Replace(" ", ""));

            int numberToCreate = 1;
            if (int.TryParse(numToCreateInput.text, out int result) || numToCreateInput.text != "0")
                numberToCreate = Mathf.Max(1, result);

            if (player.ReturnFromGraveyard(filter, numberToCreate, isDeployToggle.isOn, isCopyToggle.isOn, createdByInput.text, isChoiceToggle.isOn))
            {
                if (isDeployToggle.isOn)
                    StartEffect();

                if (!isChoiceToggle.isOn)
                    GameManager.instance.uiManager.RefreshUI();
            }
            else
                titleText.text = $"{defaultTitleText} (Failed)";
        }
        else
        {
            createdByInput.placeholder.color = new Color(0.8f, 0.0f, 0.0f, 0.5f);
            titleText.text = $"{defaultTitleText} (Input Created By)";
        }
    }

    public void IsDeployToggleState()
    {
        if (isDeployToggle.isOn)
        {
            typeDropdown.value = typeDropdown.options.IndexOf(typeDropdown.options.Single(x => x.text == CardTypes.Unit.ToString()));
            typeDropdown.interactable = false;

            isCopyArea.SetActive(false);
            createdByArea.SetActive(false);
            createdByInput.text = "";
            isCopyToggle.isOn = false;
        }
        else
        {
            typeDropdown.interactable = true;
            isCopyArea.SetActive(true);
            isCopyToggle.isOn = false;
            createdByArea.SetActive(true);
            createdByInput.text = "";
        }

        IsCopyToggleState();
    }

    public void IsCopyToggleState()
    {
        if (isCopyToggle.isOn)
        {
            createdByInput.interactable = true;
        }
        else
        {
            createdByInput.interactable = false;
            createdByInput.text = "";
        }
    }

    public void ResetButton()
    {
        ClearFields();
    }
}
