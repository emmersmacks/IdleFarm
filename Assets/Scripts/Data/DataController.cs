using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using FarmIdle.Data;

namespace FarmIdle.Game.Controllers
{
    public class DataController : MonoBehaviour
    {
        internal PlayerData Data;

        private void Start()
        {
            Data = new PlayerData();

        }
    }
}

