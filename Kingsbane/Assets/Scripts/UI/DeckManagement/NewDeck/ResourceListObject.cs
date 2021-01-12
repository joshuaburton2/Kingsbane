using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using CategoryEnums;

public class ResourceListObject : MonoBehaviour, IPointerClickHandler
{
    private ResourceList resourceList;
    public CardResources cardResource;

    private bool isSelected;

    [SerializeField]
    private TextMeshProUGUI resourceName;
    [SerializeField]
    private Image resourceIcon;
    [SerializeField]
    private Image resourceBackground;
    [SerializeField]
    private GameObject resourceDescriptionArea;
    [SerializeField]
    private TextMeshProUGUI resourceDescriptionText;

    /// <summary>
    /// 
    /// Initialise the class list object
    /// 
    /// </summary>
    public void InitResourceListObject(CardResources _cardResource, ResourceList _resourceList)
    {
        resourceList = _resourceList;
        cardResource = _cardResource;

        resourceName.text = cardResource.ToString().ToUpper();
        resourceBackground.color = GameManager.instance.colourManager.GetResourceColour(cardResource);
        resourceIcon.sprite = GameManager.instance.iconManager.GetIcon(cardResource);

        resourceDescriptionText.text = Resource.GetResoourceDescription(cardResource);
        resourceDescriptionArea.SetActive(false);
    }

    /// <summary>
    /// 
    /// Click handler for clicking on resource list object
    /// 
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isSelected = !isSelected;
            resourceDescriptionArea.SetActive(isSelected);
            resourceList.SelectResource(cardResource, isSelected);
        }
    }
}
