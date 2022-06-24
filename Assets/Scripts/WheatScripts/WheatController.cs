using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using FarmIdle.Game.Components;

namespace FarmIdle.Game.Controllers
{
    public class WheatController : MonoBehaviour
    {
        [SerializeField] private float rechargeTimeInSeconds;
        [SerializeField] private GameObject _wheatBoxPrefab;

        private SickleComponent sickle;

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.TryGetComponent<SickleComponent>(out sickle))
            {
                Instantiate(_wheatBoxPrefab, transform.position, Quaternion.identity);
                RechargeTimerStart();
            }
        }

        private async UniTask RechargeTimerStart()
        {
            gameObject.SetActive(false);
            await UniTask.Delay((int)(rechargeTimeInSeconds * 1000));
            gameObject.SetActive(true);
        }
    }
}

