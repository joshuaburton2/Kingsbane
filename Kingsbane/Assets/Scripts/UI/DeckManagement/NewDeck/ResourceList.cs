using CategoryEnums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ResourceList : MonoBehaviour
{
    private List<ResourceListObject> resourceListScripts;

    [SerializeField]
    private NewDeckUI newDeckUI;
    [SerializeField]
    private GameObject resourceListParent;
    [SerializeField]
    private GameObject resourceListPrefab;

    public void RefreshResourceList(CardResources? selectedResource = null)
    {
        GameManager.DestroyAllChildren(resourceListParent);
        resourceListScripts = new List<ResourceListObject>();

        foreach (var resource in Enum.GetValues(typeof(CardResources)))
        {
            if ((CardResources)resource != CardResources.Neutral && (CardResources)resource != selectedResource)
            {
                var resourceListObject = Instantiate(resourceListPrefab, resourceListParent.transform);

                var resourceListScript = resourceListObject.GetComponent<ResourceListObject>();
                resourceListScript.InitResourceListObject((CardResources)resource, this);
                resourceListScripts.Add(resourceListScript);
            }
        }
    }

    public void SelectResource(CardResources selectedResource, bool toSelect)
    {
        foreach (var resourceObject in resourceListScripts)
        {
            if (resourceObject.cardResource != selectedResource)
            {
                resourceObject.gameObject.SetActive(!toSelect);
            }
        }

        newDeckUI.SelectResource(toSelect, selectedResource, this);
    }
}
