using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            #region Home location

            newWorld.AddLocation(0, -1, 
                "Home", "Sweet home", 
                @"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\Home.png");

            #endregion

            #region farmer's location

            newWorld.AddLocation(-1, -1, 
                "Farmhouse", "This is the house of your neighbor, Farmer Ted.", 
                @"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\Farmhouse.png");
            newWorld.AddLocation(-2, -1, 
                "Farmer's Field", "There are rows of corn growing here, with giant rats hiding between them", 
                @"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\FarmFields.png");

            #endregion

            #region Town locations

            newWorld.AddLocation(0, 0,
                "Town square", "You see a giant fountain here",
                @"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\TownSquare.png");

            newWorld.AddLocation(-1, 0,
                "Trading shop", "The shop of Susan, the trader",
                @"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\Trader.png");

            newWorld.AddLocation(1, 0,
                "Town Gate", "There is a gate here, protecting the town from giant spider",
                @"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\TownGate.png");

            #endregion

            #region Herbalist Fields

            newWorld.AddLocation(0, 1,
                "Herbalist Hut", "You see a small hut, with plants drying from the roof",
                @"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\HerbalistsHut.png");

            newWorld.AddLocation(0, 2,
                "Herbalist's garden", "There are many plants here, with snakes hiding behind them",
                @"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\HerbalistsGarden.png");

            #endregion

            #region Spider Field

            newWorld.AddLocation(2, 0,
                "Spider forest", "The trees in this forest are covered with spider webs",
                @"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Location\SpiderForest.png");

            #endregion

            return newWorld;
        }
    }
}
