using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scenarios
{
    public class ScenarioLibrary
    {
        public List<Map> MapList { get; private set; }
        public List<Scenario> ScenarioList { get; private set; }
        public List<Campaign> CampaignList { get; private set; }

        public void InitLibrary()
        {
            MapList = new List<Map>();
            ScenarioList = new List<Scenario>();
            CampaignList = new List<Campaign>();

            var map0 = new Map()
            {
                Id = 0,
                Name = "Test Map",
                Description = "",
                ColourMapName = "Test Map Map",
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                },
            };
            MapList.Add(map0);

            var scenario0 = new Scenario()
            {
                Id = 0,
                Name = "Test Scenario",
                Description = "",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, },
                    new int?[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                    new int?[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
                },
                ObjectivesMap = new int?[][]
                {
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                    new int?[] { null, null, null, null, null, null, null, null, null, null, },
                },
                Objectives = new List<Objective>(),
                Rules = new List<Rule>(),
            };
            ScenarioList.Add(scenario0);

            map0.Scenarios = new List<Scenario>() { scenario0, };
        }
    }
}
