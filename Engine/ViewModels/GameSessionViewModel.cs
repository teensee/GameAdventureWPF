using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ViewModels
{
    public class GameSessionViewModel
    {
        public Player CurrentPlayer { get; set; }

        public GameSessionViewModel()
        {
            CurrentPlayer = new Player
            {
                Name = "Bob",
                CharacterClass = "Fighter",
                Gold = 1000000,
                HitPoints = 10,
                Level = 1,
                ExperiencePoints = 0
            };
        }
    }
}
