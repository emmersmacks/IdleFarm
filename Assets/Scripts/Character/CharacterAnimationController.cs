using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmIdle.Game.Controllers
{
    public class CharacterAnimationController : MonoBehaviour
    {
        private Animator _animator;

        private InputState _currentAnimation
        {
            get { return (InputState)_animator.GetInteger("State"); }
            set { _animator.SetInteger("State", (int)value); }
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetAnimation(InputState state)
        {
            _currentAnimation = state;
        }
    }
}

