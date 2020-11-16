using CategoryEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            var map1 = new Map()
            {
                Id = 1,
                Name = "Test Map 2",
                Description = "Test",
                ColourMapName = "Test Map 2 Map",
                TerrainMap = new TerrainTypes[][]
    {
                    new TerrainTypes[] { TerrainTypes.Difficult, TerrainTypes.Chasm, TerrainTypes.Impassable, TerrainTypes.Obstacle, TerrainTypes.TallObstacle, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, TerrainTypes.Regular, },
    },
            };
            MapList.Add(map1);

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
                    new int?[] { 0, null, null, null, null, null, null, null, null, null, },
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
                Objectives = new List<Objective>()
                {
                    new Objective() { Id = 0, Name = "Test Objective", Color = new Color(1.0f, 0.0f, 0.0f) },
                },
                Rules = new List<Rule>()
                {
                    new Rule() { Id = 0, Name = "Test Rule", Description = "This is a test rule" },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(34),
            };
            ScenarioList.Add(scenario0);

            var scenario1 = new Scenario()
            {
                Id = 1,
                Name = "Test Scenario 1",
                Description = "Test ",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, },
                    new int?[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, },
                    new int?[] { 1, null, null, null, null, null, null, null, null, null, },
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
                    new int?[] { 0, null, null, null, null, null, null, null, null, null, },
                },
                Objectives = new List<Objective>()
                {
                    new Objective() { Id = 0, Name = "Test Objective", Color = new Color(1.0f, 0.0f, 0.0f) },
                },
                Rules = new List<Rule>()
                {
                    new Rule() { Id = 0, Name = "Test Rule", Description = "This is a test rule" },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(34),
            };
            ScenarioList.Add(scenario1);

            var campaign0 = new Campaign()
            {
                Id = 0,
                Name = "Test Campaign",
                Description = "",
            };
            CampaignList.Add(campaign0);

            map0.Scenarios = new List<Scenario>() { scenario0, };
            map1.Scenarios = new List<Scenario>() { scenario1, };

            campaign0.Scenarios = new List<Scenario>() { scenario0, scenario1 };
        }
    }
}
