using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bluegravity.Game.Economy
{
    [CreateAssetMenu(fileName = nameof(ClotheItemSO), menuName = "ScriptableObjects/" + nameof(ClotheItemSO), order = 1)]
    public class ClotheItemSO : ScriptableObject
    {
        [Header("GD")]
        [SerializeField]
        private int _int;

    }

}