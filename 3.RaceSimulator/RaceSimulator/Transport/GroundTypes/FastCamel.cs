namespace RaceSimulator.Transport.GroundTypes
{
    public class FastCamel : GroundTransport
    {
        public FastCamel()
        {
            Speed = 40;
            TypeName = "FastCamel";
            TimeTillRest = 10;
        }

        protected override double FindRestDuration(int restsCount)
            => restsCount switch
            {
                1 => 5,
                2 => 6.5 + FindRestDuration(--restsCount),
                _ => 8 + FindRestDuration(--restsCount)
            };
            
        
    }
}