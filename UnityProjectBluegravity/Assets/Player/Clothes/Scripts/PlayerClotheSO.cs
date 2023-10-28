using UnityEngine;

namespace Bluegravity.Game.Player.Clothes
{
    [CreateAssetMenu(fileName = nameof(PlayerClotheSO), menuName = "ScriptableObjects/" + nameof(PlayerClotheSO), order = 1)]
    public class PlayerClotheSO : ScriptableObject
    {
        [Header("Setup")]
        [SerializeField]
        [Range(0f, PlayerClothesBehaviour.MaxLayer)]
        private int _layer = 0;
        [SerializeField]
        private Texture2D _texture;

        public int Layer { get => _layer; }
        public Texture2D Texture { get => _texture; }
    }

}