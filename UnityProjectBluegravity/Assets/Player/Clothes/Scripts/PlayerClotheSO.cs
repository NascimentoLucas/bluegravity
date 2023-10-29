using Bluegravity.Game.Item;
using UnityEngine;

namespace Bluegravity.Game.Player.Clothes
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
        private Sprite _icon;
        [SerializeField]
        private string _itemName;

        public int Layer { get => _layer; }
        public Texture2D Texture { get => _texture; }

        public Sprite GetIcon()
        {
           return _icon;
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