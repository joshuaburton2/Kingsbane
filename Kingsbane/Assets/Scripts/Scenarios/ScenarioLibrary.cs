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
            var map0 = new Map()
            {
                Id = 0,
                Name = "Map 0",
                Description = "",
                ColourMapName = "Map 0 Map",

            };
            MapList.Add(map0);
        }
    }
}
