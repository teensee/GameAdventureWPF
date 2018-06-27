using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engine.Models
{
    public class Player : LivingEntity
    {
        private string _characterClass;
        private int _hitPoints;
        private int _experiencePoints;

        public string CharacterClass
        {
            get => _characterClass;
            set
            {
                _characterClass = value;
                OnPropertyChanged();
            }
        }

        public int ExperiencePoints
        {
            get => _experiencePoints;
            private set
            {
                _experiencePoints = value;
                OnPropertyChanged();

                SetLevelAndMaxHitPoints();
            }

        }

        public ObservableCollection<QuestStatus> Quests { get; }

        public event EventHandler OnLeveledUp;
        public Player(string name, string characterClass, int expPoints, int maxHitPoints, int currHitPoints, int gold, int level) 
            : base(name, maxHitPoints, currHitPoints, gold, level)
        {
            CharacterClass = characterClass;
            ExperiencePoints = expPoints;

            Quests = new ObservableCollection<QuestStatus>();
        }


        public bool HasAllTheseItems(List<ItemQuantity> list)
        {
            foreach (ItemQuantity item in list)
            {
                if(Inventory.Count(i => i.ItemTypeID == item.ItemID) < item.Quantity)
                {
                    return false;
                }
            }

            return true;
        }

        #region leveling

        public void AddExperience(int expPoints) => ExperiencePoints += expPoints;

        private void SetLevelAndMaxHitPoints()
        {
            int originalLevel = Level;

            Level = (ExperiencePoints / 100) + 1;

            if(Level != originalLevel)
            {
                MaximumHitPoints = Level * 10;
                CompletelyHeal();

                OnLeveledUp?.Invoke(this, System.EventArgs.Empty);
            }
        }

        #endregion
    }
}
