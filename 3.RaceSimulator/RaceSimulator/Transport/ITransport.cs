namespace RaceSimulator.Transport
{
    public interface ITransport
    {
        double Speed { get; }
        string TypeName { get; }

        public double FindTime(double distance);

    }
}