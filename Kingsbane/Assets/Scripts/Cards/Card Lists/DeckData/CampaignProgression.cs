using System;
using System.Linq;

[Serializable]
public class CampaignProgression
{
    private readonly int[] HONOUR_TRACKER = new int[] { 0, 2, 2, 2, 2, 3, 3, 3, 4, 4 };
    private readonly int MAX_CAMPAIGN_LENGTH = 10;

    private int DeckId { get; set; }

    public int CampaignId { get; set; }
    public int CampaignLength { get; private set; }
    public int CompletedScenarios { get; set; }
    public int CompletedSinceTierUpgrade { get; set; }
    public bool CompletedCampaign { get; set; }
    public int HonourPoints { get; set; }
    public int NumToReserve { get; set; }

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

    public void CompleteScenario()
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
        }
    }

    public void TriggerDefeat()
    {
        CompletedCampaign = true;
        GameManager.instance.deckManager.GetPlayerDeck(DeckId).ConverToBaseDeck();
    }
}
