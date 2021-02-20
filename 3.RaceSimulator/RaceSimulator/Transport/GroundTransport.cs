using System;

namespace RaceSimulator.Transport
{
    public abstract class GroundTransport : ITransport
    {
         public double Speed { get; set; }
         public string TypeName { get; set; }

         public double FindTime(double distance)
         {
             int restsCount = Convert.ToInt16(Math.Floor(distance / (Speed * TimeTillRest)));
             return distance / Speed + FindRestDuration(restsCount);
         }

        protected int TimeTillRest { get; set; }
        protected abstract double FindRestDuration(int restsCount);
    }
}