using System;

[Serializable]
public class CampaignProgression
{
    private readonly int[] honourTracker = new int[] { 0, 2, 2, 2, 2, 3, 3, 3, 4, 4 };

    public int CampaignId { get; set; }
    public int CampaignLength { get; set; }
    public int CompletedScenarios { get; set; }
    public bool CompletedCampaign { get; set; }
    public int HonourPoints { get; set; }

    public CampaignProgression(int campaignId)
    {
        CampaignId = campaignId;
        CampaignLength = GameManager.instance.scenarioManager.GetCampaign(CampaignId).Scenarios.Count;
        CompletedScenarios = 0;
        HonourPoints = 0;
    }

    public void CompleteScenario()
    {
        CompletedScenarios++;
        if (CompletedScenarios == CampaignLength)
        {
            //Need to add code for handling campaign victory here
        }
        else
        {
            HonourPoints += honourTracker[CompletedScenarios];
        }
    }

    public void TriggerDefeat()
    {

    }
}
