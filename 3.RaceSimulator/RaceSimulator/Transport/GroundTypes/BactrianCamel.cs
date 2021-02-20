namespace RaceSimulator.Transport.GroundTypes
{
    public class BactrianCamel : GroundTransport
    {
        
        public BactrianCamel()
        {
            Speed = 10;
            TypeName = "BactrianCamel";
            TimeTillRest = 30;
        }

        protected override double FindRestDuration(int restsCount) 
            => restsCount == 1 ? 5: 8 + FindRestDuration(--restsCount);
        
        
    }
}