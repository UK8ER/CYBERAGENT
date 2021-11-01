using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class AnimationView : MonoBehaviour
    {
        [SerializeField]
        private Canvas _AnimatorCanvas;
        [SerializeField]
        private Animator _Animator;
        [SerializeField]
        private Text _AnimationText;

        private Coroutine _Coroutine;
        public void SetAnimationText(string text)
        {
            _AnimationText.text = text;
        }

        public void StartAnimation()
        {
            StartAnimationAction1(StartAnimationAction2);
        }

        private void StartAnimationAction1(Action callback)
        {
            _AnimatorCanvas.enabled = true;
            callback();
        }
        private void StartAnimationAction2()
        {
            _Animator.enabled = true;
        }


        public void StopAnimation()
        {
            StopAnimationAction1(StopAnimationAction2);
        }
        private void StopAnimationAction1(Action callback)
        {
            _Animator.enabled = false;
            callback();
        }
        private void StopAnimationAction2()
        {
            _AnimatorCanvas.enabled = false;
        }

    }
}