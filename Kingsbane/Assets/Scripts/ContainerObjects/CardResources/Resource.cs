using CategoryEnums;
using System;
using System.Collections.Generic;

/// <summary>
/// 
/// Object for storing resource data
/// 
/// </summary>
[Serializable]
public class Resource
{
    public CardResources ResourceType { get; set; }
    public int Value { get; set; } //To add Protected clause to Set

    public Resource()
    {
        ResourceType = CardResources.Neutral;
        Value = 0;
    }

    public Resource(CardResources resourceType, int value)
    {
        ResourceType = resourceType;
        Value = value;
    }

    /// <summary>
    /// 
    /// Copy a resource from one object to another
    /// 
    /// </summary>
    /// <param name="resource"></param>
    public Resource(Resource resource)
    {
        ResourceType = resource.ResourceType;
        Value = resource.Value;
    }

    /// <summary>
    /// 
    /// Calculate the new resource value if a given change is applied to it
    /// 
    /// </summary>
    public int CalcNewValue(int valueChange)
    {
        return Value + valueChange;
    }

    /// <summary>
    /// 
    /// Modify the value of the resource
    /// 
    /// </summary>
    public virtual int ModifyValue(int valueChange)
    {
        Value = CalcNewValue(valueChange);
        return Value;
    }

    public static string GetResoourceDescription(CardResources cardResource)
    {
        ResourceDescriptions.TryGetValue(cardResource, out string description);
        return description;
    }

    private static Dictionary<CardResources, string> ResourceDescriptions = new Dictionary<CardResources, string>()
    {
        { CardResources.Neutral, @"" },

        { CardResources.Devotion, @"Devotion is a representation of the players faith to a powerful entity, such as a god. This devotion allows the player to gather other like-minded individuals to their cause as well as cast powerful healing and enchantment spells to empower these units. 
<b>Resource Gain:</b> In order to gain Devotion, the player must play cards or use abilities with the <b>Prayer</b> keyword. Whenever such an effect is activated, gain the declared amount of Devotion.
<b>Ongoing Effect:</b>At the end of each scenario, the number of Prayer units left alive plus one, becomes the new Lasting Prayer amount. At the start of each turn, the player gains an amount of Devotion equal to their Lasting Prayer." },

        { CardResources.Energy, @"Energy is a measure of the hero’s strength and constitution. It allows the hero to perform supernatural feats in order to win the battle. Their might also allows them to rally other powerful warriors to their side. 
<b>Resource Gain:</b> At the start of each turn, the player gains a base energy increase. At the end of each turn, all their energy is removed, resetting their energy for their next turn.
<b>Ongoing Effect:</b> Energy decks have a limited pool of Surges they can use at any point on their turn. When a Surge is used, they gain an immediate boost of energy equal to their base energy increase." },

        { CardResources.Gold, @"Gold is a measure of the players wealth. It allows them to acquire various mercenary units, purchase items and pay for various services. This gold provides the player with a strong army and the ability to push their deck in any direction they desire.
<b>Resource Gain:</b>Whenever an enemy unit dies, the player gains an amount of Gold equal to their Bounty.
<b>Ongoing Effect:</b> The player's Gold amount persists between each scenarie. As such, whatever gold the player ends each scenario with is the amount they will start the next scenario with." },

        { CardResources.Knowledge, @"Knowledge decks display the player’s intelligence and understanding of the world around them or their foe. This understanding allows them to manipulate the battlefield, their deck or their foe to give them the advantage in the field. Other intelligent people look to the player as a beacon of knowledge in the world and will flock to their side to aid them. 
<b>Resource Gain:</b> At the start of each turn, the player gains an amount of Knowledge equal to their base increase. At the end of each turn, their Knowledge is reset to zero, resetting it for the next turn. Whenever a player uses a <b>Study</b> effect, they shuffle a number of Inspiration cards into their deck. Whenever a player draws an Inspiration card, their base Knowledge gain is increase by 1 for that scenario.
<b>Ongoing Effect:</b> Whenever a player activates a <b>Study</b> effect, this increases their Stagnation by 1. While there are no immediate detriments, for every 3 Stagnation points a player has they will have a point of Ignorance. For every point of Ignorance a player has, every time they activate a <b>Study</b> effect, they will shuffle one less Inspiration card into their deck." },

        { CardResources.Mana, @"Mana is a representation of a player’s connection with the arcane magic that suffuses the world. Mana can be spent to cast powerful damaging spells and summon powerful, but limited units, to defend the hero. 
<b>Resource Gain:</b> Mana starts at an initial high value at the start of each scenario. The player must activate effects which increase their mana.
<b>Ongoing Effect:</b>When a player's Mana reaches 0, they can still spend it, however this will cause their Mana to Overload. For each point they are Overloaded by, they have a negative <b>Empowered</b> score equal to their Overload value and all their units have -1 Attack for each point Overloaded (to a minimum of 1 Attack). Their Overload value will persist into the next scenario and disappear at the end of that scenario." },

        { CardResources.Wild, @"Wild decks display the players connection with nature and the wilderness. This connection allows them to summon powerful creatures of the wild, crush and control their opponents’ units and unleash their primal instincts. 
<b>Resource Gain:</b> At the start of each scenario, the player has a Wild value of 0. At the start of each turn, the player gains Wild equal to their Wild gain value. This will increase up to a maximum value, after which the player will gain no more Wild.
<b>Ongoing Effect:</b> Whenever a player plays an effect with <b>Cycle</b>, the player's maximum Wild will increase or decrease as defined by the effect. The changes in their maximum will persist throughout a campaign." },

    };
}
