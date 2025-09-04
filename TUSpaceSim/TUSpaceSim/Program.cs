using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUSpaceSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Simon Taschler\OneDrive\Dokumente\MBI Studiass\Inginfo 2\Basisprojekte\WS25\V2";
            var spacestation = new Spacestation("ISS", 400000, 9000, 12, 4, 150, 90);
            var destinations = new List<MissionDestination> { spacestation };
            var missionControl = new MissionControl(destinations);

            //Konsolenausgabe
            missionControl.LoadInputFiles(path);
            missionControl.UserInteraction();
        }
    }
}
