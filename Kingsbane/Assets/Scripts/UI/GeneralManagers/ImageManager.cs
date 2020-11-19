using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CategoryEnums;

public class ImageManager : MonoBehaviour
{
    [Serializable]
    private class ImageObject
    {
        public string imageName;
        public Sprite imageSprite;
    }

    [SerializeField]
    private Sprite defaultImage;
    [SerializeField]
    private List<ImageObject> cardImages;
    [SerializeField]
    private List<ImageObject> mapImages;
}
