using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ContentsPackage
{
    public class ContentsTextView : MonoBehaviour
    {
        [SerializeField]
        private Text _ContentsText;

        /// <summary>
        /// �R���e���c�e�L�X�g���Z�b�g����
        /// </summary>
        public void SetContentsText(string text)
        {
            _ContentsText.text = text;
        }
    }
}