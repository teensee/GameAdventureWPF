using System.Collections.Generic;

namespace Engine.Models
{
    public class Quest
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }

        public List<ItemQuantity> ItemToComplete { get; }

        public int RewardExperience { get; }
        public int RewardGold { get; set; }
        public List<ItemQuantity> RewardItems { get; }

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
