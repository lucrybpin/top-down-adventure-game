using UnityEngine;

namespace TopDownAdventure.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputReader _playerInputReader;
        [SerializeField] private Character _character;

        private void Awake()
        {
            _playerInputReader = new PlayerInputReader();
        }

        void Update()
        {
            Vector2 movementInput = _playerInputReader.ReadMovement();
            _character.MoveFromInput(movementInput);
        }

        private void OnEnable()
        {
            _playerInputReader.OnEnable();
        }

        private void OnDisable()
        {
            _playerInputReader.OnDisable();
        }
    }
}
