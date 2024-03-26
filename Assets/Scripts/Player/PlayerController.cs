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
            bool leftClick = _playerInputReader.LeftClick();
            _character.MoveFromInput(movementInput);
            _character.AttackFromInput(leftClick);
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
