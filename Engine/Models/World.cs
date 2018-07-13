using System.Collections.Generic;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locationList = new List<Location>();

        internal void AddLocation(int xcoord, int ycoord, string name, string desc, string imgName) 
            => _locationList.Add(new Location(xcoord, ycoord, name, desc, $"pack://application:,,,/Engine;component/Images/Location/{imgName}"));

        public Location LocationAt(int xCoord, int yCoord)
        {
            foreach (var _location in _locationList)
            {
                if(_location.XCoordinate == xCoord && _location.YCoordinate == yCoord)
                {
                    return _location;
                }
            }

            return null;
        }
    }
}
