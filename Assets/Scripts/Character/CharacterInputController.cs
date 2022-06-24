using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Cysharp.Threading.Tasks;

namespace FarmIdle.Game.Controllers
{
    public class CharacterInputController : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;

        internal float InputAxisVertical;
        internal float InputAxisHorizontal;
        internal bool InputIsActive = true;
        private CharacterAnimationController _characterAnimationController;

        private InputState _inputState = InputState.idle;

        internal InputState CurrentState
        {
            get
            {
                return _inputState;
            }
            set
            {
                _inputState = value;
            }
        }

        const string _inputHorizontalName = "Horizontal";
        const string _inputVerticalName = "Vertical";

        private void Start()
        {
            _characterAnimationController = GetComponent<CharacterAnimationController>();
        }

        private void Update()
        {
            PhoneInput();
            //KeyboardInput();
        }

        private void PhoneInput()
        {
            if (_joystick.Direction.x != 0 || _joystick.Direction.y != 0)
            {
                InputAxisVertical = _joystick.Direction.y;
                InputAxisHorizontal = _joystick.Direction.x;
                CurrentState = InputState.run;
            }
            else if (CurrentState != InputState.trimm)
            {
                InputAxisHorizontal = 0;
                InputAxisVertical = 0;
                CurrentState = InputState.idle;
            }
        }

        private void KeyboardInput()
        {
            if (Input.GetAxis(_inputHorizontalName) != 0 || Input.GetAxis(_inputVerticalName) != 0)
            {
                InputAxisVertical = Input.GetAxis(_inputVerticalName);
                InputAxisHorizontal = Input.GetAxis(_inputHorizontalName);
                CurrentState = InputState.run;
            }
            else if (CurrentState != InputState.trimm)
            {
                InputAxisHorizontal = 0;
                InputAxisVertical = 0;
                CurrentState = InputState.idle;
            }
        }
    }

    public enum InputState
    {
        idle = 0,
        run = 1,
        trimm = 2,
        none = -1
    }
}

