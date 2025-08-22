using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSpaceSim
{
    internal abstract class MissionDestination
    {
        private const double earthMass;
        private const double earthRadius;
        private const double G;

        protected string name;
        private double orbitAltitude;
        private double orbitalPeriod;
        private double deorbitDeltaV;
        private double transferDeltaV;

        protected MissionDestination(string name, double orbitAltitude, double transferDeltaV, double deorbitDeltaV)
        {
            throw new NotImplementedException();
        }

        #region Getters

        public double GetDeorbitDeltaV() => deorbitDeltaV;
        public string GetName() => name;
        public double GetTransferDeltaV() => transferDeltaV;

        #endregion
    
        public double CalculateFlightTime(Spacecraft spacecraft)
        {
            throw new NotImplementedException();
        }

        public double CalculateHohmannTransferTime(double r1, double r2)
        {
            throw new NotImplementedException();
        }

        public int CalculateNumberOfOrbits() 
        {
            throw new NotImplementedException();
        }

        public double CalculateOrbitalPeriod()
        {
            throw new NotImplementedException();
        }
    }
}
