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
        Operational,
        InOrbit,
        Docked,
        Damaged,
        Retired
    }

    public enum MissionStatus
    {
        Planned,
        Ongoing,
        Completed,
        Cancelled
    }
    #endregion
}
