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
        /// �^�C�g���e�L�X�g�A�~�b�V�����e�L�X�g���Z�b�g����
        /// </summary>
        public void SetText(string titleText,string missionText)
        {
            _TitleText.text = titleText;
            _MissionText.text = missionText;
        }
    }
}