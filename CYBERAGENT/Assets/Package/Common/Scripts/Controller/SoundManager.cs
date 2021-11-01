using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private AudioClip _CanselSound;

    /// <summary>NGClip</summary>
    [SerializeField]
    private AudioClip _NgSound;

    //============================================================
    // サウンド設定
    //============================================================
    /// <summary>ボリューム設定</summary>
    private const float _Volume = 0.5f;
    /// <summary>ループ設定</summary>
    private const bool _IsLoop = false;
    /// <summary>Awake設定</summary>
    private const bool _AwakePlay = false;
    //============================================================

    private void Start()
    {
        _SoundPlayer.volume = _Volume;
        _SoundPlayer.loop = _IsLoop;
        _SoundPlayer.playOnAwake = _AwakePlay;
    }

    /// <summary>
    /// ボタンのSEを再生
    /// </summary>
    public void ButtonSESoundPlay(Action callback)
    {
        Debug.Log("OKサウンドを再生");
        _SoundPlayer.clip = _ButtonSE;
        _SoundPlayer.Play();

        StartCoroutine(SoundPlayCoroutine(() => {
            callback();
        }));
        
    }
    public void ButtonSESoundPlay()
    {
        Debug.Log("OKサウンドを再生");
        _SoundPlayer.clip = _ButtonSE;
        _SoundPlayer.Play();
    }

    /// <summary>
    /// CanselのSEを再生
    /// </summary>
    public void CanselPlay(Action callback)
    {
        Debug.Log("キャンセルサウンドを再生");
        _SoundPlayer.clip = _CanselSound;
        _SoundPlayer.Play();

        StartCoroutine(SoundPlayCoroutine(() =>
        {
            callback();
        }));
    }

    /// <summary>
    /// NGのSEを再生
    /// </summary>
    public void NgSoundPlay(Action callback)
    {
        Debug.Log("NGサウンドを再生");
        _SoundPlayer.clip = _NgSound;
        _SoundPlayer.Play();

        StartCoroutine(SoundPlayCoroutine(() =>
        {
            callback();
        }));
    }

    /// <summary>
    /// SEを再生するまで次の処理に移行させない処理
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
