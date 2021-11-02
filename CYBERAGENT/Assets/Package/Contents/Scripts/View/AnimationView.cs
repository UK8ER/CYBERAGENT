using DG.Tweening;
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
        private Text _AnimationText;
        [SerializeField]
        private Transform _AnimationPanel;
        [SerializeField]
        private GameObject _BackGroundPanel;

        public void SetAnimationText(string text)
        {
            _AnimationText.text = text;
        }

        public void AnimationInit()
        {
            Sequence _Sequence = DOTween.Sequence()
                .OnStart(() => _BackGroundPanel.SetActive(false))
                .AppendCallback(() => _AnimatorCanvas.enabled = false)
                .Join(_AnimationPanel.DOLocalMove(new Vector3(2160, 0, 0), 0))
                .AppendCallback(() => _AnimatorCanvas.enabled = true);
        }

        public void StartAnimation(Action finish)
        {
            //_Coroutine = StartCoroutine(StartAnimationAction1());
            Sequence _Sequence = DOTween.Sequence()
                .OnStart(() => _BackGroundPanel.SetActive(true))
                .AppendCallback(() => _AnimatorCanvas.enabled = false)
                .Join(_AnimationPanel.DOLocalMove(new Vector3(2160, 0, 0), 0))
                .AppendCallback(() => _AnimatorCanvas.enabled = true)
                .Join(_AnimationPanel.DOLocalMove(Vector3.zero, 0.5f))
                .AppendInterval(3.0f)
                .Append(_AnimationPanel.DOLocalMove(new Vector3(-2160, 0, 0), 0.5f))
                .AppendCallback(() => _BackGroundPanel.SetActive(false))
                .AppendCallback(()=>finish());
        }
    }
}