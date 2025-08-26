using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TUSpaceSim
{
    internal class Astronaut
    {
        private string agency;
        private string astronautId;
        private DateTime birthday;
        private string name;
        private string nationality;
        private int numberOfEVAs;
        private int numberOfMissions;
        private int totalTimeInSpace;
        private double weight;

        public Astronaut(string astronautId, string name, DateTime birthday, string nationality, string agency, double weight)
        {
            this.astronautId = astronautId;
            this.name = name;
            this.birthday = birthday;
            this.nationality = nationality;
            this.agency = agency;
            this.weight = weight;
        }

        #region Getters & Setters

        public string GetAstronautId() => astronautId;
        public string GetName() => name;
        public double GetWeight() => weight;

        #endregion

        public void PrintInformation()
        {
            Console.WriteLine($"| {astronautId,-12} | {name,-25} | {birthday:dd:MM:yyyy} | {nationality} | {agency,-10} | {weight:F1} kg | {numberOfMissions,8} | {totalTimeInSpace,8} days |");
        }

        public void UpdateNumberOfMissionsAndTotalTimeInSpace(int days)
        {
            numberOfMissions++;
            totalTimeInSpace += days;
        }
    }
}
