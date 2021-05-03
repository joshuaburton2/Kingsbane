using CategoryEnums;
using System.Collections.Generic;
using UnityEngine;
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

            var map5 = new Map()
            {
                Id = 5,
                Name = "Sandbox",
                Description = "Sandbox- For Test Purposes Only",
                ColourMapName = MapImageTags.Sandbox,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                },
            };
            MapList.Add(map5);
            var map6 = new Map()
            {
                Id = 6,
                Name = "River Crossing",
                Description = "Crossing over a river with nearby shallows",
                ColourMapName = MapImageTags.RiverCrossing,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm, },
                    new TerrainTypes[] { TerrainTypes.Chasm,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                },
            };
            MapList.Add(map6);
            var scenario6 = new Scenario()
            {
                Id = 6,
                Name = "Default Scenario",
                Description = "",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 1,1,1,1,1,1,1,1,1,1, },
                    new int?[] { 1,1,1,1,1,1,1,1,1,1, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,0,0,0,0,0,0,0,0,0, },
                    new int?[] { 0,0,0,0,0,0,0,0,0,0, },
                },
                ObjectivesMap = new int?[][]
                {
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                },
                Rules = new List<Rule>()
                {
                },
            };
            ScenarioList.Add(scenario6);
            var scenario7 = new Scenario()
            {
                Id = 7,
                Name = "Default Scenario",
                Description = "",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 1,1,1,1,1,1,1,1,1,1, },
                    new int?[] { 1,1,1,1,1,1,1,1,1,1, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,0,0,0,0,0,0,0,0,null, },
                    new int?[] { 0,0,0,0,0,0,0,0,0,0, },
                },
                ObjectivesMap = new int?[][]
                {
                    new int?[] { 4,4,4,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 4, Name = "Test", Color = new Color(0.87058824f, 0f, 0f) },
                },
                Rules = new List<Rule>()
                {
                },
            };
            ScenarioList.Add(scenario7);

            map5.Scenarios = new List<Scenario> { scenario6 };
            map6.Scenarios = new List<Scenario> { scenario7 };

        }
    }
}
namespace CategoryEnums
{
    public enum MapImageTags
    {
        Default, RiverCrossing, Sandbox
    }
}
