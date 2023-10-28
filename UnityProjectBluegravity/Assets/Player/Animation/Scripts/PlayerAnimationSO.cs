using System;
using UnityEngine;


namespace Bluegravity.Game.Player.Animation
{

    [CreateAssetMenu(fileName = nameof(PlayerAnimationSO), menuName = "ScriptableObjects/" + nameof(PlayerAnimationSO), order = 1)]
    public class PlayerAnimationSO : ScriptableObject, IComparable
    {
        [Header("Setup")]
        [SerializeField]
        private PlayerStates _state;
        [SerializeField]
        private Texture2D _texture;

        public PlayerStates State { get => _state; }
        public Texture2D Texture { get => _texture; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is PlayerAnimationSO animation)
            {
                int me = (int)_state;
                int other = (int)animation._state;
                return me.CompareTo(other);
            }


            throw new ArgumentException("Object is not a " + nameof(PlayerAnimationSO));
        }
               
        
    }
}
