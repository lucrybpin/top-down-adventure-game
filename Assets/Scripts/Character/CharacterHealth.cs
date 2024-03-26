using UnityEngine;

namespace TopDownAdventure
{
    [System.Serializable]
    public class CharacterHealth
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _currentHealth;

        public CharacterHealth(float maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }

        public void ReceiveDamage(float damage)
        {
            _currentHealth -= damage; 
        }
    }
}
