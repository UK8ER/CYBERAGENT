using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MissionPackage
{
    public class SurveyButtonView : MonoBehaviour
    {
        [Header("SurveyButtonID")]
        public int SurveyButtonId;

        [Header("SurveyButtonText")]
        [SerializeField]
        private Text _SurveyBUttonText;

        [Header("SurveyButtonImage")]
        [SerializeField]
        private Image _SurveyBUttonImage;

        /// <summary>
        /// �{�^���e�L�X�g���Z�b�g����
        /// </summary>
        public void SetSurveyButtonText(string text)
        {
            _SurveyBUttonText.text = text;
        }

        /// <summary>
        /// �{�^���摜���Z�b�g����
        /// </summary>
        public void SetSurveyButtonImage(Sprite sprite)
        {
            _SurveyBUttonImage.sprite = sprite;
        }
    }
}