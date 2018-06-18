using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;
using System.ComponentModel;

namespace Engine.ViewModels
{
    public class GameSessionViewModel : BaseNotificationClass
    {
        private Location _currentLocation;

        public Player CurrentPlayer { get; set; }
        public World CurrentWorld { get; set; }

        public Location CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToSouth));
                OnPropertyChanged(nameof(HasLocationToWest));
            }
        }

        #region Has location to...?

        public bool HasLocationToNorth
        {
            get => CurrentWorld.LocationAt(
            CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
        }

        public bool HasLocationToWest
        {
            get => CurrentWorld.LocationAt(
            CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
        }

        public bool HasLocationToEast
        {
            get => CurrentWorld.LocationAt(
            CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
        }

        public bool HasLocationToSouth
        {
            get => CurrentWorld.LocationAt(
            CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
        }

        #endregion


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

            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, 0);

            CurrentPlayer.Inventory.Add(ItemFactory.CreateGameItem(1001));
        }

        #region Move btns

        public void MoveNorth()
        {
            if(HasLocationToNorth)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }

        public void MoveWest()
        {
            if(HasLocationToWest)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
        }

        public void MoveEast()
        {
            if(HasLocationToEast)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        }

        public void MoveSouth()
        {
            if(HasLocationToSouth)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        }

        #endregion


    }
}
