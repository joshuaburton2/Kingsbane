using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourceList : MonoBehaviour
{
    private bool isSelected;
    private List<ResourceListObject> resourceListObjects;

    [SerializeField]
    private NewDeckUI newDeckUI;
    [SerializeField]
    private GameObject resourceListParent;
    [SerializeField]
    private GameObject resourceListPrefab;

    private void Start()
    {
        isSelected = false;
    }

    /// <summary>
    /// 
    /// Refreshes the resource list with the resource list objects
    /// 
    /// </summary>
    /// <param name="excemptResource">The other selected resource to exempt from the list</param>
    public void InitResourceList(CardResources? excemptResource = null)
    {
        GameManager.DestroyAllChildren(resourceListParent);
        resourceListObjects = new List<ResourceListObject>();

        //Loops through each resource in the game
        foreach (var resource in Enum.GetValues(typeof(CardResources)))
        {
            //Ignores the neutral resource and the exempt resource
            if ((CardResources)resource != CardResources.Neutral && (CardResources)resource != excemptResource)
            {
                //Creates the resource list objects and initialises them
                var resourceListObject = Instantiate(resourceListPrefab, resourceListParent.transform);
                var resourceListScript = resourceListObject.GetComponent<ResourceListObject>();
                resourceListScript.InitResourceListObject((CardResources)resource, this);
                resourceListObjects.Add(resourceListScript);
            }
        }
    }

    /// <summary>
    /// 
    /// Refreshes the resource list with the resource list objects, but only if the resource has not already been selected
    /// 
    /// </summary>
    public void RefreshResourceList(CardResources? excemptResource = null)
    {
        if (!isSelected)
        {
            InitResourceList(excemptResource);
        }
    }

    /// <summary>
    /// 
    /// Function to call when a resource in the list is selected
    /// 
    /// </summary>
    /// <param name="toSelect">Whether the resource is being selected (true) or deselected (false)</param>
    public void SelectResource(CardResources selectedResource, bool toSelect)
    {
        //Loops through each resource object and shows or hides them based on whether the resource is selected or not
        foreach (var resourceObject in resourceListObjects)
        {
            if (resourceObject.cardResource != selectedResource)
            {
                resourceObject.gameObject.SetActive(!toSelect);
            }
        }

        isSelected = toSelect;
        newDeckUI.SelectResource(toSelect, selectedResource, this);
    }
}
