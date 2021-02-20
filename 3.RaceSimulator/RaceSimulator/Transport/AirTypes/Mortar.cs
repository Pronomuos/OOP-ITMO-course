namespace RaceSimulator.Transport.AirTypes
{
    public class Mortar: AirTransport
    {
        public Mortar()
        {
            Speed = 8;
            TypeName = "Mortar";
        }

        protected override double FindReducedDistance(double distance)
            => distance - distance * 6/ 100;
        
    }
}