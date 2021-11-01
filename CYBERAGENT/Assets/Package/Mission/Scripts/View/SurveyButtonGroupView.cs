using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Master.MissionData;

namespace MissionPackage
{
    public class SurveyButtonGroupView : MonoBehaviour
    {
        [Header("SurveyButton")]
        [SerializeField]
        private SurveyButtonView[] _SurveyButtonViews;

        [Header("SurveyButtonSprite")]
        [SerializeField]
        private Sprite _BasicSPrite;
        [SerializeField]
        private Sprite _SLankSPrite;
        [SerializeField]
        private Sprite _ALankSPrite;
        [SerializeField]
        private Sprite _BLankSPrite;

        private void Start()
        {
            for(int i = 0; i < _SurveyButtonViews.Length; i++)
            {
                _SurveyButtonViews[i].SurveyButtonId = 0;
            }
        }
        /// <summary>
        /// ボタンテキストをセットする
        /// </summary>
        public void SetSurveyButtonText(List<Servey> missionDetails)
        {
            for (int i = 0; i < missionDetails.Count; i++)
            {
                if (_SurveyButtonViews[i].SurveyButtonId == missionDetails[i].ServeyId)
                {
                    // テキストセット
                    _SurveyButtonViews[i].SetSurveyButtonText(missionDetails[i].ServeyTitle);
                }
            }
        }
        /// <summary>
        /// ボタンイメージをセットする
        /// </summary>
        public void SetSurveyButtonImage(Constants.MissionType missionType)
        {
            for (int i = 0; i < 4; i++)
            {
                if (SaveController.GetMissonFlug(missionType, i) == 3)
                {
                    if (i == _SurveyButtonViews[i].SurveyButtonId)
                    {
                        _SurveyButtonViews[i].SetSurveyButtonImage(_SLankSPrite);
                    }
                }
                else if (SaveController.GetMissonFlug(missionType, i) == 2)
                {
                    if (i == _SurveyButtonViews[i].SurveyButtonId)
                    {
                        _SurveyButtonViews[i].SetSurveyButtonImage(_ALankSPrite);
                    }
                }
                else if (SaveController.GetMissonFlug(missionType, i) == 1)
                {
                    if (i == _SurveyButtonViews[i].SurveyButtonId)
                    {
                        _SurveyButtonViews[i].SetSurveyButtonImage(_BLankSPrite);
                    }
                }
                else
                {
                    if (i == _SurveyButtonViews[i].SurveyButtonId)
                    {
                        _SurveyButtonViews[i].SetSurveyButtonImage(_BasicSPrite);
                    }
                };
            }

        }
    }
}