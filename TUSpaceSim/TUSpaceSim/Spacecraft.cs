using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSpaceSim
{
    internal class Spacecraft
    {
        private string agency;
        private List<Astronaut> assignedCrew;
        private int crewCapacity;
        private double currentPayload;
        private double exhaustVelocity;
        private double fuelCapacity;
        private bool isManned;
        private double launchMass;
        private string launchVehicle;
        private string manufacturer;
        private int maxMissions;
        private int numberOfMissions;
        private double payloadCapacity;
        private string spacecraftId;
        private string spacecraftType;
        private SpacecraftStatus status;
        private double timeToParkingOrbit;

        public Spacecraft(string spacecraftId, string spacecraftType, string manufacturer, string agency, string launchVehicle, double launchMass, double timeToParkingOrbit, int crewCapacity, double payloadCapacity, int maxMissions, double fuelCapacity, double exhaustVelocity)
        {
            
        }

        #region Getters & Setters

        public string GetAgency() => agency;
        public int CrewCapacity() => crewCapacity;
        public double GetCurrentPayload() => currentPayload;
        public bool IsManned() => isManned;
        public double GetPayloadCapacity() => payloadCapacity;
        public string GetSpacecraftId() => spacecraftId;
        public string GetSpacecraftType() => spacecraftType;
        public double GetTimeToParkingOrbit() => timeToParkingOrbit;

        public void SetSpacecraftStatus(SpacecraftStatus s) => status = s;

        #endregion

        public void AddCrew(List<Astronaut> crew) 
        {
            throw new NotImplementedException();
        }

        public void AddPayload(double p)
        { 
            throw new NotImplementedException(); 
        }

        public double CalculateFuelConsumption(double deltaV) 
        {
            throw new NotImplementedException();
        }

        public void PrintInformation() 
        {
            throw new NotImplementedException();
        }

        public void RemoveCrew()
        {
            throw new NotImplementedException();
        }

        public void RemovePayload()
        {
            throw new NotImplementedException();
        }

        public void UpdateSpacecraftUsage()
        {
            throw new NotImplementedException();
        }
    }
}
