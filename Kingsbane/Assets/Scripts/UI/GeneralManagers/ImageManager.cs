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
    private class ImageObject
    {
        public CardImageTags imageTag;
        public Sprite imageSprite;
    }

    [SerializeField]
    private Sprite defaultImage;
    [SerializeField]
    private List<ImageObject> mapImages; //Need to use a different tag system for this

    [SerializeField]
    private List<ImageObject> abyssalCardImages;
    [SerializeField]
    private List<ImageObject> agentCardImages;
    [SerializeField]
    private List<ImageObject> arcanistCardImages;
    [SerializeField]
    private List<ImageObject> captainCardImages;
    [SerializeField]
    private List<ImageObject> elementalistCardImages;
    [SerializeField]
    private List<ImageObject> grovewatcherCardImages;
    [SerializeField]
    private List<ImageObject> lifebringerCardImages;
    [SerializeField]
    private List<ImageObject> lorekeeperCardImages;
    [SerializeField]
    private List<ImageObject> luministCardImages;
    [SerializeField]
    private List<ImageObject> mercenaryCardImages;
    [SerializeField]
    private List<ImageObject> oathknightCardImages;
    [SerializeField]
    private List<ImageObject> runebladeCardImages;
    [SerializeField]
    private List<ImageObject> tricksterCardImages;
    [SerializeField]
    private List<ImageObject> waystalkerCardImages;
    [SerializeField]
    private List<ImageObject> wildkinCardImages;

    /// <summary>
    /// 
    /// Gets an image for a card based on a particular tag
    /// 
    /// </summary>
    public Sprite GetCardImage(CardImageTags imageTag, Classes.ClassList requiredClass)
    {
        var image = defaultImage;
        ImageObject imageObject = null;

        switch (requiredClass)
        {
            case Classes.ClassList.Abyssal:
                imageObject = abyssalCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Agent:
                imageObject = agentCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Arcanist:
                imageObject = arcanistCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Captain:
                imageObject = captainCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Elementalist:
                imageObject = elementalistCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Grovewatcher:
                imageObject = grovewatcherCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Lifebringer:
                imageObject = lifebringerCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Lorekeeper:
                imageObject = lorekeeperCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Luminist:
                imageObject = luministCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Mercenary:
                imageObject = mercenaryCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Oathknight:
                imageObject = oathknightCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Runeblade:
                imageObject = runebladeCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Trickster:
                imageObject = tricksterCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Waystalker:
                imageObject = waystalkerCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Wildkin:
                imageObject = wildkinCardImages.FirstOrDefault(x => x.imageTag == imageTag);
                break;
            case Classes.ClassList.Default:
            default:
                break;
        }

        if (imageObject == null)
            image = defaultImage;
        else
            image = imageObject.imageSprite;

        return image;
    }
}
