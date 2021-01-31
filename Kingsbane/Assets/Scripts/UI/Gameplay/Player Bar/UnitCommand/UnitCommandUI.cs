using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [Header("Speed Area")]
    [SerializeField]
    private GameObject speedArea;
    [SerializeField]
    private TMP_InputField speedInput;
    [SerializeField]
    private Button plusButton;
    [SerializeField]
    private Button minusButton;

    private int SetSpeed { get; set; }
    private bool ModifyingSpeed { get; set; }
    private const int LOWEST_SPEED = 1;

    private void Update()
    {
        //Checks whether the game is UI locked and disables the buttons if so
        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
        {
            buttonGroup.interactable = !GameManager.instance.effectManager.IsUILocked;

            if (GameManager.instance.effectManager.ActiveEffect == EffectManager.ActiveEffectTypes.UnitUseSpeed && !ModifyingSpeed)
            {
                ModifyingSpeed = true;
                speedArea.SetActive(true);
                unit.RemainingSpeed.ToString();
                SetSpeed = LOWEST_SPEED;
                CheckSpeedButtons();
            }
            else if (GameManager.instance.effectManager.ActiveEffect != EffectManager.ActiveEffectTypes.UnitUseSpeed)
            {
                ModifyingSpeed = false;
                speedArea.SetActive(false);
            }
        }
        else
            buttonGroup.interactable = false;
    }

    public void SetCommandUnit(Unit _unit)
    {
        unit = _unit;

        nameText.text = unit.Name;
        moveButtonArea.SetActive(unit.Owner.IsActivePlayer);
        attackButtonArea.SetActive(unit.Owner.IsActivePlayer);
        abilityButtonArea.SetActive(unit.Owner.IsActivePlayer);

        RefreshCommandBar();
    }

    public void RefreshCommandBar()
    {
        speedText.text = $"Speed: {unit.RemainingSpeed}/{unit.Speed}";
        actionText.text = $"Action: {unit.ActionsLeft}";
        abilityText.text = $"Ability: {unit.AbilityUsesLeft}";

        moveButton.interactable = unit.RemainingSpeed > 0;
        speedArea.SetActive(false);
    }

    public void MoveCommandUnit()
    {
        var currentCell = unit.UnitCounter.Cell.gridIndex;

        GameManager.instance.effectManager.SetMoveUnitMode(unit.UnitCounter.Cell);
    }

    private void CheckSpeedButtons()
    {
        speedInput.text = SetSpeed.ToString();
        minusButton.interactable = SetSpeed != LOWEST_SPEED;
        plusButton.interactable = SetSpeed != unit.RemainingSpeed;
    }

    public void IncreaseSpeedUse()
    {
        SetSpeed++;
        
        CheckSpeedButtons();
    }

    public void DecreaseSpeedUse()
    {
        SetSpeed--;
        CheckSpeedButtons();
    }

    public void ConfirmSpeedUse()
    {
        ModifyingSpeed = false;
        unit.UseSpeed(SetSpeed);
        RefreshCommandBar();
    }

    public void ForceMoveCommandUnit()
    {
        GameManager.instance.effectManager.SetForceMoveUnitMode();
    }
}
