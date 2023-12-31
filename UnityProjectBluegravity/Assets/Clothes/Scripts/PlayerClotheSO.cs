﻿#if UNITY_EDITOR
using NaughtyAttributes;
# endif
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
        private string _id;
        [SerializeField]
        private float _price;
        [SerializeField]
        private string _itemName;
        private Sprite _sprite;

        public int Layer { get => _layer; }
        public Texture2D Texture { get => _texture; }
        public string Id { get => _id; }

        public Sprite GetIcon()
        {
            if (_sprite == null)
            {
                AnimationSprites sprites = new AnimationSprites(_texture, 8, 8);
                _sprite = sprites.GetSprites(PlayerStates.Idle, Vector2.left)[0];
            }
            return _sprite;
        }

        public string GetName()
        {
            return _itemName;
        }

        public float GetPrice()
        {
            return _price;
        }

#if UNITY_EDITOR
        [Button]
        public void SetId()
        {
            _id = $"Bluegravity.Item.clothe." + _texture.name;
            UnityEditor.EditorUtility.SetDirty(this);
        }
#endif
    }

}