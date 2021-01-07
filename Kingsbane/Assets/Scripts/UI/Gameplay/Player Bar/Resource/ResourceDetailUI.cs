using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDetailUI : MonoBehaviour
{
    protected PlayerResource playerResource;

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
        buttonGroup.interactable = !GameManager.instance.effectManager.isUILocked;
    }

    public void InitResourceDetailUI(PlayerResource _playerResource)
    {
        playerResource = _playerResource;

        resourceIcon.sprite = GameManager.instance.iconManager.GetIcon(playerResource.ResourceType);
        resourceTitle.text = playerResource.ResourceType.ToString();

        RefreshResourceDetailUI();
    }

    public virtual void RefreshResourceDetailUI()
    {
        valueText.text = $"{playerResource.ResourceType}: {playerResource.Value}";
    }
}
