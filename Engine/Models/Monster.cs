using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Monster : BaseNotificationClass
    {
        private int _hitPoint;

        public string Name { get; private set; }
        public string ImageName { get; set; }
        public int MaximumHitPoints { get; private set; }
        public int HitPoints
        {
            get { return _hitPoint; }
            set
            {
                _hitPoint = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        public int RewardExpiriencePoints { get; set; }
        public int RewardGold { get; set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string name, string img, int maxHP, int hitPoints, int rewExp, int rewGold) 
        {
            Name = name;
            ImageName = img;
            MaximumHitPoints = maxHP;
            HitPoints = hitPoints;
            RewardExpiriencePoints = rewExp;
            RewardGold = rewGold;
        }
    }
}
