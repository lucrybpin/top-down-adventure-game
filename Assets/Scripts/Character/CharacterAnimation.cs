using UnityEngine;

namespace TopDownAdventure
{
    [System.Serializable]
    public class CharacterAnimation
    {
        [SerializeField] private Animator _animator;
        
        public CharacterAnimation(Animator animator)
        {
            this._animator = animator;
        }

        public void UpdateMovementAnimation(Vector2 movementInput)
        {
            bool isMoving = false;
            if (movementInput.magnitude > 0)
            {
                isMoving = true;
            }
            _animator.SetBool("isMoving", isMoving);
        }

        public void UpdateAttackAnimation(bool attackInput)
        {
            if (attackInput)
            {
                _animator.SetTrigger("Attack");
            }
        }

    }
}
