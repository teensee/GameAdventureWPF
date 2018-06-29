using Engine.Factories;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }

        public string Name { get; }
        public string Description { get; }
        public string ImagePath { get; }


        public List<Quest> QuestAvailableHere { get; } = new List<Quest>();

        public List<MonsterEncounter> MonstersHere { get; } =
            new List<MonsterEncounter>();

        public Trader TraderHere { get; set; }

        public Location(int xCoord, int yCoord, string name, string desc, string imgPath)
        {
            XCoordinate = xCoord;
            YCoordinate = yCoord;
            Name = name;
            Description = desc;
            ImagePath = imgPath;
        }

        public void AddMonster(int monsterID, int chanсeOfEncountering)
        {
            if (MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                // This monster has already been added to this location.
                // So, overwrite the ChanceOfEncountering with the new number.
                MonstersHere.First(m => m.MonsterID == monsterID)
                    .ChanceOfEncountering = chanсeOfEncountering;
            }
            else
            {
                // This monster is not already at this location, so add it.
                MonstersHere.Add(new MonsterEncounter(monsterID, chanсeOfEncountering));
            }
        }

        public Monster GetMonster()
        {
            if (!MonstersHere.Any())
            {
                return null;
            }

            // Total the percentages of all monsters at this location.
            int totalChances = MonstersHere.Sum(m => m.ChanceOfEncountering);


            // Select a random number between 1 and the total (in case the total chances is not 100).
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChances);

            // Loop through the monster list, 
            // adding the monster's percentage chance of appearing to the runningTotal variable.
            // When the random number is lower than the runningTotal,
            // that is the monster to return.
            int runningTotal = 0;

            foreach (MonsterEncounter monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;

                if (randomNumber <= runningTotal)
                {
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
                }
            }

            // If there was a problem, return the last monster in the list.
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }

    }
}
