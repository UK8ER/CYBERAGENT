using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ContentsPackage
{
    public class InputFieldView : MonoBehaviour
    {
        [SerializeField]
        private InputField _InputField;

        /// <summary>
        /// ���͂��ꂽ�l�����Z�b�g����
        /// </summary>
        public void ResetInputWord()
        {
            _InputField.text = "";
        }

        /// <summary>
        /// ���͂��ꂽ�l�̐��딻����s��
        /// </summary>
        public bool IsSuccess(string answer)
        {
            return _InputField.text == answer;
        }
    }
}