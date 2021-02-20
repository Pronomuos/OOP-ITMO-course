namespace RaceSimulator.Transport.GroundTypes
{
    public class Centaur : GroundTransport
    {
        public Centaur()
        {
            Speed = 15;
            TypeName = "Centaur";
            TimeTillRest = 8;
        }

        protected override double FindRestDuration(int restsCount) 
            => restsCount == 1 ? 2 : 2 + FindRestDuration(--restsCount);

    }
}