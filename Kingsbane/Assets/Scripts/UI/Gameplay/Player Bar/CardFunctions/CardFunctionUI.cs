using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardFunctionUI : MonoBehaviour
{
    private Player Player { get; set; }
    public PlayerUIBar PlayerUIBar { get; set; }

    [Header("Tutor Draw Main Area")]
    private CardListFilter tutorDrawFilter;
    [SerializeField]
    private GameObject tutorDrawArea;
    [SerializeField]
    private TMP_InputField nameInput;
    [SerializeField]
    private TMP_Dropdown rarityDropdown;
    [SerializeField]
    private TMP_Dropdown classDropdown;
    [SerializeField]
    private TMP_Dropdown tagDropdown;
    [SerializeField]
    private TMP_Dropdown resourceDropdown;
    [SerializeField]
    private Toggle isCreatedToggle;
    [SerializeField]
    private TMP_Dropdown costFilterDropdown;
    [SerializeField]
    private TMP_InputField costInput;
    [SerializeField]
    private TMP_Dropdown typeDropdown;

    [Header("Unit Fields")]
    [SerializeField]
    private GameObject unitFieldArea;
    [SerializeField]
    private TMP_Dropdown attackFilterDropdown;
    [SerializeField]
    private TMP_InputField attackInput;
    [SerializeField]
    private TMP_Dropdown healthFilterDropdown;
    [SerializeField]
    private TMP_InputField healthInput;
    [SerializeField]
    private TMP_Dropdown rangeFilterDropdown;
    [SerializeField]
    private TMP_InputField rangeInput;
    [SerializeField]
    private TMP_Dropdown speedFilterDropdown;
    [SerializeField]
    private TMP_InputField speedInput;

    [Header("Spell Fields")]
    [SerializeField]
    private GameObject spellFieldArea;
    [SerializeField]
    private TMP_Dropdown spellRangeFilterDropdown;
    [SerializeField]
    private TMP_InputField spellRangeInput;

    [Header("Item Fields")]
    [SerializeField]
    private GameObject itemFieldArea;
    [SerializeField]
    private TMP_Dropdown durabilityFilterDropdown;
    [SerializeField]
    private TMP_InputField durabilityRangeInput;

    [SerializeField]
    private CanvasGroup buttonGroup;

    private void Update()
    {
        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            buttonGroup.interactable = !GameManager.instance.effectManager.IsUILocked;
    }

    public void InitCardFunctionUI(Player player, PlayerUIBar playerUIBar)
    {
        Player = player;
        PlayerUIBar = playerUIBar;

        buttonGroup.interactable = false;

        tutorDrawArea.SetActive(false);
    }

    public void Draw()
    {
        Player.Draw();
        PlayerUIBar.RefreshPlayerBar();
    }

    public void OpenTutorDrawArea()
    {
        tutorDrawArea.SetActive(!tutorDrawArea.activeSelf);

        if (tutorDrawArea.activeSelf)
        {
            tutorDrawFilter = new CardListFilter();
        }
    }
}
