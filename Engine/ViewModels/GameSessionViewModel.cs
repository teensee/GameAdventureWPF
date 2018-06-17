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
    public class GameSessionViewModel : INotifyPropertyChanged
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

            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, 0);
        }

        #region Move btns

        public void MoveNorth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }

        public void MoveWest()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
        }

        public void MoveEast()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        }

        public void MoveSouth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
