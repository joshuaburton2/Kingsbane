using CategoryEnums;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// 
/// Script for obtaining sprite icons
/// 
/// </summary>
public class IconManager : MonoBehaviour
{
    [Serializable]
    private class ResourceIcon
    {
        public CardResources resourceID;
        public Sprite iconSprite;
    }

    [Serializable]
    private class ClassIcon
    {
        public Classes.ClassList classID;
        public Sprite iconSprite;
    }

    [SerializeField]
    Sprite defaultIcon;
    [SerializeField]
    List<ResourceIcon> resourceIcons = new List<ResourceIcon>();
    [SerializeField]
    List<ClassIcon> classIcons = new List<ClassIcon>();

    /// <summary>
    /// 
    /// Gets an icon of a particular type. Type is either classes or resources
    /// 
    /// </summary>
    public Sprite GetIcon<T>(T iconID)
    {
        var icon = defaultIcon;
        var type = typeof(T);

        switch (type)
        {
            case Type _ when type == typeof(Classes.ClassList):
                icon = classIcons.Where(x => x.classID == (Classes.ClassList)(object)iconID).FirstOrDefault().iconSprite;
                break;
            case Type _ when type == typeof(CardResources):
                icon = resourceIcons.Where(x => x.resourceID == (CardResources)(object)iconID).FirstOrDefault().iconSprite;
                break;
        }

        //Returns the default icon if no icon selected
        if(icon == null)
        {
            icon = defaultIcon;
        }

        return icon;
    }
}
