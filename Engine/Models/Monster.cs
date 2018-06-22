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

        public int MaximumDamage { get; set; }
        public int MinimumDamage { get; set; }

        public int RewardExpiriencePoints { get; set; }
        public int RewardGold { get; set; }

        public ObservableCollection<ItemQuantity> sss;

        public Monster(string name, int maxHP, int currHitPoints,int maxDamage,int minDamage, int rewExp, int rewGold, string img)
        {
            sss = new ObservableCollection<ItemQuantity>();

            Name = name;
            MaximumHitPoints = maxHP;
            HitPoints = currHitPoints;
            MaximumDamage = maxDamage;
            MinimumDamage = minDamage;
            RewardExpiriencePoints = rewExp;
            RewardGold = rewGold;
            ImageName = string.Format(@"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Monsters\{0}", img);

        }
    }
}
