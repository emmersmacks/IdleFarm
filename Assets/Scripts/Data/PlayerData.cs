using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmIdle.Data
{
    public class PlayerData
    {
        private int _currentHaystackCount = 0;
        private int _money = 0;
        public int MaxHeystackSize { get; } = 40;
        public int CurrentHeystackCount
        {
            get { return _currentHaystackCount; }
            set
            {

                if (value > _currentHaystackCount)
                {
                    _currentHaystackCount = value;
                    HaystackIncrement();
                }
                else
                {
                    _currentHaystackCount = value;
                    HaystackDecrement();
                }

            }
        }
        public int Money
        {
            get { return _money; }
            set
            {
                _money = value;
                MoneyCountChange();
            }
        }

        public Action HaystackDecrement = default;
        public Action HaystackIncrement = default;

        public Action MoneyCountChange = default;
    }
}

