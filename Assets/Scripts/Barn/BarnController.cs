using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using DG.Tweening;

namespace FarmIdle.Game.Controllers
{
    public class BarnController : MonoBehaviour
    {
        [SerializeField] private DataController _dataController;
        [SerializeField] private UIController _uiController;
        [SerializeField] private GameObject _haystackMagnet;
        [SerializeField] private GameObject _moneyImage;
        [SerializeField] private Transform _moneyOutput;

        private bool _isMoveHaystack = false;

        private void OnTriggerStay(Collider other)
        {
            BackPackController backPackController;
            if (other.TryGetComponent<BackPackController>(out backPackController))
            {
                MoveHaystackFromBackpack(backPackController);
            }
        }

        private void MoveHaystackFromBackpack(BackPackController backpack)
        {
            if (!_isMoveHaystack)
            {
                var haystack = backpack.GetHaystackInBackpack();
                if (haystack != null)
                    StartSail(haystack);
            }
        }

        private async UniTask StartSail(GameObject haystack)
        {
            await StartHaystackGrab(haystack);
            StartMoneyAdd();
        }

        private async UniTask StartHaystackGrab(GameObject haystack)
        {
            _isMoveHaystack = true;
            haystack.transform.parent = transform.parent;
            var tween = haystack.transform.DOMove(_haystackMagnet.transform.position, 1);
            await UniTask.Delay(100);
            _isMoveHaystack = false;
            await tween.AsyncWaitForCompletion();
            _dataController.Data.CurrentHeystackCount--;
            Destroy(haystack.gameObject);
        }

        private async UniTask StartMoneyAdd()
        {
            var money = Instantiate(_moneyImage, RectTransformUtility.WorldToScreenPoint(Camera.main, _moneyOutput.transform.position), Quaternion.identity, _uiController.transform);
            money.transform.SetSiblingIndex(0);
            var tweenMagnet = money.transform.DOLocalMove(new Vector3(761, 459), 1);
            await tweenMagnet.AsyncWaitForCompletion();
            _dataController.Data.Money += 15;
            Destroy(money.gameObject);
        }
    }
}

