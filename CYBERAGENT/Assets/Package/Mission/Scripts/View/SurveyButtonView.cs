using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Master.MissionData;

namespace MissionPackage
{
    public class SurveyButtonView : MonoBehaviour
    {
        [SerializeField]
        private Text[] _SurVeyBUttonTexts;

        /// <summary>
        /// ボタンテキストをセットする
        /// </summary>
        public void SetSurveyButtonText(List<Servey> missionDetails)
        {
            for (int i = 0; i < missionDetails.Count; i++)
            {
                if (i == missionDetails[i].ServeyId)
                {
                    _SurVeyBUttonTexts[i].text = missionDetails[i].ServeyTitle;
                }
            }
        }
    }
}