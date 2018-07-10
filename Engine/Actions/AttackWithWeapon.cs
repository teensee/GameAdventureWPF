﻿using System;
using Engine.Models;

namespace Engine.Actions
{
    public class AttackWithWeapon
    {
        private readonly GameItem _weapon;
        private readonly int _maximumDamage;
        private readonly int _minimumDamage;

        public event EventHandler<string> OnActionPerformed;

        public AttackWithWeapon(GameItem weapon, int minimumDamage, int maximumDamage)
        {
            if(weapon.Category != GameItem.ItemCategory.Weapon)
            {
                throw new ArgumentException($"{weapon.Name} is not a weapon");
            }

            if (_minimumDamage < 0)
                throw new ArgumentException("minimumdamage must be 0 or large");

            if (_maximumDamage < _minimumDamage)
                throw new ArgumentException("maximumdamage must be >= minimumdamage");

            _weapon = weapon;
            _minimumDamage = minimumDamage;
            _maximumDamage = maximumDamage;
        }

        public void Execute(LivingEntity actor, LivingEntity target)
        {
            int damage = RandomNumberGenerator.NumberBetween(_minimumDamage, _maximumDamage);

            if (damage == 0)
                ReportResult($"You missed the {target.Name}.");
            else
            {
                ReportResult($"You hit the {target.Name} for {damage} points.");
                target.TakeDamage(damage);
            }
      
        }


        private void ReportResult(string result)
        {
            OnActionPerformed?.Invoke(this, result);
        }
    }
}
