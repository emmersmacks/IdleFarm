using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace FarmIdle.Game.Controllers
{
    public class BackPackController : MonoBehaviour
    {
        [SerializeField] private float _gridCellStepX;
        [SerializeField] private float _gridCellStepY;
        [SerializeField] private float _gridCellStepZ;
        [SerializeField] private GameObject _grid;
        [SerializeField] private GameObject _haystackPref;

        [SerializeField] private DataController _dataApplication;

        internal Stack<GameObject> _gridHaystack;

        const int maxZPosition = 4;
        const int maxXPosition = 6;

        private async UniTask Start()
        {
            _gridHaystack = new Stack<GameObject>();
            await UniTask.Delay(100);
            _dataApplication.Data.HaystackIncrement += AddHaystackInBackpack;
        }

        public void AddHaystackInBackpack()
        {
            if (_gridHaystack.Count == 0)
            {
                var haystack = InstantiateHaystack(new Vector3(0, 0, 0));
                _gridHaystack.Push(haystack);
            }
            else
            {
                var haystackPosition = _gridHaystack.Peek().transform.localPosition;
                if (haystackPosition.x == maxXPosition)
                {
                    if (haystackPosition.z == maxZPosition)
                    {
                        var haystack = InstantiateHaystack(new Vector3(0, haystackPosition.y + _gridCellStepY, 0));
                        _gridHaystack.Push(haystack);
                    }
                    else
                    {
                        var haystack = InstantiateHaystack(new Vector3(0, haystackPosition.y, haystackPosition.z + _gridCellStepZ));
                        _gridHaystack.Push(haystack);
                    }
                }
                else
                {
                    var haystack = InstantiateHaystack(new Vector3(haystackPosition.x + _gridCellStepX, haystackPosition.y, haystackPosition.z));
                    _gridHaystack.Push(haystack);
                }
            }
        }

        public GameObject GetHaystackInBackpack()
        {
            if (_gridHaystack.Count != 0)
                return _gridHaystack.Pop();
            else
                return null;
        }

        private GameObject InstantiateHaystack(Vector3 position)
        {
            var haystack = Instantiate(_haystackPref, _grid.transform);
            haystack.transform.parent = _grid.transform;
            haystack.transform.localPosition = position;
            return haystack;
        }
    }
}

