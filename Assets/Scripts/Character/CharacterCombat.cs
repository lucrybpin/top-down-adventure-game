using System.Collections.Generic;
using UnityEngine;

namespace TopDownAdventure
{
    public class CharacterCombat
    {
        Transform _hitPosition;
        float _baseDamage;

        public CharacterCombat(Transform hitPosition, float baseDamage)
        {
            _hitPosition = hitPosition;
            _baseDamage = baseDamage;
        }

        public List<IDamageable> GetDamageablesInRange()
        {
            List<IDamageable> damageables = new List<IDamageable>();

            Collider[] colliders = Physics.OverlapSphere(_hitPosition.position, 0.7f);
            foreach (Collider collider in colliders)
            {
                if (collider.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    damageables.Add(damageable);
                }
            }

            return damageables;
        }

        public float GetDamage()
        {
            return _baseDamage;
        }

    }

}
