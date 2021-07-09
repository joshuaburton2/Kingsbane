using System.ComponentModel;

namespace CategoryEnums
{
    /// <summary>
    /// 
    /// Temporary tile statuses which can be applied on the map
    /// 
    /// </summary>
    public enum TileStatuses
    {
        Survey,
        Earthquake,
        [Description("Wall Of Fire")]
        WallOfFire,
        Sanctuary,
        Consecrate,
    }
}
