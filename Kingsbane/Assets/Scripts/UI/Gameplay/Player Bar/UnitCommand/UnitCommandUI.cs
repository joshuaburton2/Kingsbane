using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 
/// Script for controlling the unit command bar on a player bar
/// 
/// </summary>
public class UnitCommandUI : MonoBehaviour
{
    Unit unit;

    [SerializeField]
    private CanvasGroup buttonGroup;
    [SerializeField]
    private TextMeshProUGUI nameText;
    [Header("Move Button Area")]
    [SerializeField]
    private GameObject moveButtonArea;
    [SerializeField]
    private TextMeshProUGUI speedText;
    [SerializeField]
    private Button moveButton;
    [Header("Attack Button Area")]
    [SerializeField]
    private GameObject attackButtonArea;
    [SerializeField]
    private TextMeshProUGUI actionText;
    [SerializeField]
    private Button attackButton;
    [Header("Ability Button Area")]
    [SerializeField]
    private GameObject abilityButtonArea;
    [SerializeField]
    private TextMeshProUGUI abilityText;
    [SerializeField]
    private bool abilityTextAbove; //True if the ability text is above the command bar. False otherwise
    [SerializeField]
    private GameObject abilityButtonPrefab;
    [SerializeField]
    private GameObject abilityButtonParent;

    private List<AbilityButton> abilityButtonObjects;

    [Header("Speed Area")]
    [SerializeField]
    private GameObject speedArea;
    [SerializeField]
    private TMP_InputField speedInput;
    [SerializeField]
    private Button plusButton;
    [SerializeField]
    private Button minusButton;

    [Header("Enchantment Area")]
    [SerializeField]
    private GameObject enchantmentArea;
    [SerializeField]
    private GameObject enchantmentObjectParent;
    [SerializeField]
    private GameObject enchantmentObjectPrefab;

    private int SetSpeed { get; set; }
    private bool ModifyingSpeed { get; set; }
    private const int LOWEST_SPEED = 1;

    private void Update()
    {
        //Checks whether the game is UI locked and disables the buttons if so
        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
        {
            buttonGroup.interactable = !GameManager.instance.effectManager.IsUILocked;

            //If in the using speed mode and havent already started modifying speed, shows the use speed panel. Otherwise hides it
            if (GameManager.instance.effectManager.ActiveEffect == EffectManager.ActiveEffectTypes.UnitUseSpeed && !ModifyingSpeed)
            {
                ModifyingSpeed = true;
                speedArea.SetActive(true);
                unit.RemainingSpeed.ToString();
                SetSpeed = LOWEST_SPEED;
                CheckSpeedButtons();
            }
            else if (GameManager.instance.effectManager.ActiveEffect != EffectManager.ActiveEffectTypes.UnitUseSpeed && speedArea.activeSelf)
            {
                ModifyingSpeed = false;
                speedArea.SetActive(false);
            }
        }
        else
            buttonGroup.interactable = false;
    }

    /// <summary>
    /// 
    /// Sets the unit which is being commanded and refreshes the UI
    /// 
    /// </summary>
    public void SetCommandUnit(Unit _unit)
    {
        unit = _unit;

        nameText.text = unit.Name;
        moveButtonArea.SetActive(unit.Owner.IsActivePlayer);
        attackButtonArea.SetActive(unit.Owner.IsActivePlayer);

        RefreshAbilities();

        RefreshCommandBar();
    }

    /// <summary>
    /// 
    /// Refreshes the UI Component
    /// 
    /// </summary>
    public void RefreshCommandBar()
    {
        speedText.text = $"Speed: {unit.RemainingSpeed}/{unit.GetStat(Unit.StatTypes.Speed)}";
        actionText.text = $"Action: {unit.ActionsLeft}";
        abilityText.text = $"Ability: {unit.AbilityUsesLeft}";
        RefreshAbilities();

        moveButton.interactable = unit.CanMove;
        attackButton.interactable = unit.CanAction;
        speedArea.SetActive(false);

        enchantmentArea.SetActive(unit.Enchantments.Count > 0);
        GameManager.DestroyAllChildren(enchantmentObjectParent);
        foreach (var enchantment in unit.Enchantments)
        {
            var enchantmentObject = Instantiate(enchantmentObjectPrefab, enchantmentObjectParent.transform);
            enchantmentObject.GetComponent<EnchantmentListObject>().InitEnchantmentObject(enchantment);
        }
    }

    /// <summary>
    /// 
    /// Refreshes the list of abilities with the ones the unit has
    /// 
    /// </summary>
    private void RefreshAbilities()
    {
        var hasAbilities = unit.Abilities.Count > 0;
        //Hides the button area if the unit has no abilities
        abilityButtonArea.SetActive(unit.Owner.IsActivePlayer && hasAbilities);
        if (hasAbilities)
        {
            abilityButtonObjects = new List<AbilityButton>();
            GameManager.DestroyAllChildren(abilityButtonParent);
            //Loops through each ability and creates a button for it
            foreach (var ability in unit.Abilities)
            {
                var abilityButtonObject = Instantiate(abilityButtonPrefab, abilityButtonParent.transform);

                var abilityButtonScript = abilityButtonObject.GetComponent<AbilityButton>();
                abilityButtonScript.InitAbilityButton(ability, abilityTextAbove, unit.CanUseAbility(ability));
                abilityButtonObjects.Add(abilityButtonScript);
            }
        }
    }

    /// <summary>
    /// 
    /// Sets the game into force unit move mode
    /// 
    /// </summary>
    public void ForceMoveCommandUnit()
    {
        GameManager.instance.effectManager.SetForceMoveUnitMode();
    }

    /// <summary>
    /// 
    /// Sets the game into move unit mode
    /// 
    /// </summary>
    public void MoveCommandUnit()
    {
        GameManager.instance.effectManager.SetMoveUnitMode(unit.UnitCounter.Cell);
    }

    /// <summary>
    /// 
    /// Checks if the speed buttons can be selected or not and sets the speed text
    /// 
    /// </summary>
    private void CheckSpeedButtons()
    {
        speedInput.text = SetSpeed.ToString();
        minusButton.interactable = SetSpeed != LOWEST_SPEED;
        plusButton.interactable = SetSpeed != unit.RemainingSpeed;
    }

    /// <summary>
    /// 
    /// Button click event for increasing speed use
    /// 
    /// </summary>
    public void IncreaseSpeedUse()
    {
        SetSpeed++;

        CheckSpeedButtons();
    }

    /// <summary>
    /// 
    /// Button click event for decreasing speed use
    /// 
    /// </summary>
    public void DecreaseSpeedUse()
    {
        SetSpeed--;
        CheckSpeedButtons();
    }

    /// <summary>
    /// 
    /// Button click event for using the given speed
    /// 
    /// </summary>
    public void ConfirmSpeedUse()
    {
        ModifyingSpeed = false;
        unit.UseSpeed(SetSpeed);
        RefreshCommandBar();
    }

    /// <summary>
    /// 
    /// Button click event for increasing the units number of actions
    /// 
    /// </summary>
    public void IncreaseActions()
    {
        unit.ModifyActions(1);
        RefreshCommandBar();
    }

    /// <summary>
    /// 
    /// Button click event for setting attack mode for the unit
    /// 
    /// </summary>
    public void UseAttack()
    {
        GameManager.instance.effectManager.SetAttackMode();
    }

    /// <summary>
    /// 
    /// Button click event for increasing the units number of ability uses
    /// 
    /// </summary>
    public void IncreaseAbilities()
    {
        unit.ModifyAbilities(1);
        RefreshCommandBar();
    }
}
