using Bluegravity.Game.Item;
using UnityEngine;
using Bluegravity.Game.Player.Animation;

namespace Bluegravity.Game.Clothes
{
    [CreateAssetMenu(fileName = nameof(PlayerClotheSO), menuName = "ScriptableObjects/" + nameof(PlayerClotheSO), order = 1)]
    public class PlayerClotheSO : ScriptableObject, IViewItem
    {
        [Header("Setup")]
        [SerializeField]
        [Range(1f, PlayerClothesBehaviour.MaxLayer)]
        private int _layer = 0;
        [SerializeField]
        private Texture2D _texture;


        [Header("Setup.Item")]
        [SerializeField]
        private float _price;
        [SerializeField]
        private string _itemName;

        public int Layer { get => _layer; }
        public Texture2D Texture { get => _texture; }

        public Sprite GetIcon()
        {
            AnimationSprites sprites = new AnimationSprites(_texture, 8, 8);
            return sprites.GetSprites(PlayerStates.Idle, Vector2.left)[0];
        }

        public string GetName()
        {
            return _itemName;
        }

        public float GetPrice()
        {
            return _price;
        }
    }

}