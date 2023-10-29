using Bluegravity.Game.Player;
using UnityEngine;

namespace Bluegravity.Game
{
    public class AreaLimits : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        private PlayerBehaviour _player;
        [SerializeField]
        private Transform _center;


        [Header("Setup")]
        [SerializeField]
        private float _radius = float.MaxValue;
        [SerializeField]
        private float _delay = 3;

        private float _time;

        private bool IsPlayerOutSide => Vector3.Distance(transform.position, _player.transform.position) > _radius;
        private float Lerp => _time / _delay;

        private void Update()
        {
            if (IsPlayerOutSide)
            {
                _time += Time.deltaTime;
                if (Lerp > 1)
                {
                    _player.MoveTo(_center.position);
                }
            }
            else
            {
                _time = 0;
            }
        }

        private void OnDrawGizmos()
        {
            if (_player == null) return;
            if (_center == null) return;

            Gizmos.color = Color.Lerp(Color.green, Color.red, Lerp);
            Gizmos.DrawWireSphere(_center.position, _radius);
        }

    }
}
