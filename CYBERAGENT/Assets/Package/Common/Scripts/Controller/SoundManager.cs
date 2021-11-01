using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class SoundManager : MonoBehaviour
    {
        [Header("AudioSource")]
        /// <summary>OkClip</summary>
        [SerializeField]
        private AudioSource _SoundPlayer;

        [Header("AudioClip")]
        /// <summary>ButtonSE</summary>
        [SerializeField]
        private AudioClip _ButtonSE;

        /// <summary>CanselClip</summary>
        [SerializeField]
        private AudioClip _SuccessSound;

        /// <summary>NGClip</summary>
        [SerializeField]
        private AudioClip _NgSound;

        //============================================================
        // �T�E���h�ݒ�
        //============================================================
        /// <summary>�{�����[���ݒ�</summary>
        private const float _Volume = 0.5f;
        /// <summary>���[�v�ݒ�</summary>
        private const bool _IsLoop = false;
        /// <summary>Awake�ݒ�</summary>
        private const bool _AwakePlay = false;
        //============================================================

        private void Start()
        {
            _SoundPlayer.volume = _Volume;
            _SoundPlayer.loop = _IsLoop;
            _SoundPlayer.playOnAwake = _AwakePlay;
        }

        /// <summary>
        /// �{�^����SE���Đ�
        /// </summary>
        public void ButtonSESoundPlay(Action callback)
        {
            Debug.Log("OK�T�E���h���Đ�");
            _SoundPlayer.clip = _ButtonSE;
            _SoundPlayer.Play();

            StartCoroutine(SoundPlayCoroutine(() =>
            {
                callback();
            }));

        }
        public void ButtonSESoundPlay()
        {
            Debug.Log("OK�T�E���h���Đ�");
            _SoundPlayer.clip = _ButtonSE;
            _SoundPlayer.Play();
        }

        /// <summary>
        /// Success��SE���Đ�
        /// </summary>
        public void SuccessPlay(Action callback)
        {
            Debug.Log("�T�N�Z�X�T�E���h���Đ�");
            _SoundPlayer.clip = _SuccessSound;
            _SoundPlayer.Play();

            StartCoroutine(SoundPlayCoroutine(() =>
            {
                callback();
            }));
        }
        public void SuccessPlay()
        {
            Debug.Log("�T�N�Z�X�T�E���h���Đ�");
            _SoundPlayer.clip = _SuccessSound;
            _SoundPlayer.Play();
        }

        /// <summary>
        /// NG��SE���Đ�
        /// </summary>
        public void NgSoundPlay(Action callback)
        {
            Debug.Log("NG�T�E���h���Đ�");
            _SoundPlayer.clip = _NgSound;
            _SoundPlayer.Play();

            StartCoroutine(SoundPlayCoroutine(() =>
            {
                callback();
            }));
        }
        public void NgSoundPlay()
        {
            Debug.Log("NG�T�E���h���Đ�");
            _SoundPlayer.clip = _NgSound;
            _SoundPlayer.Play();
        }

        /// <summary>
        /// SE���Đ�����܂Ŏ��̏����Ɉڍs�����Ȃ�����
        /// </summary>
        private IEnumerator SoundPlayCoroutine(Action callback)
        {
            while (true)
            {
                yield return new WaitForFixedUpdate();
                if (!_SoundPlayer.isPlaying)
                {
                    callback();
                    break;
                }
            }
        }
    }
}