using Engine.Models;
using Engine.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using Engine.Factories;
using System.ComponentModel;

namespace Engine.ViewModels
{
    public class GameSessionViewModel : BaseNotificationClass
    {
        /// <summary>
        /// event which handle raised message
        /// </summary>
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        private Location _currentLocation;
        private Monster _currentMonster;
        private Trader _currentTrader;

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
                _currentMonster = value;

                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));

                if(CurrentMonster != null)
                {
                    RaiseMessage("");
                    RaiseMessage($"You see a {CurrentMonster.Name} here");
                }
            }
        }

        /// <summary>
        /// Current equipped weapon
        /// </summary>
        public Weapon CurrentWeapon { get; set; }

        public Trader CurrentTrader
        {
            get => _currentTrader;
            set
            {
                _currentTrader = value;

                OnPropertyChanged(nameof(CurrentTrader));
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
            CurrentPlayer = new Player
            {
                Name = "Bob",
                CharacterClass = "Fighter",
                Gold = 0,
                HitPoints = 10,
                Level = 1,
                ExperiencePoints = 0
            };

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
            if (CurrentWeapon == null)
            {
                RaiseMessage("You must select a weapon to attack monster.");
                return;
            }

            //Determine damage to monster
            int damageToMonster = RandomNumberGenerator.NumberBetween(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage);

            if (damageToMonster == 0)
                RaiseMessage($"You missed the {CurrentMonster.Name}.");
            else
            {
                CurrentMonster.HitPoints -= damageToMonster;
                RaiseMessage($"You hit the {CurrentMonster.Name} for {damageToMonster} points.");              
            }

            if (CurrentMonster.HitPoints <= 0)
            {
                RaiseMessage("");
                RaiseMessage($"You defeat the {CurrentMonster.Name}.");

                CurrentPlayer.ExperiencePoints += CurrentMonster.RewardExpiriencePoints;
                RaiseMessage($"You recieve {CurrentMonster.RewardExpiriencePoints} experience point.");

                CurrentPlayer.Gold += CurrentMonster.RewardGold;
                RaiseMessage($"You recieve {CurrentMonster.RewardGold} gold.");

                foreach (var itemQuantity in CurrentMonster.sss)
                {
                    var item = ItemFactory.CreateGameItem(itemQuantity.ItemID);
                    CurrentPlayer.AddItemToInventory(item);

                    RaiseMessage($"You get a {itemQuantity.Quantity}ea. {item.Name}.");
                }

                GetMonsterAtLocation();
            }
            else
            {
                //If monster still alive let the monster attack
                var damageToPlayer = RandomNumberGenerator.NumberBetween(CurrentMonster.MinimumDamage, CurrentMonster.MaximumDamage);

                if (damageToPlayer == 0)
                {
                    RaiseMessage("The monster attacks, but missed you.");
                }
                else
                {
                    CurrentPlayer.HitPoints -= damageToPlayer;
                    RaiseMessage($"You recieve {damageToPlayer} from {CurrentMonster.Name}.");
                }

                if (CurrentPlayer.HitPoints <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"The {CurrentMonster.Name} killed you.");

                    CurrentLocation = CurrentWorld.LocationAt(0, -1);    //Teleport to player's home
                    CurrentPlayer.HitPoints = CurrentPlayer.Level * 10; //Full heal :0
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

                        CurrentPlayer.ExperiencePoints += quest.RewardExperience;
                        RaiseMessage($"You receive {quest.RewardExperience} experience points");

                        CurrentPlayer.Gold += quest.RewardGold;
                        RaiseMessage($"You receive {quest.RewardGold} gold");

                        foreach (var itemQuantity in quest.RewardItems)
                        {
                            GameItem rewardItem = ItemFactory.CreateGameItem(itemQuantity.ItemID);

                            CurrentPlayer.AddItemToInventory(rewardItem);
                            RaiseMessage($"You receive a {rewardItem.Name}");
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


    }
}
