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

            var map3 = new Map()
            {
                Id = 3,
                Name = "Test",
                Description = "Test",
                ColourMapName = MapImageTags.Test,
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
            MapList.Add(map3);
            var map4 = new Map()
            {
                Id = 4,
                Name = "Test 2",
                Description = "Test",
                ColourMapName = MapImageTags.Test_2,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                },
            };
            MapList.Add(map4);
            var scenario3 = new Scenario()
            {
                Id = 3,
                Name = "Default Scenario",
                Description = "Test",
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
            ScenarioList.Add(scenario3);
            var scenario4 = new Scenario()
            {
                Id = 4,
                Name = "Test",
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
                    new int?[] { null,null,null,null,0,0,0,null,null,null, },
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
            ScenarioList.Add(scenario4);
            var scenario5 = new Scenario()
            {
                Id = 5,
                Name = "Default Scenario",
                Description = "Test ",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 1,1,1,1,1,1,1,1,1,1, },
                    new int?[] { 1,1,1,1,1,1,1,1,1,1, },
                    new int?[] { null,null,null,null,null,1,1,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,0,0,null,null,null, },
                    new int?[] { 0,0,0,0,0,0,0,0,0,0, },
                    new int?[] { 0,0,0,0,0,0,0,0,0,0, },
                },
                ObjectivesMap = new int?[][]
                {
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,3,null,null,null,null,null, },
                    new int?[] { null,null,null,3,3,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 3, Name = "Test", Color = new Color(0f, 0f, 0f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 1, Name = "Test Rule", Description = "Testing" },
                   new Rule() { Id = 2, Name = "Test", Description = "Test" },
                },
            };
            ScenarioList.Add(scenario5);

            map3.Scenarios = new List<Scenario> { scenario3 };
            map4.Scenarios = new List<Scenario> { scenario4, scenario5 };

        }
    }
}
namespace CategoryEnums
{
    public enum MapImageTags
    {
        Default, Test, Test_2
    }
}
