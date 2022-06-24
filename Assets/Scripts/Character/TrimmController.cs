using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using FarmIdle.Game.Components;

namespace FarmIdle.Game.Controllers
{
    public class TrimmController : MonoBehaviour
    {
        [SerializeField] private Button trimButton;
        [SerializeField] private SickleComponent trimmController;
        [SerializeField] private AnimationClip _trimmAnimation;

        private CharacterAnimationController _characterAnimationController;
        private CharacterInputController _characterInputController;

        private void Start()
        {
            trimButton.onClick.AddListener(delegate { TrimmStart(); });
            _characterAnimationController = GetComponent<CharacterAnimationController>();
            _characterInputController = GetComponent<CharacterInputController>();
        }

        private async UniTask TrimmStart()
        {
            if (_characterInputController.CurrentState != InputState.run)
            {
                _characterInputController.CurrentState = InputState.trimm;
                _characterAnimationController.SetAnimation(_characterInputController.CurrentState);
                trimmController.gameObject.SetActive(true);
                await UniTask.Delay(((int)(_trimmAnimation.length * 1000)));
                trimmController.gameObject.SetActive(false);
                _characterAnimationController.SetAnimation(InputState.idle);
            }
        }
    }
}

