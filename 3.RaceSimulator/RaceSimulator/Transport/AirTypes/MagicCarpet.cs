namespace RaceSimulator.Transport.AirTypes
{
    public class MagicCarpet: AirTransport
    {
        public MagicCarpet()
        {
            Speed = 10;
            TypeName = "MagicCarpet";
        }

        protected override double FindReducedDistance(double distance)
        {
            if (distance > 1000 && distance <= 5000)
                return distance - distance * 3 / 100;
            if (distance > 5000 && distance <= 10000)
                return distance - distance * 10/ 100;
            if (distance > 10000)
                return distance - distance * 5 / 100;
            
            return distance;
        }
    }
}