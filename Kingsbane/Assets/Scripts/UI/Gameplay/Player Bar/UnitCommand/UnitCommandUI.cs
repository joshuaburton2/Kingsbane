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
    [SerializeField]
    private GameObject moveButtonArea;
    [SerializeField]
    private TextMeshProUGUI speedText;
    [SerializeField]
    private Button moveButton;
    [SerializeField]
    private GameObject attackButtonArea;
    [SerializeField]
    private TextMeshProUGUI actionText;
    [SerializeField]
    private Button attackButton;
    [SerializeField]
    private GameObject abilityButtonArea;
    [SerializeField]
    private TextMeshProUGUI abilityText;

    private void Update()
    {
        //Checks whether the game is UI locked and disables the buttons if so
        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            buttonGroup.interactable = !GameManager.instance.effectManager.IsUILocked;
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
    }
}
