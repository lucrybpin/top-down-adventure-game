using UnityEngine;

namespace TopDownAdventure.Player
{
    public class PlayerInputReader 
    {
        private PlayerControls _playerControls;

        private UnityEngine.Vector2 movementInput;

        public PlayerInputReader()
        {
            _playerControls= new PlayerControls();
        }

        public Vector2 ReadMovement()
        {
            return _playerControls.Player.Move.ReadValue<Vector2>();
        }

        public void OnEnable()
        {
            _playerControls.Enable();
        }

        public void OnDisable()
        {
            _playerControls.Disable();
        }
    }
}
