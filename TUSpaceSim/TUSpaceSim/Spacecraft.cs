using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            this.spacecraftId = spacecraftId;
            this.spacecraftType = spacecraftType;
            this.manufacturer = manufacturer;
            this.agency = agency;
            this.launchVehicle = launchVehicle;
            this.launchMass = launchMass;
            this.timeToParkingOrbit = timeToParkingOrbit;
            this.crewCapacity = crewCapacity;
            this.payloadCapacity = payloadCapacity;
            this.maxMissions = maxMissions;
            this.fuelCapacity = fuelCapacity;
            this.exhaustVelocity = exhaustVelocity;

            isManned = crewCapacity > 0;
        }

        #region Getters & Setters

        public string GetAgency() => agency;
        public int GetCrewCapacity() => crewCapacity;
        public double GetCurrentPayload() => currentPayload;
        public bool IsManned() => isManned;
        public double GetPayloadCapacity() => payloadCapacity;
        public string GetSpacecraftId() => spacecraftId;
        public SpacecraftStatus GetSpacecraftStatus() => status;
        public string GetSpacecraftType() => spacecraftType;
        public double GetTimeToParkingOrbit() => timeToParkingOrbit;

        public void SetSpacecraftStatus(SpacecraftStatus s) => status = s;

        #endregion

        public void AddCrew(List<Astronaut> crew) 
        {
            assignedCrew.AddRange(crew);
        }

        public void AddPayload(double p)
        {
            currentPayload = p;
        }

        public double CalculateFuelConsumption(double deltaV) 
        {
            var crewMass = assignedCrew.Sum(q => q.GetWeight());
            var mass = launchMass + crewMass + currentPayload;
            return (mass * (1 - Math.Exp(-deltaV / exhaustVelocity))) / fuelCapacity * 100;
        }

        public void PrintInformation() 
        {
            Console.WriteLine($"| {spacecraftId,-12} | {spacecraftType,-12} | {manufacturer, -12} | {agency, -10} | {launchVehicle,-12} | {crewCapacity, 3} | {payloadCapacity,4} | {numberOfMissions}/{maxMissions} | {status} |");
        }

        public void RemoveCrew()
        {
            //assignedCrew.RemoveRange(0, crewCapacity);
            assignedCrew = new List<Astronaut>();
        }

        public void RemovePayload()
        {
            currentPayload = 0;
        }

        public void UpdateSpacecraftUsage()
        {
            numberOfMissions++;
            if (numberOfMissions >= maxMissions) 
            {
                status = SpacecraftStatus.Retired;
                Console.WriteLine($"[RETIRED]   Spacecraft ({spacecraftId}) {spacecraftType} has reached its mission limit and is now retired.");
            }
        }
    }
}
