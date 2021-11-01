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
    /// ���[�_�����J��
    /// </summary>
    public void OpenModal()
    {
        _ModalCanvas.enabled = true;
    }

    /// <summary>
    /// ���[�_�������
    /// </summary>
    public void CloseModal()
    {
        _ModalCanvas.enabled = false;
    }
}
