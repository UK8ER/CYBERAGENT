using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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
        [SerializeField]
        private Transform _AnimationPanel;

        private Coroutine _Coroutine;

        /// <summary>コールバック用UnityEvent</summary>
        public class FinishAnimationEvent : UnityEvent { }
        private FinishAnimationEvent _FinishAnimationEvent = new FinishAnimationEvent();
        public FinishAnimationEvent FinishAnimation
        {
            get { return this._FinishAnimationEvent; }
            set { this._FinishAnimationEvent = value; }
        }

        public void SetAnimationText(string text)
        {
            _AnimationText.text = text;
        }

        public void StartAnimation()
        {
            _Coroutine = StartCoroutine(StartAnimationAction1());
        }
        private IEnumerator StartAnimationAction1()
        {
            //_AnimatorCanvas.enabled = true;
            yield return StartCoroutine("StartAnimationAction2");
        }
        private IEnumerator StartAnimationAction2()
        {
            _Animator.enabled = true;
            yield return null;
            yield return new WaitForSeconds(3.0f);
            
            // コールバック
            _FinishAnimationEvent.Invoke();
        }


        public void StopAnimation()
        {
            _Coroutine = StartCoroutine(StopAnimationAction1());
        }
        private IEnumerator StopAnimationAction1()
        {
            _Animator.enabled = false;
            yield return StartCoroutine("StopAnimationAction2");
        }
        private IEnumerator StopAnimationAction2()
        {
            //_AnimatorCanvas.enabled = false;
            ResetPosition();
            yield return null;
        }
        private void ResetPosition()
        {
            _AnimationPanel.localPosition = new Vector3(2160, 0, 0);
        }

    }
}