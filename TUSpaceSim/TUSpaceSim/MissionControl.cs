using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSpaceSim
{
    internal class MissionControl
    {
        private List<Mission> allMissions;
        private List<Mission> completedMissions;
        private List<Mission> currentMissions;
        private List<Mission> plannedMissions;
        private List<Astronaut> registeredAstronauts;
        private List<MissionDestination> registeredDestinations;
        private List<Spacecraft> registeredSpacecrafts;

        public MissionControl(List<MissionDestination> registeredDestinations)
        {
            
        }

        public List<Astronaut> AssignCrewToMission(string crewIds, List<Astronaut> registeredAstronauts) 
        { 
            //Param crewIds Plural als string???
            throw new NotImplementedException();
        }

        private bool CheckSpacestationCapacity(Mission mission, Spacecraft spacecraft)
        {
            throw new NotImplementedException();
        }

        private Spacecraft GetAvailableSpacecraftForMission(Mission mission)
        {
            throw new NotImplementedException(); 
        }

        public List<Astronaut> LoadAstronautsFromCSV(string path)
        {
            throw new NotImplementedException(); 
        }

        public void LoadInputFiles(string path)
        {
            throw new NotImplementedException(); 
        }

        public List<Mission> LoadPlannedMissionsFromCSV(string path, List<Astronaut> astronauts, List<MissionDestination> destinations)
        {
            //Warum in File Input FUnc zwei Listen als Param???
            throw new NotImplementedException(); 
        }

        public List<Spacecraft> LoadSpacecraftsFromCSV(string path) 
        {
            throw new NotImplementedException();
        }

        public void PrintAstronauts(List<Astronaut> astronauts)
        {
            throw new NotImplementedException(); 
        }

        public void PrintMissions(List<Mission> missions) 
        {
            throw new NotImplementedException();
        }

        public void PrintSpacecrafts(List<Spacecraft> spacecrafts)
        {
            throw new NotImplementedException(); 
        }

        public void PrintSpacestationStatus(Spacestation spacestation)
        {
            throw new NotImplementedException();
        }

        public bool StartNextMission()
        {
            throw new NotImplementedException();
        }

        public void UpdateCurrentMissions(DateTime now) 
        {
            throw new NotImplementedException(); 
        }

        public void UserInteraction()
        {
            throw new NotImplementedException();
        }
    }
}
