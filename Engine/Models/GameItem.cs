using Engine.Actions;

namespace Engine.Models
{
    public class GameItem
    {
        public enum ItemCategory
        {
            Miscellaneous,
            Weapon,
            Consumable
        }

        public ItemCategory Category { get; }
        public int ItemTypeID { get; }
        public string Name { get; }
        public int Price { get; }
        public bool IsUnique { get; }
        public IAction Action { get; set; }

        public GameItem(ItemCategory category,int id, string name, int price, 
                        bool isUnique = false, IAction attack = null)
        {
            Category = category;
            ItemTypeID = id;
            Name = name;
            Price = price;
            IsUnique = isUnique;
            Action = attack;
        }

        public void PerformAction(LivingEntity actor, LivingEntity target) => Action?.Execute(actor, target);

        public GameItem Clone() =>
            new GameItem(Category, ItemTypeID, Name, Price, IsUnique, Action);
    }
}
