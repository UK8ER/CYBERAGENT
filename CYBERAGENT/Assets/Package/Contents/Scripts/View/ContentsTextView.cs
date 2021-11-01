using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ContentsPackage
{
    public class ContentsTextView : MonoBehaviour
    {
        [Header("ContentsText")]
        /// <summary>コンテンツテキスト</summary>
        [SerializeField]
        private Text _ContentsText;

        /// <summary>
        /// コンテンツテキストをセットする
        /// </summary>
        public void SetContentsText(string text)
        {
            _ContentsText.text = text;
        }
    }
}