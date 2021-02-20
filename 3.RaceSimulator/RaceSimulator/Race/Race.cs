using System;
using RaceSimulator.Transport;
using System.Collections.Generic;
using System.Linq;

namespace RaceSimulator.Race
{
    public abstract class Race<T> where T : ITransport
    {
        private List<T> _transportsList;
        protected abstract string Type {get;}
        private double Distance { get; }

        protected Race(List<T> transportsList, double distance)
        {
            _transportsList = transportsList;
            Distance = distance;
        }

        protected Race(double distance)
        {
            _transportsList = new List<T>();
            Distance = distance;
        }

        public void AddTransport(T transport)
        {
            if (!_transportsList.Contains(transport))
                _transportsList.Add(transport);
        }

        private string GetWinner()
        {
            if (_transportsList.Count <= 1)
                return "None";

            return _transportsList.Select(v => new
            {
                v.TypeName,
                Time = v.FindTime(Distance)
            }).OrderBy(v => v.Time).First().TypeName;
        }

        public void PrintWinner()
        {
            var winner = GetWinner();
            if (winner == "None")
                Console.WriteLine("The race cannot be started with 1 or less participants.");
            else
                Console.WriteLine("In {0} {1} race the winner is {2}.",Type, Distance, winner);
        }
    }
}