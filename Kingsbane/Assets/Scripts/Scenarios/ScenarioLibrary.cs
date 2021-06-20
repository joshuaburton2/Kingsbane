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
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Difficult,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular, },
                    new TerrainTypes[] { TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Obstacle,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Difficult, },
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
                    new TerrainTypes[] { TerrainTypes.Difficult,TerrainTypes.Difficult,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Regular,TerrainTypes.Impassable,TerrainTypes.Regular, },
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
                Description = @"",
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
                Description = @"",
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
                Description = @"",
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
                   new Rule() { Id = 3, Name = "Hidden Alcove", Description = @"The last player to occupy the objective tile for the Hidden Alcove owns it. Whoever owns the Hidden Alcove can deploy their units in adjacent tiles" },
                },
            };
            ScenarioList.Add(scenario8);

            var scenario9 = new Scenario()
            {
                Id = 9,
                Name = "Default Scenario",
                Description = @"",
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
                Description = @"Default Scenario",
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
                Description = @"",
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
                Description = @"",
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
                Description = @"",
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
                Description = @"Default Scenario",
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
                   new Rule() { Id = 4, Name = "Clan-Hall Fortifications", Description = @"At the start of the scenario, deploy <b>Wooden Walls, Wooden Towers</b> and <b>Wooden Gates</b> for player 1 in the indicated tiles. Also deploy <b>Wooden Palisade</b> for player 2 in the indicated tiles" },
                   new Rule() { Id = 13, Name = "Charging Power", Description = @"Mogris cannot move until the start of round 8 as they ready their powers" },
                   new Rule() { Id = 15, Name = "Hold Out", Description = @"If the player can survive until the end of round 12 and prevent enemy units reaching the streets, the player wins the scenario." },
                   new Rule() { Id = 16, Name = "Defend the City", Description = @"If 8 enemy units (other than their hero) reach the city streets tiles, they lose the scenario. Once an enemy unit enters these tiles, they are removed from the field. If no enemy units reach these tiles in the time limit, the player completes the bonus objective." },
                },
            };
            ScenarioList.Add(scenario14);

            var scenario15 = new Scenario()
            {
                Id = 15,
                Name = "Default Scenario",
                Description = @"Default Scenario",
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
                Description = @"",
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
                   new Rule() { Id = 5, Name = "Eternal Flames", Description = @"Whenever a unit enters or starts their turn in a Flaming Grounds tile, deal 3 damage to it." },
                },
            };
            ScenarioList.Add(scenario16);

            var scenario17 = new Scenario()
            {
                Id = 17,
                Name = "Default Scenario",
                Description = @"",
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
                Description = @"",
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
                Description = @"",
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

            var scenario26 = new Scenario()
            {
                Id = 26,
                Name = "Caravan Ambush",
                Description = @"After travelling through the Wastes, you come across a Roktarr caravan under attack by marauding beasts. Taking it upon yourself to help, you rush to the aid of the caravan.",
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
                    new int?[] { null,null,null,null,11,11,11,null,null,null, },
                    new int?[] { null,null,null,11,null,null,11,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 11, Name = "Caravans", Color = new Color(0.78431374f, 0f, 0f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 6, Name = "Scare the Monsters", Description = @"If 6 enemy beast units die, the player wins" },
                   new Rule() { Id = 7, Name = "Roktarr Convoy", Description = @"At the start of the scenario, deploy five Caravan units on the relevant tiles under the player’s control. If all five of them die, the player loses. If the player ends the scenario with all five caravans alive, they complete the bonus objective" },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(84),
            };
            ScenarioList.Add(scenario26);

            var scenario27 = new Scenario()
            {
                Id = 27,
                Name = "Prove Your Worth!",
                Description = @"After aiding the Roktarr caravan, you are bought before the Elders and offered a place in the clan. But first, you must be tested to see if you are worthy to join their ranks, facing off against one of the Elders in their Proving Grounds to show your strength.",
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
                    new int?[] { null,null,null,null,12,12,null,null,null,null, },
                    new int?[] { null,null,null,null,12,12,12,null,null,null, },
                    new int?[] { null,null,null,null,12,12,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 12, Name = "Totem Pole", Color = new Color(0.78431374f, 0.78431374f, 0f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 8, Name = "Capture the Pole", Description = @"Whenever a unit moves into the Totem Pole tiles, if the owner of the unit has more units in the tiles than the other player, that player will capture the totem pole. At the start of the scenario set a counter to 5. At the end of each turn, if player 1 controls the totem pole, reduce the counter by 1. Once the counter reaches 0, player 1 completes the scenario. If player 1 captures the totem pole and does not lose it before the end of the scenario, they complete the bonus objective." },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(85),
            };
            ScenarioList.Add(scenario27);

            var scenario28 = new Scenario()
            {
                Id = 28,
                Name = "Settler Invasion",
                Description = @"Now a formal member of the Roktarr, you must participate in your first task to aid the clan- eliminating a newly founded Imperial colony on their southern borders. Travelling to the border, you must force the Imperials out and maintain freedom for your new-found clan.",
                DeploymentMap = new int?[][]
                {
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,1,1,1,null,null,null,null,null,null, },
                    new int?[] { null,null,1,1,1,null,null,null,null,null, },
                    new int?[] { null,1,1,1,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,0,0,0,0,0,0,0,0,0, },
                },
                ObjectivesMap = new int?[][]
                {
                    new int?[] { 15,16,16,16,16,15,13,13,null,13, },
                    new int?[] { 16,null,null,null,16,null,null,null,null,null, },
                    new int?[] { null,null,null,null,14,null,null,null,null,null, },
                    new int?[] { 16,null,null,null,16,null,null,17,null,null, },
                    new int?[] { 15,16,16,16,16,15,null,null,null,null, },
                    new int?[] { null,null,null,null,null,13,13,null,13,13, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 15, Name = "Wooden Towers", Color = new Color(0f, 0.78431374f, 0f) },
                   new Objective() { Id = 16, Name = "Wooden Walls", Color = new Color(0.78431374f, 0f, 0f) },
                   new Objective() { Id = 13, Name = "Pallisade Walls", Color = new Color(0f, 0f, 0.78431374f) },
                   new Objective() { Id = 14, Name = "Wooden Gate", Color = new Color(0f, 0.78431374f, 0.78431374f) },
                   new Objective() { Id = 17, Name = "Town Square", Color = new Color(0.78431374f, 0.78431374f, 0f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 9, Name = "Forward Deployment", Description = @"Whoever has occupied the square last controls it. If the enemy control’s the square, they can deploy units in adjacent tiles. At the start of the game, the enemy gains control of the town square." },
                   new Rule() { Id = 10, Name = "Colony Fortress", Description = @"At the start of the scenario, deploy Wooden Walls, Wooden Towers, Palisade Walls and Wooden Gate on the indicated tiles. " },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(86),
            };
            ScenarioList.Add(scenario28);

            var scenario29 = new Scenario()
            {
                Id = 29,
                Name = "Traitors in Our Midst",
                Description = @"Mogris, the newly declared King of the Wastes, has turned his eye toward the Roktarr, sending an emissary to demand their fealty. You travel to meet them on neutral ground in the forests of the Southern Wastes, aiding and protecting the representatives of the Roktarr. Despite the supposed treaty in place, something feels off about the negotiation, and you had best have your guard up.",
                DeploymentMap = new int?[][]
                {
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 1,1,null,null,null,null,null,null,null,null, },
                    new int?[] { 1,1,null,null,null,null,null,null,null,null, },
                    new int?[] { 1,1,null,null,null,null,null,null,0,0, },
                    new int?[] { 1,1,null,null,null,null,null,0,0,0, },
                    new int?[] { null,null,null,null,null,null,null,null,0,0, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                ObjectivesMap = new int?[][]
                {
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,18,18, },
                    new int?[] { null,null,null,null,null,null,null,18,18,18, },
                    new int?[] { null,null,null,null,null,null,null,null,18,18, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 18, Name = "Roktarr Camp", Color = new Color(0f, 0.78431374f, 0f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 11, Name = "Protect the Elders", Description = @"At the start of the scenario, set a counter to 5. At the end of the enemy’s turn, reduce the counter by the number of their units in the Roktarr camp. If this counter is reduced to 0 or below, the player loses the scenario." },
                   new Rule() { Id = 12, Name = "Clear the Woods", Description = @"After 8 or more units of the enemy have died, the player wins the scenario. If one of those units is Kolvar, the player completes the bonus objective." },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(87),
            };
            ScenarioList.Add(scenario29);

            var scenario30 = new Scenario()
            {
                Id = 30,
                Name = "The Last Stand",
                Description = @"With word coming from your scouts that Mogris is marching on the Roktarr, you have rushed back to the Clan-Hall to aid in its defense. But the army of Mogris is greater than was expected, and his powers go beyond what even rumor has said, and you look to be soon overwhelmed…",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 1,1,1,1,1,1,1,1,1,1, },
                    new int?[] { 1,1,null,null,null,null,null,null,1,1, },
                    new int?[] { 1,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,0,0,null,null,0,null,null,0,0, },
                    new int?[] { 0,null,null,null,0,0,null,null,0,0, },
                },
                ObjectivesMap = new int?[][]
                {
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,19,19,null,null,19,19,null,null, },
                    new int?[] { null,19,null,null,null,null,null,null,null,19, },
                    new int?[] { 19,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,22,21,20,20,21,22,null,null, },
                    new int?[] { null,22,22,null,null,null,null,null,22,22, },
                    new int?[] { 22,null,null,null,null,null,null,null,null,22, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 19, Name = "Pallisade Walls", Color = new Color(0.78431374f, 0.78431374f, 0f) },
                   new Objective() { Id = 22, Name = "Wooden Walls", Color = new Color(0.78431374f, 0f, 0f) },
                   new Objective() { Id = 21, Name = "Wooden Towers", Color = new Color(0f, 0.78431374f, 0f) },
                   new Objective() { Id = 20, Name = "Wooden Gates", Color = new Color(0f, 0f, 0.78431374f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 13, Name = "Charging Power", Description = @"Mogris cannot move until the start of round 8 as they ready their powers" },
                   new Rule() { Id = 14, Name = "Clan-Hall Fortifications", Description = @"At the start of the scenario deploy Wooden Walls, Wooden Towers and Wooden Gates for player 1 in the indicated tiles. Also deploy Wooden Palisade for player 2 in the indicated tiles. " },
                   new Rule() { Id = 15, Name = "Hold Out", Description = @"If the player can survive until the end of round 12 and prevent enemy units reaching the streets, the player wins the scenario." },
                   new Rule() { Id = 16, Name = "Defend the City", Description = @"If 8 enemy units (other than their hero) reach the city streets tiles, they lose the scenario. Once an enemy unit enters these tiles, they are removed from the field. If no enemy units reach these tiles in the time limit, the player completes the bonus objective." },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(88),
            };
            ScenarioList.Add(scenario30);

            var scenario31 = new Scenario()
            {
                Id = 31,
                Name = "Shadowy Burial",
                Description = @"The loss of their Clan-Hall has devastated the Roktarr, but their spirits are not yet broken. For it is believed that they know of a way to undo Mogris’ cursed powers, a cursed, but powerful item, the skull of the ancient Shadow Dragon, Kyravor, who devastated the Wastes long ago in its wrath. However, the mask has been broken into pieces and scattered throughout the Grey Wastes. The first piece is found in the Untovan Barrows, where shadowy creatures lurk and lie in waiting.",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 0,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,null,null,null,null,null,null,null,1,null, },
                    new int?[] { 0,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 0,null,null,null,null,null,null,null,null,null, },
                },
                ObjectivesMap = new int?[][]
                {
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,23,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,23,null,23,null,null, },
                    new int?[] { null,null,null,23,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,23,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,23,null, },
                    new int?[] { null,null,null,null,null,23,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,23,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 23, Name = "Barrows", Color = new Color(0.39215687f, 0.39215687f, 0.39215687f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 17, Name = "Cleanse the Barrows", Description = @"If the player kills the enemy hero, they complete the bonus objective" },
                   new Rule() { Id = 18, Name = "Mask Heist", Description = @"The unit which uncovered the mask is carrying it and must return to the deployment zone. If the unit dies, the mask is dropped on the ground and is picked up by a friendly unit if they enter the tile (the enemy cannot pick up the mask, but can enter the tile to prevent it from being picked up). Once a unit carrying the mask has returned to the standard deployment zone, the player wins the game." },
                   new Rule() { Id = 19, Name = "Search for the Mask", Description = @"There are 8 Barrows tiles on the map. The player can move their units into these tiles and use their action to search it. At which point, roll a result between 1 and 4 and add the number of previously searched Barrows, with the roll giving the following results:
- 1-2: Blessed Barrow, Restore 2 Health to the unit
-3-5: Haunted Barrow, Deal 2 damage to the unit
- 6: Wealthy Barrow: Draw a card
- 7: Cursed Barrow, Destroy the minion, or redeploy the hero
- 8+ Masked Barrow, Recover the Mask" },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(89),
            };
            ScenarioList.Add(scenario31);

            var scenario32 = new Scenario()
            {
                Id = 32,
                Name = "Tree Inferno",
                Description = @"With the first piece of the mask in their hands, the hero now searches for the second. Rumor has it that the second piece is hidden away within the Burned Grove, the home of the Volkar Clan who resisted Kyravor. Despite its discovery, recovering the mask looks to be a difficult task, for the last surviving druids of the Volkar protect it still, and will not allow anyone to take it unless they can prove their worth. ",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 1,null,null,null,null,null,null,1,1,1, },
                    new int?[] { 1,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 1,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,0,0,null,null,null,null, },
                    new int?[] { null,null,null,0,0,0,null,null,null,null, },
                    new int?[] { null,null,null,null,0,0,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,1, },
                    new int?[] { null,null,null,null,null,null,null,null,null,1, },
                    new int?[] { 1,1,1,null,null,null,null,null,null,1, },
                },
                ObjectivesMap = new int?[][]
                {
                    new int?[] { 24,24,24,null,null,null,null,null,null,null, },
                    new int?[] { 24,null,null,null,25,null,null,null,null,null, },
                    new int?[] { 24,null,null,25,24,24,25,null,null,null, },
                    new int?[] { 24,null,null,24,null,24,null,null,null,null, },
                    new int?[] { 24,24,null,null,null,null,null,null,null,24, },
                    new int?[] { 24,null,null,null,null,null,null,null,null,24, },
                    new int?[] { null,26,null,null,null,null,null,null,26,null, },
                    new int?[] { null,null,null,null,null,24,null,null,null,null, },
                    new int?[] { 24,null,26,null,null,null,null,26,null,null, },
                    new int?[] { 24,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 24, Name = "Flaming Grounds", Color = new Color(0.78431374f, 0f, 0f) },
                   new Objective() { Id = 25, Name = "Druidic Pillars", Color = new Color(0f, 0f, 0.78431374f) },
                   new Objective() { Id = 26, Name = "Balance Stones", Color = new Color(0f, 0.78431374f, 0f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 20, Name = "Restore Balance", Description = @"At the start of the scenario deploy 4 Druidic Pillars on the indicated tiles under the control of player 1 and set the middle pillars health to 1. On each turn, the player can move a unit adjacent to the Balance Stones and use their action to change the state of the pillars. Each stone will deal a specified amount of damage to one of the pillars. Damaging a pillar heals the adjacent pillars for the same amount. If the pillar is reduced below 1 health, instead of dying, its health is set back up to its max and any remaining damage is applied. If the same stone is activated twice in a row, its effect does not occur. If the pillars all read the same number of health, the player wins the scenario. If the player does not reset the scenario before completion, they complete the bonus objective. The effect of the stones from left to right are as follows:
- Damage central pillar by 1
- Resets the pillars to their default state (3, 1, 3)
- Damages right pillar by 1
- Damages left pillar by 2" },
                   new Rule() { Id = 21, Name = "Eternal Flames", Description = @"Whenever a unit enters or starts their turn in a Flaming Grounds tile, deal 3 damage to it. Player 2’s Treant units are immune to this effect." },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(90),
            };
            ScenarioList.Add(scenario32);

            var scenario33 = new Scenario()
            {
                Id = 33,
                Name = "The Dragon's Grave",
                Description = @"The location of the last piece of the mask is well known, but it is in such a dangerous location that none have dared to claim it- the grave of Kyravor. These lands have long been corrupted and the fierce guardians of the grave will do whatever it takes to defend the dragon’s resting place.",
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
                   new Rule() { Id = 22, Name = "Cursed Guardian", Description = @"If player 1 permanently kills player 2’s hero, they win the scenario. If they kill the hero three turns in a row after it has been redeployed, they complete the bonus objective." },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(91),
            };
            ScenarioList.Add(scenario33);

            var scenario34 = new Scenario()
            {
                Id = 34,
                Name = "Into the Flames",
                Description = @"With the pieces of the mask in the hero’s hands, they require a means of bringing the pieces back together- but the power required to do so is far greater than that of a mere smithy. It is believed that only the mythical forge within the heart of the volcano Sithrimus can do so, but its guardians would surely not simply allow the power of Kyravor to be bought back into the world.",
                DeploymentMap = new int?[][]
                {
                    new int?[] { 0,0,0,0,0,0,0,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,1,1,null,null,null,null,null, },
                    new int?[] { null,null,null,null,1,1,null,null,null,null, },
                    new int?[] { null,null,null,null,1,1,null,null,null,null, },
                    new int?[] { null,null,null,null,1,1,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,0,0,0,0,0,0,0, },
                },
                ObjectivesMap = new int?[][]
                {
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { 27,null,null,null,null,null,27,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,27, },
                    new int?[] { null,null,null,27,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 27, Name = "Forge Guardians", Color = new Color(0.78431374f, 0f, 0f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 23, Name = "Forge Guardians", Description = @"At the start of the scenario, deploy four Forge Guardians units in the indicated tiles. Give each unit one of the following keywords, each applying to the units from left to right: Spellshield, Deadly, Warden, Unleash. Once two of Forge Guardians and Forgemaster Xeron have been destroyed, the player wins the scenario. If the player kills all four Guardians before killing Xeron, they complete the bonus objective." },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(92),
            };
            ScenarioList.Add(scenario34);

            var scenario35 = new Scenario()
            {
                Id = 35,
                Name = "Forbidden Ritual",
                Description = @"With the mask forged, it is time to finally take on Mogris and free the wastes from his corrupting influence. The Roktarr scouts have reported that he has taken his forces deep into the hidden places of the wastes, to a mysterious shrine with a dark corruption lingering over it. However his strange relationship with the void has shed a lot of his old followers, and only those tied to the Abyss themselves still stand with him. Whatever his reasons for travelling to the shrine, you are sure they cannot be for the good of this world, and you must rush to stop him in time.",
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
                    new int?[] { 28,null,null,null,null,null,null,null,null,28, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,28,null,null,null,null,null,null,28,null, },
                    new int?[] { null,null,28,null,null,null,28,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                    new int?[] { null,null,null,null,null,null,null,null,null,null, },
                },
                Objectives = new List<Objective>()
                {
                   new Objective() { Id = 28, Name = "Ritual Pillars", Color = new Color(0.78431374f, 0f, 0.78431374f) },
                },
                Rules = new List<Rule>()
                {
                   new Rule() { Id = 26, Name = "Destroy the Conduit", Description = @"If the enemy’s hero dies before they complete the ritual, the player wins the scenario. " },
                   new Rule() { Id = 27, Name = "The Dark Ritual", Description = @"At the start of the scenario, set a counter to 8. At the start of the enemy’s turn, reduce the counter by 1. If the counter reaches 0, the player loses the game as Mogris completes the ritual to summon Se’Carr." },
                   new Rule() { Id = 28, Name = "Ritual Pillars", Description = @"At the start of the scenario, deploy Ritual Pillars under the enemy’s control in each of the indicated tiles. Whenever one of these pillars is destroyed, increase the ritual counter by 1." },
                   new Rule() { Id = 29, Name = "Dragon's Mask", Description = @"The player’s hero can target and damage Mogris with attacks, items and spells. If your hero has damaged Mogris by any means, he is no longer Indestructible until the start of your next turn." },
                },
                EnemyDeck = GameManager.instance.deckManager.GetNPCDeck(93),
            };
            ScenarioList.Add(scenario35);

            var campaign3 = new Campaign()
            {
                Id = 3,
                Name = "Freedom for the Wastes",
                Description = "The Grey Wastes are a harsh land- and its people even harsher. While many of these people are seen as barbaric, those who know them know them as a people of honour, and those who desire freedom above all else. You have come to these lands seeking this freedom, only to find that it has been shattered by a marauding warlord, one who seeks to use dark powers to claim Kingship over the Wastes. Thrust into the middle of this conflict, you must use your skills to keep the people of the Wastes free and defend the honour of this land.",
            };
            CampaignList.Add(campaign3);

            map5.Scenarios = new List<Scenario> { scenario6 };
            map6.Scenarios = new List<Scenario> { scenario7 };
            map7.Scenarios = new List<Scenario> { scenario8 };
            map8.Scenarios = new List<Scenario> { scenario9 };
            map9.Scenarios = new List<Scenario> { scenario10, scenario26 };
            map10.Scenarios = new List<Scenario> { scenario11, scenario27 };
            map11.Scenarios = new List<Scenario> { scenario12, scenario28 };
            map12.Scenarios = new List<Scenario> { scenario13, scenario29 };
            map13.Scenarios = new List<Scenario> { scenario14, scenario30 };
            map14.Scenarios = new List<Scenario> { scenario15, scenario31 };
            map15.Scenarios = new List<Scenario> { scenario16, scenario32 };
            map16.Scenarios = new List<Scenario> { scenario17, scenario33 };
            map17.Scenarios = new List<Scenario> { scenario18, scenario34 };
            map18.Scenarios = new List<Scenario> { scenario19, scenario35 };

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
            scenario26.Map = map9;
            scenario27.Map = map10;
            scenario28.Map = map11;
            scenario29.Map = map12;
            scenario30.Map = map13;
            scenario31.Map = map14;
            scenario32.Map = map15;
            scenario33.Map = map16;
            scenario34.Map = map17;
            scenario35.Map = map18;

            campaign3.Scenarios = new List<Scenario> { scenario26, scenario27, scenario28, scenario29, scenario30, scenario31, scenario32, scenario33, scenario34, scenario35 };
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
