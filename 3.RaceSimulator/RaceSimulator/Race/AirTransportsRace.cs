using RaceSimulator.Transport;
using System.Collections.Generic;

namespace RaceSimulator.Race
{
    public class AirTransportsRace : Race<AirTransport>
    {
        public AirTransportsRace(List<AirTransport> transportsList, double distance) :
            base(transportsList, distance) {}
        public AirTransportsRace(double distance) :
            base(distance) {}
        
        protected override string Type {get => "air";}
    }
}