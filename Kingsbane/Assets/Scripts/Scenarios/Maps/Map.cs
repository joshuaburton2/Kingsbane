﻿using CategoryEnums;
using System.Collections.Generic;

public class Map
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ColourMapName { get; set; }
    public TerrainTypes[][] TerrainMap { get; set; }
    public List<Scenario> Scenarios { get; set; }
}
