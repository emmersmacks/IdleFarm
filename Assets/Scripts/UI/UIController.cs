using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace FarmIdle.Game.Controllers
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] internal TextMeshProUGUI MoneyText;
        [SerializeField] internal RectTransform MoneyPanel;
        [SerializeField] internal TextMeshProUGUI HaystackPanel;
        [SerializeField] private DataController _dataController;

        private Tweener _tween;
        private Vector3 _defaultMoneyPanelPosition;

        private async UniTask Start()
        {
            await UniTask.Delay(100);
            _dataController.Data.HaystackIncrement += HaystackPanelUpdate;
            _dataController.Data.HaystackDecrement += HaystackPanelUpdate;
            _dataController.Data.MoneyCountChange += MoneyCountChange;
            _defaultMoneyPanelPosition = MoneyPanel.transform.position;
        }

        private void HaystackPanelUpdate()
        {
            HaystackPanel.text = string.Format("{0}/{1}", _dataController.Data.CurrentHeystackCount, _dataController.Data.MaxHeystackSize);
        }

        private void MoneyCountChange()
        {
            MoneyText.text = _dataController.Data.Money.ToString();
            MoneyPanelAnimationStart();
        }

        public void MoneyPanelAnimationStart()
        {
            if (_tween != null)
            {
                _tween.Restart();
            }
            else
            {
                MoneyPanel.transform.DOShakePosition(1, 10);
            }
        }
    }
}

