using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CategoryEnums;
using System.Linq;

/// <summary>
/// 
/// IMPORTANT: If cards are ever deleted, need to ensure that all the image tags line up correctly with their image.
/// Deleteing cards may cause these to go out of sync
/// 
/// </summary>
public class ImageManager : MonoBehaviour
{
    [Serializable]
    private class ClassImageList
    {
        public Classes.ClassList Class;
        public List<CardImageObject> imageList;
    }

    [Serializable]
    private class CardImageObject
    {
        public CardImageTags imageTag;
        public Sprite imageSprite;
    }

    [SerializeField]
    private Sprite defaultImage;
    [SerializeField]
    private List<CardImageObject> mapImages; //Need to use a different tag system for this

    [SerializeField]
    private List<ClassImageList> classImageList;

    /// <summary>
    /// 
    /// Gets an image for a card based on a particular tag
    /// 
    /// </summary>
    public Sprite GetCardImage(CardImageTags imageTag, Classes.ClassList requiredClass)
    {
        var image = defaultImage;
        CardImageObject imageObject = null;

        imageObject = classImageList.FirstOrDefault(x => x.Class == requiredClass).imageList.FirstOrDefault(x => x.imageTag == imageTag);

        if (imageObject == null)
            image = defaultImage;
        else
            image = imageObject.imageSprite;

        return image;
    }

    /// <summary>
    /// 
    /// Context Menu function for syncing the card images with their appropriate tags.
    /// Make sure to keep image names consistent with tags.
    /// 
    /// SHOULD NOT BE CALLED IN GAME
    /// 
    /// </summary>
    [ContextMenu("Sync Image Tags")]
    public void SyncImageTags()
    {
        foreach (var Class in classImageList)
        {
            foreach (var image in Class.imageList)
            {
                if (Enum.TryParse(image.imageSprite.name, true, out CardImageTags imageTag))
                    image.imageTag = imageTag;
                else
                {
                    Debug.Log($"Missing Tag for {image.imageSprite.name}");
                    image.imageTag = CardImageTags.Default;
                }
                    
            }
        }
    }
}
