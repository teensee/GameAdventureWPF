using Engine.Models;
using Engine.EventArgs;
using System;
using System.Linq;
using Engine.Factories;

namespace Engine.ViewModels
{
    public class GameSessionViewModel : BaseNotificationClass
    {
        /// <summary>
        /// Event which handle raised message
        /// </summary>
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        private Location _currentLocation;
        private Monster _currentMonster;
        private Trader _currentTrader;
        private Player _currentPlayer;

        public Player CurrentPlayer
        {
            get => _currentPlayer;
            set
            {
                if (_currentPlayer != null)
                {
                    _currentPlayer.OnActionPerformed -= OnCurrentPlayerPerformedAction;
                    _currentPlayer.OnLeveledUp -= OnCurrentPlayerLeveledUp;
                    _currentPlayer.OnKilled -= OnCurrentPlayerKilled;
                }

                _currentPlayer = value;

                if (_currentPlayer != null)
                {
                    _currentPlayer.OnActionPerformed += OnCurrentPlayerPerformedAction;
                    _currentPlayer.OnLeveledUp += OnCurrentPlayerLeveledUp;
                    _currentPlayer.OnKilled += OnCurrentPlayerKilled;
                }
            }
        }

        public World CurrentWorld { get; }

        public Location CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;

                OnPropertyChanged();

                OnPropertyChanged(nameof(HasLocationToEast));
                OnPropertyChanged(nameof(HasLocationToNorth));
                OnPropertyChanged(nameof(HasLocationToSouth));
                OnPropertyChanged(nameof(HasLocationToWest));

                CompleteQuestAtLocation();
                GivePlayerQuestsAtLocation();
                GetMonsterAtLocation();

