using RaceSimulator.Transport;
using System.Collections.Generic;

namespace RaceSimulator.Race
{
    public class AllTransportsRace : Race<ITransport>
    {
        public AllTransportsRace(List<ITransport> transportsList, double distance) :
            base(transportsList, distance) {}
        public AllTransportsRace(double distance) :
            base(distance) {}
        
        protected override string Type {get => "common";}

    }
}