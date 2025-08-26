using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSpaceSim
{
    internal abstract class MissionDestination
    {
        private const double EARTH_MASS = 5.9722e24;
        private const double EARTH_RADIUS = 637100;
        private const double G = 6.673e-11;

        protected string name;
        private double orbitAltitude;
        private double orbitalPeriod;
        private double deorbitDeltaV;
        private double transferDeltaV;

        protected MissionDestination(string name, double orbitAltitude, double transferDeltaV, double deorbitDeltaV)
        {
            this.name = name;
            this.orbitAltitude = orbitAltitude;
            this.transferDeltaV = transferDeltaV;
            this.deorbitDeltaV = deorbitDeltaV;
        }

        #region Getters

        public double GetDeorbitDeltaV() => deorbitDeltaV;
        public string GetName() => name;
        public double GetTransferDeltaV() => transferDeltaV;

        #endregion
    
        public double CalculateFlightTime(Spacecraft spacecraft)
        {
            var t1 = spacecraft.GetTimeToParkingOrbit();
            var t2 = CalculateHohmannTransferTime(EARTH_RADIUS + 200000, EARTH_RADIUS + orbitAltitude);
            var t3 = CalculateNumberOfOrbits() * CalculateOrbitalPeriod();
            return t1 + t2 + t3;
        }

        public double CalculateHohmannTransferTime(double r1, double r2)
        {
            var a = (r1 + r2) / 2;
            return Math.PI/60 * Math.Sqrt(Math.Pow(a,3)/(G*EARTH_MASS));
        }

        public virtual int CalculateNumberOfOrbits() => 0; //abstract?

        public double CalculateOrbitalPeriod()
        {
            return 2*Math.PI/60 * Math.Sqrt(Math.Pow(EARTH_RADIUS+orbitAltitude,3) / (G * EARTH_MASS));
        }
    }
}
