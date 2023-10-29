using UnityEngine;

namespace Bluegravity.Game.View
{
    [RequireComponent(typeof(Animator))]
    public class AnimatorView : MonoBehaviour
    {
        private static AnimatorView _lastView;

        [Header("Setup")]
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private string _keyBool = "Show";


        public void Show(bool value)
        {
            if (_lastView != null && !_lastView.GetInstanceID().Equals(GetInstanceID()))
            {
                _lastView._animator.SetBool(_keyBool, false);
            }

            _lastView = this;
            _lastView._animator.SetBool(_keyBool, value);
        }
    }

}