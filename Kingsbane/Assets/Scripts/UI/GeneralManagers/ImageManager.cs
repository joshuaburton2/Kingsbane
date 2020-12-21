using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CategoryEnums;
using System.Linq;

public class ImageManager : MonoBehaviour
{
    [Serializable]
    private class ImageObject
    {
        public CardImageTags imageTag;
        public Sprite imageSprite;
    }

    [SerializeField]
    private Sprite defaultImage;
    [SerializeField]
    private List<ImageObject> cardImages;
    [SerializeField]
    private List<ImageObject> mapImages; //Need to use a different tag system for this

    public Sprite GetCardImage(CardImageTags imageTag)
    {
        var image = defaultImage;

        var ImageObject = cardImages.FirstOrDefault(x => x.imageTag == imageTag);
        if (ImageObject == null)
            image = defaultImage;
        else
            image = ImageObject.imageSprite;

        return image;
    }
}
