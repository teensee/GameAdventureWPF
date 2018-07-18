using Engine.Models;
using System;

namespace Engine.Factories
{
    public static class MonsterFactory
    {
        public static Monster GetMonster(int monsterID)
        {
            switch (monsterID)
            {
                case 1:
                    Monster snake = new Monster("Snake", 4, 4, 5, 1, "Snake.png")
                    {
                        CurrentWeapon = ItemFactory.CreateGameItem(1501)
                    };

                    AddLootItem(snake, 9001, 25);
                    AddLootItem(snake, 9002, 75);

                    return snake;
                case 2:
                    Monster rat = new Monster("Rat", 5, 5, 5, 1, "Rat.png")
                    {
                        CurrentWeapon = ItemFactory.CreateGameItem(1502)
                    };

                    AddLootItem(rat, 9003, 25);
                    AddLootItem(rat, 9004, 75);

                    return rat;

                case 3:
                    Monster giantSpider = new Monster("Giant Spider", 10, 10, 10, 5, "GiantSpider.png")
                    {
                        CurrentWeapon = ItemFactory.CreateGameItem(1503)
                    };

                    AddLootItem(giantSpider, 9005, 25);
                    AddLootItem(giantSpider, 9006, 72);

                    return giantSpider;

                default:
                    throw new ArgumentException(string.Format("MonsterType '{0}' does not exist", monsterID));
            }
        }

        private static void AddLootItem(Monster monster, int itemID, int percentage)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= percentage)
            {
                monster.AddItemToInventory(ItemFactory.CreateGameItem(itemID));
            }
        }
    }
}
