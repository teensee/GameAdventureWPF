namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        public string ImageName { get; set; }

        public int MaximumDamage { get; set; }
        public int MinimumDamage { get; set; }

        public int RewardExpiriencePoints { get; set; }


        public Monster(string name, int maxHP, int currHitPoints,int maxDamage,int minDamage, int rewExp, int rewGold, string img)
        {
            Name = name;
            MaximumHitPoints = maxHP;
            CurrentHitPoints = currHitPoints;
            MaximumDamage = maxDamage;
            MinimumDamage = minDamage;
            RewardExpiriencePoints = rewExp;
            Gold = rewGold;
            ImageName = string.Format(@"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Monsters\{0}", img);

        }
    }
}