                CurrentTrader = CurrentLocation.TraderHere;
            }
        }

        /// <summary>
        /// Current monster
        /// </summary>
        public Monster CurrentMonster
        {
            get => _currentMonster;
            set
            {

                if (_currentMonster != null)
                    _currentMonster.OnKilled -= OnCurrentMonsterKilled;

                _currentMonster = value;

                if(_currentMonster != null)
                {
                    _currentMonster.OnKilled += OnCurrentMonsterKilled;

                    RaiseMessage("");
                    RaiseMessage($"You see a {CurrentMonster.Name} here");
                }

                OnPropertyChanged();
                OnPropertyChanged(nameof(HasMonster));
            }
        }

        public Trader CurrentTrader
        {
            get => _currentTrader;
            set
            {
                _currentTrader = value;

                OnPropertyChanged();
                OnPropertyChanged(nameof(HasTrader));
            }
        }

        /// <summary>
        /// Check trader on location
        /// </summary>
        public bool HasTrader => CurrentTrader != null;

        /// <summary>
        /// Check monster on location
        /// </summary>
        public bool HasMonster => CurrentMonster != null;

        #region Has location to...?

        /// <summary>
        /// Check location to north
        /// </summary>
        public bool HasLocationToNorth
        {
            get => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
        }

        /// <summary>
        /// Check location to west
        /// </summary>
        public bool HasLocationToWest
        {
            get => CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
        }

        /// <summary>
        /// Check location to east
        /// </summary>
        public bool HasLocationToEast
        {
            get => CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
        }

        /// <summary>
        /// Check location to south
        /// </summary>
        public bool HasLocationToSouth
        {
            get => CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
        }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public GameSessionViewModel()
        {
            CurrentPlayer = new Player("Bob", "Fighter", 0, 10, 10, 0, 1);

            if (!CurrentPlayer.Weapons.Any())
                CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));

            CurrentWorld = WorldFactory.CreateWorld();
            CurrentLocation = CurrentWorld.LocationAt(0, -1);
        }

        #region Move btns

        /// <summary>
        /// go to north
        /// </summary>
        public void MoveNorth()
        {
            if(HasLocationToNorth)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }

        /// <summary>
        /// go to west!
        /// </summary>
        public void MoveWest()
        {
            if(HasLocationToWest)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
        }

        /// <summary>
        /// Go to east :)
        /// </summary>
        public void MoveEast()
        {
            if(HasLocationToEast)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        }

        /// <summary>
        /// move to south!
        /// </summary>
        public void MoveSouth()
        {
            if(HasLocationToSouth)
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        }

        #endregion

        /// <summary>
        /// Get new monster :SSS
        /// </summary>
        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster();
        }

        /// <summary>
        /// Send message to textbox
        /// </summary>
        /// <param name="message"> text message</param>
        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }

        #region Combat

        /// <summary>
        /// Combat logic
        /// </summary>
        public void AttackCurrentMonster()
        {
            if (CurrentPlayer.CurrentWeapon == null)
            {
                RaiseMessage("You must select a weapon to attack monster.");
                return;
            }

            CurrentPlayer.UseCurrentWeaponOn(CurrentMonster);

            if (CurrentMonster.IsDead)
            {
                GetMonsterAtLocation();
            }
            else
            {
                int damageToPlayer = RandomNumberGenerator.NumberBetween(CurrentMonster.MinimumDamage, CurrentMonster.MaximumDamage);
                if (damageToPlayer == 0)
                    RaiseMessage($"The {CurrentMonster.Name} attacks, but missed you :)");
                else
                {
                    RaiseMessage($"The {CurrentMonster.Name} hit you for {damageToPlayer} points");
                    CurrentPlayer.TakeDamage(damageToPlayer);
                }
            }
        }

        #endregion



        #region Quest logic

        /// <summary>
        /// Complete quest
        /// </summary>
        private void CompleteQuestAtLocation()
        {
            foreach (var quest in CurrentLocation.QuestAvailableHere)
            {
                QuestStatus questToComplete =
                    CurrentPlayer.Quests.FirstOrDefault(q => q.PlayerQuest.ID == quest.ID && !q.isCompleted);

                if (questToComplete != null)
                {
                    if (CurrentPlayer.HasAllTheseItems(quest.ItemToComplete))
                    {
                        //remove the quest completion items from the player's inventory
                        foreach (var itemQuantity in quest.ItemToComplete)
                        {
                            for (int i = 0; i < itemQuantity.Quantity; i++)
                            {
                                CurrentPlayer.RemoveItemFromInventory(CurrentPlayer.Inventory.First(item => item.ItemTypeID == itemQuantity.ItemID));
                            }
                        }

                        RaiseMessage("");
                        RaiseMessage($"You completed the '{quest.Name}' quest");

                        RaiseMessage($"You receive {quest.RewardExperience} experience points");
                        CurrentPlayer.AddExperience(quest.RewardExperience);

                        RaiseMessage($"You receive {quest.RewardGold} gold");
                        CurrentPlayer.RecieveGold(quest.RewardGold);

                        foreach (var itemQuantity in quest.RewardItems)
                        {
                            GameItem rewardItem = ItemFactory.CreateGameItem(itemQuantity.ItemID);

                            RaiseMessage($"You receive a {rewardItem.Name}");
                            CurrentPlayer.AddItemToInventory(rewardItem);
                        }

                        // Mark the Quest as completed
                        questToComplete.isCompleted = true;
                    }
                }
            }
        }

        /// <summary>
        /// get new quest
        /// </summary>
        private void GivePlayerQuestsAtLocation()
        {
            foreach (Quest quest in CurrentLocation.QuestAvailableHere)
            {
                if (!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));

                    RaiseMessage("");
                    RaiseMessage($"You receive the '{quest.Name}' quest");
                    RaiseMessage(quest.Description);

                    RaiseMessage("Return with:");
                    foreach (ItemQuantity itemQuantity in quest.ItemToComplete)
                    {
                        RaiseMessage($"   {itemQuantity.Quantity} {ItemFactory.CreateGameItem(itemQuantity.ItemID).Name}");
                    }

                    RaiseMessage("And you will receive:");
                    RaiseMessage($"   {quest.RewardExperience} experience points");
                    RaiseMessage($"   {quest.RewardGold} gold");
                    foreach (ItemQuantity itemQuantity in quest.RewardItems)
                    {
                        RaiseMessage($"   {itemQuantity.Quantity} {ItemFactory.CreateGameItem(itemQuantity.ItemID).Name}");
                    }
                }
            }
        }

        #endregion

        private void OnCurrentPlayerPerformedAction(object sender, string result) => RaiseMessage(result);

        private void OnCurrentPlayerLeveledUp(object sender, System.EventArgs e) => RaiseMessage($"You receive a {CurrentPlayer.Level}!");

        private void OnCurrentPlayerKilled(object sender, System.EventArgs e)
        {
            RaiseMessage(string.Empty);
            RaiseMessage("You have been killed");

            CurrentLocation = CurrentWorld.LocationAt(0, -1);
            CurrentPlayer.CompletelyHeal();
        }

        private void OnCurrentMonsterKilled(object sender, System.EventArgs e)
        {
            RaiseMessage(string.Empty);
            RaiseMessage($"You defeat the {CurrentMonster.Name}!");

            RaiseMessage($"You receive {CurrentMonster.RewardExpiriencePoints} experience points");
            CurrentPlayer.AddExperience(CurrentMonster.RewardExpiriencePoints);

            RaiseMessage($"You receive {CurrentMonster.Gold} gold");
            CurrentPlayer.RecieveGold(CurrentMonster.Gold);

            foreach (var gameItem in CurrentMonster.Inventory)
            {
                RaiseMessage($"You receive one {gameItem.Name}");
                CurrentPlayer.AddItemToInventory(gameItem);
            }
        }

    }
}
