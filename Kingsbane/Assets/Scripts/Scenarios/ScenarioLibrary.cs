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
                Name = "Mountain Pass",
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

            var map9 = new Map()
            {
                Id = 9,
                Name = "Wasteland Path",
                Description = "A commonly tread trail through the desolate wastes, caravans are frequently seen traversing the path in order to facilitate trade between the Clan Halls of the Wastes. However those who walk such a path must tread carefully, for monsters are drawn to it as they know that, eventually, their food will come.",
                ColourMapName = MapImageTags.WastelandPath,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                },
            };
            MapList.Add(map9);

            var map10 = new Map()
            {
                Id = 10,
                Name = "Proving Grounds",
                Description = "The Roktarr proving grounds are where its young members are inducted formally into the clans ranks. The trials are tough and grueling, but those who endure them come out stronger for it.",
                ColourMapName = MapImageTags.ProvingGrounds,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Impassable,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle, },
                },
            };
            MapList.Add(map10);

            var map11 = new Map()
            {
                Id = 11,
                Name = "Northern Colony",
                Description = "It is a common sight for Imperial forces to be seen on the southern borders of the Grey Wastes, but in some cases, they take it a step too far and establish a formal colony in the region, infringing upon the freedom of the Wastes. It does not take long before the Wildfolk retaliate, for they know that the more they give to the Imperials, the more they will seek to take. As such, such colonies rarely stand for long, as the Wildfolk look to remove the root of the problem before it grows.",
                ColourMapName = MapImageTags.NorthernColony,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                },
            };
            MapList.Add(map11);

            var map12 = new Map()
            {
                Id = 12,
                Name = "Forest Trail",
                Description = "The Wastes are wild, but there are still paths forged through them, even through the dense forests of the Southern Wastes. These trails weave and wander through these lands and offer some degree of safety. But still one must be careful of what is lurking in the shadows.",
                ColourMapName = MapImageTags.ForestTrail,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle, },
                },
            };
            MapList.Add(map12);

            var map13 = new Map()
            {
                Id = 13,
                Name = "Roktarr Clan Hall",
                Description = "The clan hall of the Roktarr is built in one of the few fertile valleys of the Wastes, the land claimed by the clan many years ago. The centre and home of the clan, the clan hall is a unifying icon for the would be disparate members of the clan. Members of the clan would die to defend it, no matter the cost.",
                ColourMapName = MapImageTags.RoktarrClanHall,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular, },
                },
            };
            MapList.Add(map13);

            var map14 = new Map()
            {
                Id = 14,
                Name = "Untovan Barrows",
                Description = "Mysterious and haunted, the Untovan Barrows are a cursed place in the wastes. It was where the bodies of those who were slain by the ancient Shadow Dragon Kyravor were laid to rest. Over time, the curse of Kyravor has corrupted their spirits, transforming them into fearsome creatures of shadow. They now haunt the barrows, turning it into an evil domain of shadows and death.",
                ColourMapName = MapImageTags.UntovanBarrows,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Chasm,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Chasm,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Chasm,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle, },
                },
            };
            MapList.Add(map14);

            var map15 = new Map()
            {
                Id = 15,
                Name = "The Burned Grove",
                Description = "Once the home of the Volkar Clan who were instrumental in standing up against Kyravor, the Burned Grove is now a haunted place, where the forest still burn after centuries of being incinerated by shadowy dragon fire. Among these trees however, the last surviving druids and their treants still wander, protecting an ancient secret hidden away within the grove, only granting it to those who are worthy.",
                ColourMapName = MapImageTags.TheBurnedGrove,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Obstacle,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Obstacle,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                },
            };
            MapList.Add(map15);

            var map16 = new Map()
            {
                Id = 16,
                Name = "Kyravor's Grave",
                Description = "The resting place of the cursed Shadow Dragon Kyravor is a cursed land, with the shadow energies of the dragon seeping into the lands around. Few would dare enter or cross these lands, and those who would must have good reason to do so. The only known inhabitants of the land are those who have been cursed with protecting the grave, for whatever fell future might be in store for it.",
                ColourMapName = MapImageTags.KyravorsGrave,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Difficult,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                },
            };
            MapList.Add(map16);

            var map17 = new Map()
            {
                Id = 17,
                Name = "Volcanic Forge",
                Description = "Hidden away in the heart of the volcano Sithrimus lies an ancient forge which uses the power of the volcano to create items of mythic proportions. The residents of the forge have protected it for thousands of years and are very cautious about who is able to gain access to their tools, keeping an aura of mystery around the forge as few are able to enter its domain.",
                ColourMapName = MapImageTags.VolcanicForge,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.TallObstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Chasm,TerrainTypes.Obstacle, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Chasm, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Chasm, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Chasm,TerrainTypes.Chasm,TerrainTypes.Chasm, },
                },
            };
            MapList.Add(map17);

            var map18 = new Map()
            {
                Id = 18,
                Name = "Shrine of Se'Carr",
                Description = "The wastes are so large and expansive, that there are many places were few have ever tread, breeding secret and dark places hidden far away from civilization. Many cults found their shrines in such places, hidden away where they can work toward their fell agenda in secret. This shrine was founded many years ago dedicated to Se’carr, an ancient mysterious entity which dwells in the depths of the Abyss, its goals unfathomable to mortal minds. Many dark rituals have been performed here since its founding and it is a place of horror and madness, the energy of the Abyss seeping into it. It would not take much for the rift to be torn asunder, bringing whatever lurks in the darkest places of the Abyss into our world..",
                ColourMapName = MapImageTags.ShrineofSecarr,
                TerrainMap = new TerrainTypes[][]
                {
                    new TerrainTypes[] { TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Impassable, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle, },
                },
            };
            MapList.Add(map18);

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

            var scenario10 = new Scenario()
            {
                Id = 10,
                Name = "Default Scenario",
                Description = "Default Scenario",
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
            ScenarioList.Add(scenario10);

            var scenario11 = new Scenario()
            {
                Id = 11,
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
            ScenarioList.Add(scenario11);

            var scenario12 = new Scenario()
            {
                Id = 12,
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
            ScenarioList.Add(scenario12);

            var scenario13 = new Scenario()
            {
                Id = 13,
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
            ScenarioList.Add(scenario13);

            var scenario14 = new Scenario()
            {
                Id = 14,
                Name = "Default Scenario",
                Description = "Default Scenario",
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
                    new int?[] { null,null,9,9,null,null,9,9,null,null, },
                    new int?[] { null,9,null,null,null,null,null,null,null,9, },
                    new int?[] { 9,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,6,7,8,8,7,6,null,null, },
                    new int?[] { null,6,6,null,null,null,null,null,6,6, },
                    new int?[] { 6,null,null,null,null,null,null,null,null,6, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 9, Name = "Wooden Palisade", Color = new Color(0f, 0f, 0.78431374f) },
                   new Objective() { Id = 6, Name = "Wooden Walls", Color = new Color(0.78431374f, 0f, 0f) },
                   new Objective() { Id = 7, Name = "Wooden Towers", Color = new Color(0.5882353f, 0.43137255f, 0.19607843f) },
                   new Objective() { Id = 8, Name = "Wooden Gate", Color = new Color(0f, 0.78431374f, 0f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 4, Name = "Clan-Hall Fortifications", Description = "At the start of the scenario, deploy <b>Wooden Walls, Wooden Towers</b> and <b>Wooden Gates</b> for player 1 in the indicated tiles. Also deploy <b>Wooden Palisade</b> for player 2 in the indicated tiles" },
                },
            };
            ScenarioList.Add(scenario14);

            var scenario15 = new Scenario()
            {
                Id = 15,
                Name = "Default Scenario",
                Description = "Default Scenario",
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
            ScenarioList.Add(scenario15);

            var scenario16 = new Scenario()
            {
                Id = 16,
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
                    new int?[] { 10,10,10,null,null,null,null,null,null,null, },
                    new int?[] { 10,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 10,null,null,null,10,10,null,null,null,null, },
                    new int?[] { 10,null,null,10,null,10,null,null,null,null, },
                    new int?[] { 10,10,null,null,null,null,null,null,null,10, },
                    new int?[] { 10,null,null,null,null,null,null,null,null,10, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,10,null,null,null,null, },
                    new int?[] { 10,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 10,null,null,null,null,null,null,null,null,10, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 10, Name = "Flaming Grounds", Color = new Color(0.78431374f, 0f, 0f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 5, Name = "Eternal Flames", Description = "Whenever a unit enters or starts their turn in a Flaming Grounds tile, deal 3 damage to it." },
                },
            };
            ScenarioList.Add(scenario16);

            var scenario17 = new Scenario()
            {
                Id = 17,
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
            ScenarioList.Add(scenario17);

            var scenario18 = new Scenario()
            {
                Id = 18,
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
            ScenarioList.Add(scenario18);

            var scenario19 = new Scenario()
            {
                Id = 19,
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
            ScenarioList.Add(scenario19);

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
            map9.Scenarios = new List<Scenario> { scenario10 };
            map10.Scenarios = new List<Scenario> { scenario11 };
            map11.Scenarios = new List<Scenario> { scenario12 };
            map12.Scenarios = new List<Scenario> { scenario13 };
            map13.Scenarios = new List<Scenario> { scenario14 };
            map14.Scenarios = new List<Scenario> { scenario15 };
            map15.Scenarios = new List<Scenario> { scenario16 };
            map16.Scenarios = new List<Scenario> { scenario17 };
            map17.Scenarios = new List<Scenario> { scenario18 };
            map18.Scenarios = new List<Scenario> { scenario19 };

            scenario6.Map = map5;
            scenario7.Map = map6;
            scenario8.Map = map7;
            scenario9.Map = map8;
            scenario10.Map = map9;
            scenario11.Map = map10;
            scenario12.Map = map11;
            scenario13.Map = map12;
            scenario14.Map = map13;
            scenario15.Map = map14;
            scenario16.Map = map15;
            scenario17.Map = map16;
            scenario18.Map = map17;
            scenario19.Map = map18;

            campaign2.Scenarios = new List<Scenario> { scenario6, scenario7, scenario8, scenario9 };
        }
    }
}
namespace CategoryEnums
{
    public enum MapImageTags
    {
        Default, Farmland, ForestTrail, KyravorsGrave, MountainPass, NorthernColony, ProvingGrounds, RiverCrossing, RoktarrClanHall, Sandbox, ShrineofSecarr, TheBurnedGrove, UntovanBarrows, VolcanicForge, WastelandPath
    }
}
