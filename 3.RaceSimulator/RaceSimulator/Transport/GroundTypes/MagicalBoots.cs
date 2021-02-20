namespace RaceSimulator.Transport.GroundTypes
{
    public class MagicalBoots : GroundTransport
    {
        public MagicalBoots()
        {
            Speed = 6;
            TypeName = "MagicalBoots";
            TimeTillRest = 60;
        }

        protected override double FindRestDuration(int restsCount)
            => restsCount == 1 ? 10 : 5 + FindRestDuration(--restsCount);
    }
}