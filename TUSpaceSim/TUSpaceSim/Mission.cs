using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSpaceSim
{
    internal class Mission : IComparable<Mission>
    {
        private List<Astronaut> assignedCrew;
        private Spacecraft assignedSpacecraft;
        private int crewSize;
        private MissionDestination destination;
        private bool isManned;
        private DateTime launchDate;
        private string launchSite;
        private string missionId;
        private string missionName;
        private double payload;
        private int plannedDuration;
        private DateTime plannedUndockingOrDeorbit;
        private string responsibleAgency;
        private MissionStatus status;

        public Mission(string missionId, string missionName, string responsibleAgency, DateTime launchDate, int plannedDuration, string launchSite, MissionDestination destination, double payload, bool isManned, List<Astronaut> assignedCrew)
        {

        }

        #region Getters & Setters

        public List<Astronaut> GetAssignedCrew() => assignedCrew;
        public Spacecraft GetAssignedSpacecraft() => assignedSpacecraft;
        public int GetCrewSize() => crewSize;
        public MissionDestination GetDestination() => destination;
        public bool IsManned() => isManned;
        public DateTime GetLaunchDate() => launchDate;
        public string GetLaunchSite() => launchSite;
        public string GetMissionId() => missionId;
        public string GetMissionName() => missionName;
        public double GetPayload() => payload;
        public int GetPlannedDuration() => plannedDuration;
        public DateTime GetPlannedUndockingOrDeorbit() => plannedUndockingOrDeorbit;
        public string GetResponsibleAgency() => responsibleAgency;

        public void SetAssignedSpacecraft(SpacecraftStatus s) => assignedSpacecraft = s;
        public void SetMissionStatus(MissionStatus s) => status = s;

        #endregion

        public int CompareTo(Mission other)
        {
            throw new NotImplementedException();
        }

        public void PrintInformation() 
        {
            throw new NotImplementedException();
        }
    }
}
