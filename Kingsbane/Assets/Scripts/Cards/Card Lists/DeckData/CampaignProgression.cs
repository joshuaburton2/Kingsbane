using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



[Serializable]
public class CampaignProgression
{
    private readonly int[] HONOUR_TRACKER = new int[] { 0, 2, 2, 2, 2, 3, 3, 3, 4, 4 };
    private readonly int BONUS_OBJECTIVE_HONOUR = 1;
    private readonly int MAX_CAMPAIGN_LENGTH = 10;

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

    private const int numLootCards = 8;

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

    public Campaign GetCampaign()
    {
        return GameManager.instance.scenarioManager.GetCampaign(CampaignId);
    }

    public Scenario GetCurrentScenario()
    {
        if (!CompletedCampaign)
        {
            return GetCampaign().Scenarios[CompletedScenarios];
        }
        else
        {
            return GetCampaign().Scenarios.LastOrDefault();
        }
    }

    public void CompleteScenario(bool completedBonusObjectives)
    {
        CompletedScenarios++;
        CompletedSinceTierUpgrade++;
        if (CompletedScenarios == CampaignLength)
        {
            CompletedCampaign = true;
            GameManager.instance.deckManager.GetPlayerDeck(DeckId).ConverToBaseDeck();
        }
        else
        {
            HonourPoints += HONOUR_TRACKER[CompletedScenarios];

            AddLootRotations(1);

            if (completedBonusObjectives)
            {
                HonourPoints += BONUS_OBJECTIVE_HONOUR;
            }
        }
    }

    public void TriggerDefeat()
    {
        CompletedCampaign = true;
        GameManager.instance.deckManager.GetPlayerDeck(DeckId).ConverToBaseDeck();
    }

    public void ResetLootCards()
    {
        LootCards = new List<SaveLootCard>();
        TotalWeighting = 0;
    }

    public void GenerateLootRotation()
    {
        LootCards = GameManager.instance.libraryManager.GenerateLootCards(GameManager.instance.deckManager.GetPlayerDeck(DeckId), numLootCards, out int totalWeighting)
            .Select(x => x.ConvertToSaveLootCard()).ToList();
        TotalWeighting = totalWeighting;
    }

    public void AddLootRotations(int numRotations)
    {
        NumLootRotations += numRotations;

        GenerateLootRotation();

        GameManager.instance.deckManager.SaveDecks();
    }

    public bool ConfirmLootRotation()
    {
        NumLootRotations--;

        if (NumLootRotations > 0)
        {
            GenerateLootRotation();
        }

        GameManager.instance.deckManager.SaveDecks();

        return NumLootRotations > 0;
    }
}
