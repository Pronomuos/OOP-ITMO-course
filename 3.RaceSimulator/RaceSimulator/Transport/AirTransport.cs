namespace RaceSimulator.Transport
{
    public abstract class AirTransport : ITransport
    {
        public double Speed { get; set; }
        public string TypeName { get; set; }

        public double FindTime(double distance)
            => FindReducedDistance(distance) / Speed;
        
        protected abstract double FindReducedDistance(double distance);
    }
}