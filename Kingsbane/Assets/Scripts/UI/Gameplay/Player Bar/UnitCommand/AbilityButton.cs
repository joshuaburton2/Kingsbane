using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    private AbilityData ability;

    [SerializeField]
    private GameObject abilityTextArea;
    [SerializeField]
    private TextMeshProUGUI abilityText;
    [SerializeField]
    private TextMeshProUGUI buttonText;
    [SerializeField]
    private Button useButton;

    public void InitAbilityButton(AbilityData _ability, bool abilityTextAbove, bool canUseAbility)
    {
        ability = _ability;

        buttonText.text = ability.Name;

        abilityText.text = ability.AbilityText(false);
        useButton.interactable = canUseAbility;

        var directionMod = abilityTextAbove ? 1 : -1;
        abilityTextArea.transform.localPosition = new Vector3(abilityTextArea.transform.localPosition.x, abilityTextArea.transform.localPosition.y * directionMod);
        HideAbilityText();
    }

    public void SelectAbility()
    {
        abilityTextArea.SetActive(!abilityTextArea.activeSelf);
    }

    public void UseAbility()
    {
        GameManager.instance.effectManager.SetUnitAbilityMode(ability);
    }

    public void HideAbilityText()
    {
        abilityTextArea.SetActive(false);
    }
}
