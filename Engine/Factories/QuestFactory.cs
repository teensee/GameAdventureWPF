﻿using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Factories
{
    public static class QuestFactory
    {
        private static readonly List<Quest> _quest = new List<Quest>();

        static QuestFactory()
        {
            List<ItemQuantity> itemToComplete = new List<ItemQuantity>();
            List<ItemQuantity> rewardItem = new List<ItemQuantity>();

            itemToComplete.Add(new ItemQuantity(9001,5));
            rewardItem.Add(new ItemQuantity(1002, 1));

            _quest.Add(new Quest(1,
                "Clear the herb garden",
                "Defeat the snakes in the Herbalist's garden",
                itemToComplete,
                25, 10,
                rewardItem));
        }

        internal static Quest GetQuestByID(int id)
        {
            return _quest.FirstOrDefault(quest => quest.ID == id);
        }
    }
}