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
        /// 入力された値をリセットする
        /// </summary>
        public void ResetInputWord()
        {
            _InputField.text = "";
        }

        /// <summary>
        /// 入力された値の正誤判定を行う
        /// </summary>
        public bool IsSuccess(string answer)
        {
            return _InputField.text == answer;
        }
    }
}