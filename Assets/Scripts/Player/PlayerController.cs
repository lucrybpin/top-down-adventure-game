using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownAdventure.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputReader _playerInputReader;

        private void Awake()
        {
            _playerInputReader = new PlayerInputReader();
        }

        void Update()
        {
            Vector2 movementInput = _playerInputReader.ReadMovement();
            Debug.Log($"movementInput: {movementInput}");
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
