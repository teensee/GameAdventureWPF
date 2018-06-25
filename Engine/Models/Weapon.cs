using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public Weapon(int id, string name, int price, int minimumDamage, int maximumDamage) 
            : base(id, name, price, true)
        {
            MaximumDamage = maximumDamage;
            MinimumDamage = minimumDamage;
        }

        public new Weapon Clone()
        {
            return new Weapon(ItemTypeID, Name, Price, MaximumDamage, MinimumDamage);
        }
    }
}
