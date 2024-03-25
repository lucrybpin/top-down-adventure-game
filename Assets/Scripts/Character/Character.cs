using UnityEngine;

namespace TopDownAdventure
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;

        private void Awake()
        {
            _characterMovement = new CharacterMovement(_characterController);
            _characterAnimation = new CharacterAnimation(_animator);
        }

        public void MoveFromInput(Vector2 movementInput)
        {
            float angle = _characterMovement.Rotate(movementInput, Time.deltaTime);
            _characterMovement.Move(movementInput, angle, Time.deltaTime);
            _characterAnimation.UpdateMovementAnimation(movementInput);
        }
    }
}
