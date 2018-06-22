using System.Collections.Generic;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locationList = new List<Location>();

        internal void AddLocation(int xcoord, int ycoord, string name, string desc, string imgName)
        {
            Location loc = new Location();
            loc.XCoordinate = xcoord;
            loc.YCoordinate = ycoord;
            loc.Name = name;
            loc.Description = desc;
            loc.ImagePath = string.Format(@"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\{0}", imgName);

            _locationList.Add(loc);
        }

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
