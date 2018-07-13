﻿using Engine.Actions;
using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Factories
{
    public static class ItemFactory
    {
        private static List<GameItem> _standardGameItems = new List<GameItem>();

        static ItemFactory()
        {
            BuildWeapon(1001, "Pointy Stick", 1, 1, 2);
            BuildWeapon(1002, "Rusty Sword", 5, 1, 5);

            BuildMiscellaneous(9001, "Snake fang", 1);
            BuildMiscellaneous(9002, "Snakeskin", 2);
            BuildMiscellaneous(9003, "Rat tail", 1);
            BuildMiscellaneous(9004, "Rat fur", 2);
            BuildMiscellaneous(9005, "Spider fang", 1);
            BuildMiscellaneous(9006, "Spider silk", 2);

        }

        public static GameItem CreateGameItem(int itemID)
        {
            var item = _standardGameItems.FirstOrDefault(i => i.ItemTypeID == itemID)?.Clone();
            return item;
        }

        private static void BuildMiscellaneous(int id, string name, int price)
        {
            _standardGameItems.Add(new GameItem(GameItem.ItemCategory.Miscellaneous, id, name, price));
        }

        private static void BuildWeapon(int id, string name, int price, 
                                        int minimumDamage, int maximumDamage)
        {
            GameItem weapon = new GameItem(GameItem.ItemCategory.Weapon, id, name, price, true);

            weapon.Action = new AttackWithWeapon(weapon, minimumDamage, maximumDamage);

            _standardGameItems.Add(weapon);
        }
    }
}
