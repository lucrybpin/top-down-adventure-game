using UnityEngine;

namespace TopDownAdventure
{
    [RequireComponent(typeof(CharacterController))]
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterMovement _characterMovement;
        [SerializeField] private CharacterController _characterController;

        private void Awake()
        {
            _characterMovement = new CharacterMovement(_characterController);
        }

        public void MoveFromInput(Vector2 movementInput)
        {
            float angle = _characterMovement.Rotate(movementInput, Time.deltaTime);
            _characterMovement.Move(movementInput, angle, Time.deltaTime);
        }
    }
}
