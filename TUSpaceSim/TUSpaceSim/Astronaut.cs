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
            
        }

        #region Getters & Setters

        public string GetAstronautId() => astronautId;
        public string GetName() => name;
        public double GetWeight() => weight;

        #endregion

        public void PrintInformation()
        {
            throw new NotImplementedException();
        }

        public void UpdateNumberOfMissionsAndTotalTimeInSpace(int days)
        {
            throw new NotImplementedException();
        }
    }
}
