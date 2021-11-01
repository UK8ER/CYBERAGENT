using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalView : MonoBehaviour
{
    [SerializeField]
    private Canvas _ModalCanvas;

    [SerializeField]
    private InputField _InputField;

    /// <summary>
    /// モーダルを開く
    /// </summary>
    public void OpenModal()
    {
        _ModalCanvas.enabled = true;
    }

    /// <summary>
    /// モーダルを閉じる
    /// </summary>
    public void CloseModal()
    {
        _ModalCanvas.enabled = false;
    }
}
