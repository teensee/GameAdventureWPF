using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ItemQuantity> ItemToComplete { get; set; }

        public int RewardExperience { get; set; }
        public int RewardGold { get; set; }
        public List<ItemQuantity> RewardItems { get; set; }

        public Quest(int id, string name, string desc, List<ItemQuantity> itemToComplete,
            int rewExp, int rewGold, List<ItemQuantity> rewItem)
        {
            //common 
            ID = id;
            Name = name;
            Description = desc;

            //needed item
            ItemToComplete = itemToComplete;

            //reward
            RewardExperience = rewExp;
            RewardGold = rewGold;
            RewardItems = rewItem;
        }

    }
}
