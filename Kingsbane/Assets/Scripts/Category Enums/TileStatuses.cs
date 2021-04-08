using System.ComponentModel;

namespace CategoryEnums
{
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
