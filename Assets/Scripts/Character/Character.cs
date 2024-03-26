using System.Collections.Generic;
using UnityEngine;

namespace TopDownAdventure
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour, IDamageable
    {
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private CharacterCombat _characterCombat;
        [SerializeField] private CharacterHealth _characterHealth;
        [SerializeField] private Animator _animator;

        [SerializeField] private Transform _hitPosition;

        private void Awake()
        {
            _characterMovement = new CharacterMovement(_characterController);
            _characterAnimation = new CharacterAnimation(_animator);
            _characterCombat = new CharacterCombat(_hitPosition, 1);
            _characterHealth = new CharacterHealth(100);
        }

        public void MoveFromInput(Vector2 movementInput)
        {
            float angle = _characterMovement.Rotate(movementInput, Time.deltaTime);
            _characterMovement.Move(movementInput, angle, Time.deltaTime);
            _characterAnimation.UpdateMovementAnimation(movementInput);
        }

        public void AttackFromInput(bool rightClick)
        {
            if (!rightClick)
                return;

            List<IDamageable> damageables = _characterCombat.GetDamageablesInRange();
            foreach (IDamageable damageable in damageables)
            {
                if (damageable.Owner() == gameObject)
                    continue;

                damageable.ReceiveDamage(_characterCombat.GetDamage());

            }
            _characterAnimation.UpdateAttackAnimation(rightClick);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_hitPosition.position, 0.7f);
        }

        public GameObject Owner()
        {
            return gameObject;
        }

        public void ReceiveDamage(float damage)
        {
            _characterHealth.ReceiveDamage(damage); 
        }
    }
}
