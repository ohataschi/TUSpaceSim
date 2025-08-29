using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
            this.registeredDestinations = registeredDestinations;
        }

        public List<Astronaut> AssignCrewToMission(string crewIds, List<Astronaut> registeredAstronauts)
        {
            //Param crewIds Plural als string???
            var crew = registeredAstronauts.Where(q => crewIds.Contains(q.GetName())).ToList();
            return crew.Count > 0 ? crew : null;
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
            path = $"{path}\\Astronauts.csv";
            if (!File.Exists(path))
            {
                Console.WriteLine("Astronauts.csv is missing!");
                return null;
            }
            
            var astronauts = new List<Astronaut>();
            foreach(var line in File.ReadAllLines(path).Skip(1)) 
            {
                var fields = line.Split(';');
                var id = fields[0];
                var name = fields[1];
                var birthday = DateTime.ParseExact(fields[2], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var nationality = fields[3];
                var agency = fields[4];
                var weight = int.Parse(fields[5]);
                astronauts.Add(new Astronaut(id, name, birthday, nationality, agency, weight));
            }
            Console.WriteLine("Astronauts.csv successfully loaded.");
            return astronauts;
        }

        public void LoadInputFiles(string path)
        {
            registeredAstronauts = LoadAstronautsFromCSV(path);
            registeredSpacecrafts = LoadSpacecraftsFromCSV(path);
            plannedMissions = LoadPlannedMissionsFromCSV(path, registeredAstronauts, registeredDestinations);
            allMissions = plannedMissions;
            Console.WriteLine($@"Imported Resources
  - Astronauts:         {registeredAstronauts.Count}
  - Spacecrafts:        {registeredSpacecrafts.Count}
  - Planned Missions:   {plannedMissions.Count}");
        }

        public List<Mission> LoadPlannedMissionsFromCSV(string path, List<Astronaut> astronauts, List<MissionDestination> destinations)
        {
            //Warum in File Input FUnc zwei Listen als Param???
            path = $"{path}\\Missions.csv";
            if (!File.Exists(path))
            {
                Console.WriteLine("Missions.csv is missing!");
                return null;
            }

            var missions = new List<Mission>();
            foreach (var line in File.ReadAllLines(path).Skip(1))
            {
                var fields = line.Split(';');
                var id = fields[0];
                var name = fields[1];
                var agency = fields[2];
                var launchDate = DateTime.ParseExact(fields[3], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                var plannedDuration = int.Parse(fields[4]);
                var launchSite = fields[5];
                var destination = registeredDestinations.FirstOrDefault(q => q.GetName() == fields[6]);
                var payload = double.Parse(fields[7]);
                var isManned = bool.Parse(fields[8]);

                List<Astronaut> assignedCrew = null;
                if (isManned)
                {
                    assignedCrew = AssignCrewToMission(fields[9], registeredAstronauts);
                }
                missions.Add(new Mission(id, name, agency, launchDate, plannedDuration, launchSite, destination, payload, isManned, assignedCrew));
            }
            Console.WriteLine("Missions.csv successfully loaded.");
            return missions;
        }

        public List<Spacecraft> LoadSpacecraftsFromCSV(string path) 
        {
            path = $"{path}\\Spacecrafts.csv";
            if (!File.Exists(path))
            {
                Console.WriteLine("Spacecrafts.csv is missing!");
                return null;
            }

            var spacecrafts = new List<Spacecraft>();
            foreach (var line in File.ReadAllLines(path).Skip(1))
            {
                var fields = line.Split(';');
                var id = fields[0];
                var type = fields[1];
                var manufacturer = fields[2];
                var agency = fields[3];
                var launchVehicle = fields[4];
                var launchMass = double.Parse(fields[5]);
                var timeToParkingOrbit = double.Parse(fields[6]);
                var crewCapacity = int.Parse(fields[7]);
                var payloadCapacity = double.Parse(fields[8]);
                var maxMissions = int.Parse(fields[9]);
                var fuelCapacity = double.Parse(fields[10]);
                var exhaustVelocity = double.Parse(fields[11]);
                spacecrafts.Add(new Spacecraft(id, type, manufacturer, agency, launchVehicle, launchMass, timeToParkingOrbit, crewCapacity, payloadCapacity, maxMissions, fuelCapacity, exhaustVelocity));
            }
            Console.WriteLine("Spacecrafts.csv successfully loaded.");
            return spacecrafts;
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
