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
            completedMissions = new List<Mission>();
            currentMissions = new List<Mission>();
        }

        public List<Astronaut> AssignCrewToMission(string crewIds, List<Astronaut> registeredAstronauts)
        {
            //Param crewIds Plural als string???
            var crew = registeredAstronauts.Where(q => crewIds.Contains(q.GetAstronautId())).ToList();
            return crew.Count > 0 ? crew : null;
        }

        //Methode gehört nicht in diese Klasse
        private bool CheckSpacestationCapacity(Mission mission, Spacecraft spacecraft)
        {
            var destination = mission.GetDestination();
            if (destination is Spacestation spacestation) 
            { 
                if (spacestation.GetDockedSpacecraft().Count == spacestation.GetNumberOfDockingPorts()) 
                {
                    //Konsolenausgabe
                    return false;
                }
                if (/*!spacecraft.IsManned() ^ */spacestation.GetCurrentCrew().Count + mission.GetCrewSize() > spacestation.GetCrewCapacity()) 
                {
                    //Konsolenausgabe
                    return false;
                }
                if (spacestation.GetStoredPayload() + spacecraft.GetCurrentPayload() > spacestation.GetPayloadCapacity()) 
                {
                    //Konsolenausgabe
                    return false;
                }
                if (spacestation.GetDockedSpacecraft().Sum(q => q.GetCrewCapacity()) + spacecraft.GetCrewCapacity() < spacestation.GetCurrentCrew().Count + mission.GetCrewSize()) 
                {
                    //Konsolenausgabe
                    return false;
                }
                return true;
            }
            return false;
        }

        private Spacecraft GetAvailableSpacecraftForMission(Mission mission)
        {
            return registeredSpacecrafts.FirstOrDefault(q =>
                q.GetSpacecraftStatus() == SpacecraftStatus.OnGround
                && q.GetAgency() == mission.GetResponsibleAgency()
                && q.IsManned() == mission.IsManned()
                && q.GetPayloadCapacity() >= mission.GetPayload()
                && (!mission.IsManned() ^ q.GetCrewCapacity() >= mission.GetCrewSize()));
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

                var assignedCrew = new List<Astronaut>();
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
            plannedMissions.Sort();
            var nextMission = plannedMissions.First();
            UpdateCurrentMissions(nextMission.GetLaunchDate());

            //Konsolenausgabe

            var spacecraftForNextMission = GetAvailableSpacecraftForMission(nextMission);
            if (spacecraftForNextMission == null)
            {
                //Konsolenausgabe: Cancelled
                nextMission.SetMissionStatus(MissionStatus.Cancelled);
                plannedMissions.Remove(nextMission);
                return false;
            }

            //Konsolenausgabe: Assigned
            spacecraftForNextMission.AddPayload(nextMission.GetPayload());
            var flightTimeInMinutes = nextMission.GetDestination().CalculateFlightTime(spacecraftForNextMission);
            var arrivalTime = nextMission.GetLaunchDate().AddMinutes(flightTimeInMinutes);

            //Konsolenausgabe: Flighttime

            var dest = nextMission.GetDestination();
            var fuelConsumptionTransfer = spacecraftForNextMission.CalculateFuelConsumption(dest.GetTransferDeltaV());
            var fuelConsumptionDeorbit = spacecraftForNextMission.CalculateFuelConsumption(dest.GetDeorbitDeltaV());
            var remainingFuel = 100 - fuelConsumptionTransfer - fuelConsumptionDeorbit;

            //Konsolenausgabe Fuel

            if (remainingFuel < 10) 
            {
                //Konsolenausgabe: Cancelled
                nextMission.SetMissionStatus(MissionStatus.Cancelled);
                plannedMissions.Remove(nextMission);
                return false;
            }

            //Konsolenausgabe ready

            if (dest is Spacestation station) 
            {
                if (!CheckSpacestationCapacity(nextMission, spacecraftForNextMission))
                {
                    nextMission.SetMissionStatus(MissionStatus.Cancelled);
                    plannedMissions.Remove(nextMission);
                    return false;
                }
                //Konsolenausgabe
            }

            nextMission.SetAssignedSpacecraft(spacecraftForNextMission);

            if (nextMission.IsManned()) 
            {
                spacecraftForNextMission.AddCrew(registeredAstronauts);
                //Konsolenausgabe
            }

            //Konsolenausgabe Clearance

            spacecraftForNextMission.SetSpacecraftStatus(SpacecraftStatus.InOrbit);
            nextMission.SetMissionStatus(MissionStatus.Ongoing);
            currentMissions.Add(nextMission);
            plannedMissions.Remove(nextMission);

            if (dest is Spacestation spacestation) 
            {
                spacestation.DockSpacecraft(spacecraftForNextMission);
                spacestation.AddPayload(spacecraftForNextMission.GetCurrentPayload());
                spacecraftForNextMission.RemovePayload();
                
                if(nextMission.IsManned()) 
                {
                    spacestation.AddCrew(nextMission.GetAssignedCrew());
                    spacecraftForNextMission.RemoveCrew();
                } 
            }

            return true;
        }

        public void UpdateCurrentMissions(DateTime now) 
        {
            var missionsToComplete = new List<Mission>();
            foreach (var mission in currentMissions) 
            {
                if (mission.GetPlannedUndockingOrDeorbit() <= now)
                    missionsToComplete.Add(mission);
            }

            if (missionsToComplete.Count == 0)
                return;

            //Konsolenausgabe

            missionsToComplete.Sort();

            foreach(var mission in missionsToComplete) 
            { 
                if (mission.GetDestination() is Spacestation spacestation) 
                { 
                    if (mission.IsManned()) 
                        spacestation.RemoveCrew(mission.GetAssignedCrew());
                    spacestation.RemovePayload(mission.GetPayload() * 0.3);
                    //Konsolenausgabe
                }
                mission.SetMissionStatus(MissionStatus.Completed);
                var spacecraft = mission.GetAssignedSpacecraft();
                spacecraft.SetSpacecraftStatus(SpacecraftStatus.OnGround);
                spacecraft.UpdateSpacecraftUsage();

                mission.GetAssignedCrew().ForEach(q => q.UpdateNumberOfMissionsAndTotalTimeInSpace(mission.GetPlannedDuration()));
                completedMissions.Add(mission);
                currentMissions.Remove(mission);
            }
        }

        public void UserInteraction()
        {
            int input;
            do
            {
                Console.WriteLine("MISSION CONTROL DASHBOARD");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Current active missions: {currentMissions.Count}");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("[1] Start next mission");
                Console.WriteLine("[2] Show planned missions");
                Console.WriteLine("[3] Show current missions");
                Console.WriteLine("[4] Show completed missions");
                Console.WriteLine("[5] Show all missions");
                Console.WriteLine("[6] Show registered astronauts");
                Console.WriteLine("[7] Show registered spacecraft");
                Console.WriteLine("[8] Show status of ISS");
                Console.WriteLine("[0] Exit program");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Selection:");

                input = int.Parse(Console.ReadLine());
                switch (input) 
                {
                    case 0: 
                        {
                            Console.WriteLine("Simulation stopped.");
                        } break;
                    case 1: 
                        {
                            if (plannedMissions.Count > 0)
                                StartNextMission();
                            else
                                Console.WriteLine("No planned missions available.");
                        } break;
                    case 2: {
                            PrintMissions(plannedMissions);
                        } break;
                    case 3: { 
                            PrintMissions(currentMissions);
                        } break;
                    case 4: { 
                            PrintMissions(completedMissions);
                        } break;
                    case 5: { 
                            PrintMissions(allMissions);
                        } break;
                    case 6: { 
                            PrintAstronauts(registeredAstronauts);
                        } break;
                    case 7: { 
                            PrintSpacecrafts(registeredSpacecrafts);
                        } break;
                    case 8: {
                            PrintSpacestationStatus(registeredDestinations.First() as Spacestation);
                        } break;
                    default: {
                            Console.WriteLine("Invalid input");
                        } break;
                }
            } while (input != 0);
        }
    }
}
