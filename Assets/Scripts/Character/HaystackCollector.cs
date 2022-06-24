using FarmIdle.Game.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmIdle.Game.Controllers
{
    public class HaystackCollector : MonoBehaviour
    {
        [SerializeField] DataController dataApplication;
        private void OnTriggerEnter(Collider other)
        {
            HaystackComponent haystack;
            if (other.TryGetComponent<HaystackComponent>(out haystack))
            {
                if (dataApplication.Data.CurrentHeystackCount < dataApplication.Data.MaxHeystackSize)
                {
                    Destroy(haystack.gameObject);
                    dataApplication.Data.CurrentHeystackCount++;
                }
            }
        }
    }
}

