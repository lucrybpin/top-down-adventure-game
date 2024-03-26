using UnityEngine;

namespace TopDownAdventure
{
    public interface IDamageable
    {
        public GameObject Owner();
        public void ReceiveDamage(float damage); 
    }
}
