using System;

namespace Shouty
{
    public class Location 
    {
        public int Latitude { get; }
        public int Longitude { get; }

        public Location(int latitude, int longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public int DistanceFrom(Location other)
        {
            return (int)Math.Sqrt(Math.Pow(Latitude - other.Latitude, 2) +
            Math.Pow(Longitude - other.Longitude, 2));
        }
    }
}
