namespace Engine.Models
{
    public class QuestStatus : BaseNotificationClass
    {
        public Quest PlayerQuest { get; }
        private bool _isCompleted;

        public bool isCompleted
        {
            get => _isCompleted;
            set
            {
                _isCompleted = value;
                OnPropertyChanged();
            }
        }

        public QuestStatus(Quest quest)
        {
            PlayerQuest = quest;
            isCompleted = false;
        }
    }
}
