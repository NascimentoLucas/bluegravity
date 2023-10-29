using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bluegravity.Game.Save
{

    [Serializable]
    public class SaveData
    {
        [SerializeField]
        private float _gold;
        [SerializeField]
        private List<string> _itens;


    }

    public class SaveManager : MonoBehaviour
    {
        public static SaveManager Instance;

        private void Awake()
        {
            Instance = this;
        }
    }

}