using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engine.ViewModels;

namespace TestEngine.ViewModel
{
    [TestClass]
    public class TestGaneSession
    {
        [TestMethod]
        public void TestCreateGameSession()
        {
            GameSessionViewModel gameSession = new GameSessionViewModel();

            Assert.IsNotNull(gameSession.CurrentPlayer);
            Assert.AreEqual("Home", gameSession.CurrentLocation.Name);
        }

        [TestMethod]
        public void TestPlayerMovesHomeAndIsComplelelyHealOnKilled()
        {
            GameSessionViewModel gameSession = new GameSessionViewModel();

            gameSession.CurrentPlayer.TakeDamage(999);

            Assert.AreEqual("Home", gameSession.CurrentLocation.Name);
            Assert.AreEqual(gameSession.CurrentPlayer.Level * 10, gameSession.CurrentPlayer.CurrentHitPoints);
        }
    }
}
