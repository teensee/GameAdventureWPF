using System;
using Engine.Models;

namespace Engine.Actions
{
    public class Heal : BaseAction, IAction
    {
        private readonly int _hitPointsToHeal;


        public Heal(GameItem itemInUse, int hitPointsToHeal)
            :base(itemInUse)
        {
            if(itemInUse.Category != GameItem.ItemCategory.Consumable)
            {
                throw new ArgumentException($"{itemInUse.Name} is not consumable");
            }

            _hitPointsToHeal = hitPointsToHeal;
        }

        public void Execute(LivingEntity actor, LivingEntity target)
        {
            string ActorName = (actor is Player) ? "You" : $"{actor.Name.ToLower()}";
            string TargetName = (target is Player) ? "yoursefl" : $"the {target.Name.ToLower()}";

            ReportResult($"{ActorName} heal {TargetName} for {_hitPointsToHeal} point{(_hitPointsToHeal > 1 ? "s" : "")}");
            target.Heal(_hitPointsToHeal);
        }

    }
}
