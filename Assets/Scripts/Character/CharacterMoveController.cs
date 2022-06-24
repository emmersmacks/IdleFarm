using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmIdle.Game.Controllers
{
    public class CharacterMoveController : MonoBehaviour
    {
        [SerializeField] private CharacterInputController _inputController;

        [SerializeField] private float _movementSpeed;

        private CharacterController _characterController;
        private CharacterAnimationController _characterAnimationController;

        private Vector3 _direction;

        private void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _characterAnimationController = GetComponent<CharacterAnimationController>();
        }

        private void Update()
        {
            if (_inputController.CurrentState == InputState.run)
            {
                Move();
                Rotate();
                _characterAnimationController.SetAnimation(InputState.run);
            }
            else if (_inputController.CurrentState == InputState.idle)
            {
                _characterAnimationController.SetAnimation(InputState.idle);
            }
        }

        private void Move()
        {
            _direction = new Vector3(_inputController.InputAxisHorizontal, 0, _inputController.InputAxisVertical);
            _characterController.Move(_direction * Time.deltaTime * _movementSpeed);
        }

        private void Rotate()
        {
            transform.LookAt(_direction + transform.position);
        }
    }
}

