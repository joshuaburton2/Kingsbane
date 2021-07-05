using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


/// <summary>
/// 
/// Object for storing a decks progression through a campaign
/// 
/// </summary>
[Serializable]
public class CampaignProgression
{
    //Constant properties for campaign
    //Honour tracker is the amount of honour gained at that number of scenarios completed
    private readonly int[] HONOUR_TRACKER = new int[] { 0, 2, 2, 2, 2, 3, 3, 3, 4, 4 };
    private readonly int BONUS_OBJECTIVE_HONOUR = 1;
    private readonly int MAX_CAMPAIGN_LENGTH = 10;

    private const int NUM_LOOT_CARDS = 8;

    //Cannot store the deckdata or campaigndata object as this cannot be serialized
    private int DeckId { get; set; }
    public int CampaignId { get; set; }
    public int CampaignLength { get; private set; }
    public int CompletedScenarios { get; set; }
    public int CompletedSinceTierUpgrade { get; set; }
    public bool CompletedCampaign { get; set; }
    public int HonourPoints { get; set; }
    public int NumToReserve { get; set; }
    public List<SaveLootCard> LootCards { get; set; }
    public int NumLootRotations { get; set; }
    public int TotalWeighting { get; set; }

    /// <summary>
    /// 
    /// Creates an object for tracking a players campaign progression. Can be serialized to save
    /// 
    /// </summary>
    /// <param name="deckId"></param>
    /// <param name="campaignId"></param>
    public CampaignProgression(int deckId, int campaignId)
    {
        DeckId = deckId;
        CampaignId = campaignId;
        var campaign = GameManager.instance.scenarioManager.GetCampaign(CampaignId);
        CampaignLength = campaign.Scenarios.Count;
        if (CampaignLength > MAX_CAMPAIGN_LENGTH)
            throw new Exception($"Cannot have a campaign of length greater than {MAX_CAMPAIGN_LENGTH}, currently {CampaignLength}");
        CompletedScenarios = 0;
        CompletedSinceTierUpgrade = 0;
        HonourPoints = 0;
        NumToReserve = 0;

        ResetLootCards();
    }

    public DeckData GetDeck()
    {
        return GameManager.instance.deckManager.GetPlayerDeck(DeckId);
    }

    /// <summary>
    /// 
    /// Gets the campaign the tracker is associated with
    /// 
    /// </summary>
    /// <returns></returns>
    public Campaign GetCampaign()
    {
        return GameManager.instance.scenarioManager.GetCampaign(CampaignId);
    }

    /// <summary>
    /// 
    /// Gets the data for the scenario the player is currently on
    /// 
    /// </summary>
    /// <returns></returns>
    public Scenario GetCurrentScenario()
    {
        //If the player hasnt completed the campaign, then gets the current scenario in the list
        if (!CompletedCampaign)
        {
            return GetCampaign().Scenarios[CompletedScenarios];
        }
        else
        {
            //Not utilised currently, but if wanting to view the player's completed campaign, can use the last scenario as the default one loaded
            return GetCampaign().Scenarios.LastOrDefault();
        }
    }

    /// <summary>
    /// 
    /// Complete the scenario for the player
    /// 
    /// </summary>
    /// <param name="completedBonusObjectives">If the player has succesffuly completed the bonus object, pass true here</param>
    public void CompleteScenario(bool completedBonusObjectives)
    {
        //Increase the number of completed scenarios and the tier upgrade tracker
        CompletedScenarios++;
        CompletedSinceTierUpgrade++;
        //If equal to the campaign length, means player has completed the campaign
        if (CompletedScenarios == CampaignLength)
        {
            CompletedCampaign = true;
            //Converts the player's deck to a non-campaign deck so they cannot load in again- may need to be refined in future to allow for campaign reviews
            GetDeck().ConverToBaseDeck();
        }
        else
        {
            //If continuing campaign, gives the player their required honour and adds a new loot rotation, as they always get one at the end of each scenario
            HonourPoints += HONOUR_TRACKER[CompletedScenarios];

            AddLootRotations(1);

            //Adds extra honour if the player completed the bonus objective
            if (completedBonusObjectives)
            {
                HonourPoints += BONUS_OBJECTIVE_HONOUR;
            }
        }
    }

    /// <summary>
    /// 
    /// If a player loses a scenario in a campaign, triggers a defeat for them
    /// 
    /// </summary>
    public void TriggerDefeat()
    {
        //Will need to be expanded in future to allow for campaign reviews
        CompletedCampaign = true;
        GetDeck().ConverToBaseDeck();
    }

    /// <summary>
    /// 
    /// Resets the loot cards for the player back to their base
    /// 
    /// </summary>
    public void ResetLootCards()
    {
        LootCards = new List<SaveLootCard>();
        TotalWeighting = 0;
    }

    /// <summary>
    /// 
    /// Generates a new loot rotation for the player and stores the data
    /// 
    /// </summary>
    public void GenerateLootRotation()
    {
        LootCards = GameManager.instance.libraryManager.GenerateLootCards(GetDeck(), NUM_LOOT_CARDS, out int totalWeighting)
            .Select(x => x.ConvertToSaveLootCard()).ToList(); //Converts the loot cards to save loot cards so they can be serialized
        TotalWeighting = totalWeighting;
    }

    /// <summary>
    /// 
    /// Adds a given number of new loot rotations to the player
    /// 
    /// </summary>
    public void AddLootRotations(int numRotations)
    {
        NumLootRotations += numRotations;

        //If there a new loot cards stored, generates a new rotation
        if (!LootCards.Any())
            GenerateLootRotation();

        GameManager.instance.deckManager.SaveDecks();
    }

    /// <summary>
    /// 
    /// Confirms a loot rotation after adding the cards to their deck
    /// 
    /// </summary>
    /// <returns></returns>
    public bool ConfirmLootRotation()
    {
        NumLootRotations--;

        //If there are still loot rotations left, generates a new rotation
        if (NumLootRotations > 0)
        {
            GenerateLootRotation();
        }

        GameManager.instance.deckManager.SaveDecks();

        return NumLootRotations > 0;
    }

    /// <summary>
    /// 
    /// Add a number of cards to reserve for the player
    /// 
    /// </summary>
    /// <param name="numToReserve"></param>
    public void AddNumToReserves(int numToReserve)
    {
        //Minimises the number to reserve to ensure the player does not need to remove more cards than they have in the deck
        numToReserve = Mathf.Min(numToReserve, GetDeck().DeckCount);

        //Increases by minimised num to reserve
        NumToReserve += numToReserve;
        GameManager.instance.deckManager.SaveDecks();
    }
}
