using System;

namespace RaceSimulator.Transport.AirTypes
{
    public class Broomstick : AirTransport
    {
        public Broomstick()
        {
            Speed = 20.0;
            TypeName = "Broomstick";
        }

        protected override double FindReducedDistance(double distance)
            =>  distance - (distance * (Math.Floor(distance / 1000) / 100));
        

    }
}