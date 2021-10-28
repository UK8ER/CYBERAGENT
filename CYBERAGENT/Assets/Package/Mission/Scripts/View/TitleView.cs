using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MissionPackage
{
    public class TitleView : MonoBehaviour
    {
        [SerializeField]
        private Text _TitleText;

        [SerializeField]
        private Text _MissionText;

        /// <summary>
        /// タイトルテキスト、ミッションテキストをセットする
        /// </summary>
        public void SetText(string titleText,string missionText)
        {
            _TitleText.text = titleText;
            _MissionText.text = missionText;
        }
    }
}