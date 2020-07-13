using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum Rarity { Default, Common, Uncommon, Rare, Epic, Legendary }
    public enum CardType { Default, Unit, Spell, Item }

    public int CardID { get { return cardID; } }
    public int cardID = -1; //ID of the card in the card library. Should have no reference in gameplay
    public string CardName { get { return cardName; } }
    private string cardName = "Default";

    public Rarity rarity = Rarity.Default;
    public CardType cardType = CardType.Default;
    public Classes.ClassList cardClass = Classes.ClassList.Default;

    public Sprite cardArt;
    private string artLocation;

    public List<Tags.GeneralTags> CardTags { get; private set; }

    public List<Synergies.SynergyList> CardSyngergies { get; private set; }

    public Player CardOwner { get; private set; }

    [SerializeField]
    //The resource cost of the card. Default cost is the base cost without modifications based on the cards played in a game.
    //The resource cost is the cost of the card with modifications which may arise during a game.
    //The resource cost should always be set to the default cost at the start of each game.
    //The resources in order are Devotion, Energy, Gold, Knowledge, Mana, Wild, Neutral. 
    //Neutral cost is depricated but kept in for use in IsPlayable function. May be added again
    private int[] defaultCost = new int[] { 0, 0, 0, 0, 0, 0, 0 };
    private int[] resourceCost = new int[] { 0, 0, 0, 0, 0, 0, 0 };
    public List<Resources.ResourceList> Resources { get; private set; }

    private void Awake()
    {
        ResourceInit();
    }

    /// <summary>
    /// 
    /// Initialises the Resource Data on the card. To be called on awake
    /// 
    /// </summary>
    private void ResourceInit()
    {
        resourceCost = defaultCost;

        Resources = new List<Resources.ResourceList>();
        for (int resourceIndex = 0; resourceIndex < defaultCost.Length; resourceIndex++)
        {
            if (defaultCost[resourceIndex] != 0)
            {
                Resources.Add((Resources.ResourceList)resourceIndex);
            }
        }
    }

    /// <summary>
    /// 
    /// Tests if a card is playable based on the player's current resources
    /// 
    /// IMPORTANT: Can be reworked to integrate Resources in Player and Card class
    /// 
    /// </summary>
    /// <returns>True if the card can be played. False otherwise</returns>
    public bool IsPlayable()
    {
        int[] playerResources = CardOwner.playerResources;

        //The resource differences will be the difference between the player's current resources and their mandatory spending
        //of their resources based on the cost of the card
        int[] resourceDifferences = new int[playerResources.Length];

        for (int resourceID = 0; resourceID < resourceCost.Length; resourceID++)
        {
            //Calculate the resource difference. Calculated here even if the cost is 0 since needs a value for all resource types
            resourceDifferences[resourceID] = playerResources[resourceID] - resourceCost[resourceID];

            //Tests if the resource actually has a cost of that type
            if (resourceCost[resourceID] != 0)
            {
                //Tests if the current resource is not a neutral cost
                if (resourceID != resourceCost.Length - 1)
                {
                    //If the difference between the cost of a card and the player's resource is less than 0, this means the card cannot be played
                    if (resourceDifferences[resourceID] < 0)
                    {
                        return false;
                    }
                }
                //Case for if the card has a neutral cost
                else
                {
                    //Loops through all the resource difference values
                    foreach (int resourceDifference in resourceDifferences)
                    {
                        //If the player has enough resources remaining after spending the mandatory cost of the card, they can play
                        //the card
                        if(resourceDifference - resourceCost[resourceID] > 0)
                        {
                            return true;
                        }
                    }

                    //If none of the player's resources have the neutral cost remaining after spending the mandatory cost of the card, returns false
                    return false;
                }
            }
        }

        //Default outcome of the function. This will also return true if the card has no cost associated with it
        return true;
    }

    public virtual void Play()
    {

    }
}
