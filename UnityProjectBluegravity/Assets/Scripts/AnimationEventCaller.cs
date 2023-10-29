using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Bluegravity.Game.Animation
{
    public class AnimationEventCaller : MonoBehaviour
    {

        [Header("Setup")]
        [SerializeField]
        private UnityEvent _event;


        public void CallEvent()
        {
            _event.Invoke();
        }

    }

}