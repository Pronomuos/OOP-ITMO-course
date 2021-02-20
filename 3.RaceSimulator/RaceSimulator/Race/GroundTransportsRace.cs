using RaceSimulator.Transport;
using System.Collections.Generic;

namespace RaceSimulator.Race
{
    public class GroundTransportsRace : Race<GroundTransport>
    {
        public GroundTransportsRace(List<GroundTransport> transportsList, double distance) :
            base(transportsList, distance) {}
        public GroundTransportsRace(double distance) :
            base(distance) {}
        
        protected override string Type {get => "ground";}

    }
}