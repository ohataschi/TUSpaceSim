using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TUSpaceSim
{
    internal class Spacestation : MissionDestination
    {
        private int crewCapacity;
        private List<Astronaut> currentCrew;
        private List<Spacecraft> dockedSpacecraft;
        private int numberOfDockingPorts;
        private double payloadCapacity;
        private double storedPayload;

        public Spacestation(string name, int orbitAltitude, double payloadCapacity, int crewCapacity, int numberOfDockingPorts, double transferDeltaV, double deorbitDeltaV) : base(name, orbitAltitude, transferDeltaV, deorbitDeltaV)
        {
            this.payloadCapacity = payloadCapacity;
            this.crewCapacity = crewCapacity;
            this.numberOfDockingPorts = numberOfDockingPorts;
        }

        #region Getters

        public List<Astronaut> GetCurrentCrew() => currentCrew;
        public int GetCrewCapacity() => crewCapacity;
        public double GetStoredPayload() => storedPayload;
        public double GetPayloadCapacity() => payloadCapacity;
        public List<Spacecraft> GetDockedSpacecraft() => dockedSpacecraft;
        public int GetNumberOfDockingPorts() => numberOfDockingPorts;

        #endregion

        public void AddCrew(List<Astronaut> crew)
        {
            foreach (var astronaut in crew) 
                Console.WriteLine($"[INFO]   {astronaut.GetName()} boarded spacestation {name}");
            currentCrew.AddRange(crew);
        }

        public void AddPayload(double mass)
        {
            storedPayload += mass;
            Console.WriteLine($"[INFO]   {mass} kg of cargo transferred to spacestation {name}");
        }

        public override int CalculateNumberOfOrbits() => 
            new Random().Next(2, 5);

        public void DockSpacecraft(Spacecraft spacecraft)
        {
            dockedSpacecraft.Add(spacecraft);
            Console.WriteLine($"[DOCKED]   Spacecraft {spacecraft.GetSpacecraftType()} ({spacecraft.GetSpacecraftId()}) is now attached to spacestation {name}.");
        }

        public void RemoveCrew(List<Astronaut> crew)
        {
            foreach (var astronaut in crew) 
            {
                Console.WriteLine($"[INFO]   {astronaut.GetName()} left spacestation {name}.");
                currentCrew.Remove(astronaut);
            }
        }

        public void RemovePayload(double mass)
        {
            storedPayload -= mass;
            Console.WriteLine($"[INFO]   {mass} kg of cargo from spacestation {name} returned to earth.");
        }

        public void UndockSpacecraft(Spacecraft spacecraft)
        {
            dockedSpacecraft.Remove(spacecraft);
            Console.WriteLine($"[UNDOCKED]   Spacecraft {spacecraft.GetSpacecraftType()} ({spacecraft.GetSpacecraftId()}) left spacestation {name}.");
        }



    }
}
