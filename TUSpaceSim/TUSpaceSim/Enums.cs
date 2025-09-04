using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSpaceSim
{
    #region Enums
    public enum SpacecraftStatus
    {
        OnGround,
        InOrbit,
        Docked,
        Stranded,
        Retired
    }

    public enum MissionStatus
    {
        Planned,
        Ongoing,
        Completed,
        Failed,
        Cancelled
    }
    #endregion
}
