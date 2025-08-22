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

        #region Getters

        public List<Astronaut> GetCurrentCrew() => currentCrew;
        public int GetCrewCapacity() => crewCapacity;
        public double GetStoredPayload() => storedPayload;
        public double GetPayloadCapacity() => payloadCapacity;
        public List<Spacecraft> GetDockedSpacecraft() => dockedSpacecraft;
        public int GetNumberOfDockingPorts() => numberOfDockingPorts;

        public Spacestation(string name, int orbitAltitude, double payloadCapacity, int crewCapacity, int numberOfDockingPorts, double transferDeltaV, double deorbitDeltaV)
        {

        }

        #endregion

        public void AddCrew(List<Astronaut> crew)
        {
            throw new NotImplementedException();
        }

        public void AddPayload(double mass)
        {
            throw new NotImplementedException();
        }

        public int CalculateNumberOfOrbits()
        {
            throw new NotImplementedException();
        }

        public void DockSpacecraft(Spacecraft spacecraft)
        {
            throw new NotImplementedException();
        }

        public void RemoveCrew(List<Astronaut> crew)
        {
            throw new NotImplementedException();
        }

        public void RemovePayload(double mass)
        {
            throw new NotImplementedException();
        }

        public void UndockSpacecraft(Spacecraft spacecraft)
        {
            throw new NotImplementedException();
        }



    }
}
