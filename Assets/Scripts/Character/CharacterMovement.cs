using TMPro;
using UnityEngine;

namespace TopDownAdventure
{
    [System.Serializable]
    public class CharacterMovement
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _smoothRotationSpeed;

        public CharacterMovement(CharacterController characterController, float movementSpeed = 5.2f, float smoothRotationSpeed = 10f)
        {
            this._characterController = characterController;
            this._movementSpeed = movementSpeed;
            this._smoothRotationSpeed = smoothRotationSpeed;
        }

        public float Rotate(Vector2 inputDirection, float deltaTime)
        {
            if (inputDirection.magnitude == 0)
                return -1;
            
            // 1 - Find angle from input
            float desiredAngle = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;

            // 2 - Smooth
            float angle = Mathf.LerpAngle(_characterController.transform.eulerAngles.y, desiredAngle, _smoothRotationSpeed * deltaTime);

            // 3 - Rotate
            _characterController.transform.rotation = Quaternion.Euler(0f, angle, 0f);
            return angle;
        }


        public void Move(Vector2 inputDirection, float angle, float deltaTime)
        {
            if (inputDirection.magnitude == 0)
                return;

            // 1 - Normalize to keep speed consistent in diagonals
            inputDirection.Normalize();

            // 2 - Rotate the forward vector to align with our rotation angle and this will represent the 3D Vector where our character should move
            Vector3 movementDirection = new Vector3(inputDirection.x, 0f, inputDirection.y) ; // Quaternion.Euler(0f, angle, 0f) * Vector3.forward * _movementSpeed;
            _characterController.Move(movementDirection * _movementSpeed * deltaTime);

        }

    }
}
