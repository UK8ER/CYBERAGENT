using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ContentsPackage
{
    public class ServeyTitleView : MonoBehaviour
    {
        [SerializeField]
        private Text _TitleText;

        /// <summary>
        /// タイトルテキストをセットする
        /// </summary>
        public void SetText(string titleText)
        {
            _TitleText.text = titleText;
        }
    }
}