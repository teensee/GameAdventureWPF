namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        public string ImageName { get; }

        public int RewardExpiriencePoints { get; }


        public Monster(string name, int maxHP, 
                       int currHitPoints,int rewExp, 
                       int rewGold, string img)
            : base(name, maxHP, currHitPoints, rewGold)
        {
            RewardExpiriencePoints = rewExp;
            ImageName = string.Format($"pack://application:,,,/Engine;component/Images/Monsters/{img}");
        }
    }
}
