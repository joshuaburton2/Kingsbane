﻿using CategoryEnums;
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
                Name = "Map 0",
                Description = "",
                ColourMapName = "Map 0 Map",
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
        }
    }
}
