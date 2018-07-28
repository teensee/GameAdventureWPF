using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            #region Home location

            newWorld.AddLocation(
                0, -1, 
                "Home", 
                "Sweet home", 
                "Home.png");

            #endregion

            #region farmer's location

            newWorld.AddLocation(
                -1, -1, 
                "Farmhouse",
                "This is the house of your neighbor, Farmer Ted.", 
                "Farmhouse.png");

            newWorld.AddLocation(
                -2, -1, 
                "Farmer's Field", 
                "There are rows of corn growing here, with giant rats hiding between them", 
                "FarmFields.png");

            newWorld.LocationAt(-2, -1).AddMonster(2, 100);

            newWorld.LocationAt(-1, -1).TraderHere =
                TraderFactory.GerTraderByName("Farmer Ted");

            #endregion

            #region Town locations

            newWorld.AddLocation(
                0, 0,
                "Town square", 
                "You see a giant fountain here",
                "TownSquare.png");

            newWorld.AddLocation(
                -1, 0,
                "Trading shop",
                "The shop of Susan, the trader",
                "Trader.png");

            newWorld.AddLocation(
                1, 0,
                "Town Gate", 
                "There is a gate here, protecting the town from giant spider",
                "TownGate.png");


            newWorld.LocationAt(-1, 0).TraderHere =
                TraderFactory.GerTraderByName("Susan");
            #endregion

            #region Herbalist Fields

            newWorld.AddLocation(
                0, 1,
                "Herbalist Hut", 
                "You see a small hut, with plants drying from the roof",
                "HerbalistsHut.png");


            newWorld.AddLocation(
                0, 2,
                "Herbalist's garden", 
                "There are many plants here, with snakes hiding behind them",
                "HerbalistsGarden.png");

            //Add quest in location herbalist's garden
            newWorld.LocationAt(0, 1).QuestAvailableHere.Add(QuestFactory.GetQuestByID(1));

            //Add snake in location "Herbalist's garden"
            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            newWorld.LocationAt(0, 1).TraderHere =
                TraderFactory.GerTraderByName("Pete the Herbalist");

            #endregion

            #region Spider Field

            newWorld.AddLocation(
                2, 0,
                "Spider forest", 
                "The trees in this forest are covered with spider webs",
                "SpiderForest.png");

            newWorld.LocationAt(2, 0).AddMonster(3, 100);

            #endregion

            return newWorld;
        }
    }
}
