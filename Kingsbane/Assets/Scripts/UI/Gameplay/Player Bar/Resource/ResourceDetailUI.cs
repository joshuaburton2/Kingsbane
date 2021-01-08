using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDetailUI : MonoBehaviour
{
    protected PlayerResource playerResource;
    protected PlayerUIBar playerBar;

    [SerializeField]
    protected CanvasGroup buttonGroup;
    [SerializeField]
    protected Image resourceIcon;
    [SerializeField]
    protected TextMeshProUGUI resourceTitle;
    [SerializeField]
    protected TextMeshProUGUI valueText;
    [SerializeField]
    protected TextMeshProUGUI propertyText;

    private void Update()
    {
        //Checks whether the game is UI locked and disables the buttons if so
        if (GameManager.instance.CurrentGamePhase == GameManager.GamePhases.Gameplay)
            buttonGroup.interactable = !GameManager.instance.effectManager.isUILocked;
    }

    /// <summary>
    /// 
    /// Initialises the resource details wth the general functionality of the details
    /// 
    /// </summary>
    public void InitResourceDetailUI(PlayerResource _playerResource, PlayerUIBar _playerBar)
    {
        playerResource = _playerResource;
        playerBar = _playerBar;

        resourceIcon.sprite = GameManager.instance.iconManager.GetIcon(playerResource.ResourceType);
        resourceTitle.text = playerResource.ResourceType.ToString();

        buttonGroup.interactable = false;

        RefreshResourceDetailUI();
    }

    /// <summary>
    /// 
    /// Refreshes the resource details
    /// 
    /// </summary>
    public virtual void RefreshResourceDetailUI()
    {
        valueText.text = $"{playerResource.ResourceType}: {playerResource.Value}";
    }
}
