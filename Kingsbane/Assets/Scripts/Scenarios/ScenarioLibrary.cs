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

            var map7 = new Map()
            {
                Id = 7,
                Name = "MountainPass",
                Description = "Pass through a mountain range",
                ColourMapName = MapImageTags.MountainPass,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.TallObstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.TallObstacle,TerrainTypes.TallObstacle, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.TallObstacle,TerrainTypes.TallObstacle,TerrainTypes.TallObstacle, },
                    new TerrainTypes[] { TerrainTypes.TallObstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.TallObstacle, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.TallObstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.TallObstacle,TerrainTypes.TallObstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.TallObstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.TallObstacle,TerrainTypes.TallObstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.TallObstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.TallObstacle, },
                },
            };
            MapList.Add(map7);

            var map8 = new Map()
            {
                Id = 8,
                Name = "Farmland",
                Description = "Battle in the farms",
                ColourMapName = MapImageTags.Farmland,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                },
            };
            MapList.Add(map8);

            var scenario6 = new Scenario()
            {
                Id = 6,
                Name = "Default Scenario",
                Description = "",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 1,1,1,1,1,1,1,1,1,1, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
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
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
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
            ScenarioList.Add(scenario7);

            var scenario8 = new Scenario()
            {
                Id = 8,
                Name = "Default Scenario",
                Description = "",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 1,1,1,1,1,1,1,1,1,1, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,0,0,0,0,0,0,0,0,0, },
                },
                ObjectivesMap = new int?[][]
                {
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,5,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 5, Name = "Hidden Alcove", Color = new Color(0.78431374f, 0f, 0f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 3, Name = "Hidden Alcove", Description = "The last player to occupy the objective tile for the Hidden Alcove owns it. Whoever owns the Hidden Alcove can deploy their units in adjacent tiles" },
                },
            };
            ScenarioList.Add(scenario8);

            var scenario9 = new Scenario()
            {
                Id = 9,
                Name = "Default Scenario",
                Description = "",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 1,1,1,1,1,1,1,1,1,1, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
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
            ScenarioList.Add(scenario9);

            var campaign2 = new Campaign()
            {
                Id = 2,
                Name = "Test",
                Description = "Test",
            };
            CampaignList.Add(campaign2);

            map5.Scenarios = new List<Scenario> { scenario6 };
            map6.Scenarios = new List<Scenario> { scenario7 };
            map7.Scenarios = new List<Scenario> { scenario8 };
            map8.Scenarios = new List<Scenario> { scenario9 };

            scenario6.Map = map5;
            scenario7.Map = map6;
            scenario8.Map = map7;
            scenario9.Map = map8;

            campaign2.Scenarios = new List<Scenario> { scenario6, scenario7, scenario8, scenario9 };
        }
    }
}
namespace CategoryEnums
{
    public enum MapImageTags
    {
        Default, Farmland, MountainPass, RiverCrossing, Sandbox
    }
}
