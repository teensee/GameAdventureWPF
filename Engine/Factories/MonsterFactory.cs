using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    public static class MonsterFactory
    {
        public static Monster GetMonster(int monsterID)
        {
            switch (monsterID)
            {
                case 1:
                    Monster snake = new Monster("Snake", 4, 4, 2, 1, 5, 1, "Snake.png");

                    AddLootItem(snake, 9001, 25);
                    AddLootItem(snake, 9002, 75);

                    return snake;
                case 2:
                    Monster rat = new Monster("Rat", 5, 5, 2, 1, 5, 1, "Rat.png");

                    AddLootItem(rat, 9003, 25);
                    AddLootItem(rat, 9004, 75);

                    return rat;

                case 3:
                    Monster giantSpider = new Monster("Giant Spider", 10, 10, 4, 1, 10, 5, "GiantSpider.png");

                    AddLootItem(giantSpider, 9005, 25);
                    AddLootItem(giantSpider, 9006, 72);

                    return giantSpider;

                default:
                    throw new ArgumentException(string.Format("MonsterType '{0}' does not exist", monsterID));
            }
        }

        private static void AddLootItem(Monster monsterName, int itemID, int percentage)
        {
            if(RandomNumberGenerator.NumberBetween(1,100) <= percentage)
            {
                monsterName.Inventory.Add(new ItemQuantity(itemID, 1));
            }
        }
    }
}
