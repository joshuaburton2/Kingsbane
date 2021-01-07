using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CategoryEnums;
using System.Linq;

public class ResourceUI : MonoBehaviour
{
    [Serializable]
    private class ResourceDetailObject
    {
        public CardResources resourceType;
        public GameObject resourceDetailPrefab;
    }

    [SerializeField]
    private GameObject resourceDetailParent;
    [SerializeField]
    private List<ResourceDetailObject> resourceDetailObjects;

    private List<ResourceDetailUI> resourceDetailScripts;

    public void InitResourceUI(List<PlayerResource> resources)
    {
        resourceDetailScripts = new List<ResourceDetailUI>();

        foreach (var resource in resources)
        {
            var resourcePrefab = resourceDetailObjects.Single(x => x.resourceType == resource.ResourceType).resourceDetailPrefab;
            var resourceDetailObject = Instantiate(resourcePrefab, resourceDetailParent.transform);
            var resourceDetailScript = resourceDetailObject.GetComponent<ResourceDetailUI>();

            resourceDetailScript.InitResourceDetailUI(resource);
            resourceDetailScripts.Add(resourceDetailScript);
        }
    }

    public void RefreshResourceUI()
    {
        foreach (var resourceDetail in resourceDetailScripts)
        {
            resourceDetail.RefreshResourceDetailUI();
        }
    }
}
