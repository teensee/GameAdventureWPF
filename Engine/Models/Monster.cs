namespace Engine.Models
{
    public class Monster : LivingEntity
    {
        public string ImageName { get; }

        public int MaximumDamage { get; }
        public int MinimumDamage { get; }

        public int RewardExpiriencePoints { get; }


        public Monster(string name, int maxHP, int currHitPoints, int maxDamage, int minDamage, int rewExp, int rewGold, string img)
            : base(name, maxHP, currHitPoints, rewGold)
        {
            MaximumDamage = maxDamage;
            MinimumDamage = minDamage;
            RewardExpiriencePoints = rewExp;
            ImageName = string.Format(@"D:\C#repos\WPF\GaneAdventureWPF\Engine\Images\Monsters\{0}", img);

        }
    }
}
