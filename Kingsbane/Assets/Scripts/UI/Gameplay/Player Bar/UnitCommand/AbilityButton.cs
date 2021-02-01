using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// Script for controlling a ability button on the unit command bar
/// 
/// </summary>
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

    /// <summary>
    /// 
    /// Initialises the button with a given ability
    /// 
    /// </summary>
    /// <param name="abilityTextAbove">If the text area needs to appear above the button or below</param>
    /// <param name="canUseAbility">Whether the player can use this particular ability or not</param>
    public void InitAbilityButton(AbilityData _ability, bool abilityTextAbove, bool canUseAbility)
    {
        ability = _ability;

        buttonText.text = ability.Name;

        abilityText.text = ability.AbilityText(false);
        useButton.interactable = canUseAbility;

        //Varies the position of the ability text based on whether it needs to be above or below
        var directionMod = abilityTextAbove ? 1 : -1;
        abilityTextArea.transform.localPosition = new Vector3(abilityTextArea.transform.localPosition.x, abilityTextArea.transform.localPosition.y * directionMod);
        abilityTextArea.SetActive(false);
    }

    /// <summary>
    /// 
    /// Button click event for selecting the ability
    /// 
    /// </summary>
    public void SelectAbility()
    {
        abilityTextArea.SetActive(!abilityTextArea.activeSelf);
    }

    /// <summary>
    /// 
    /// Button click event for using an ability
    /// 
    /// </summary>
    public void UseAbility()
    {
        GameManager.instance.effectManager.SetUnitAbilityMode(ability);
    }
}
