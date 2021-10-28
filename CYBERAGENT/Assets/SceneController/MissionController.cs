using Common;
using Master;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Master.MissionData;

namespace MissionPackage
{
    public class MissionController : MonoBehaviour
    {
        #region Field
        [SerializeField]
        private TitleView _TitleView;

        [SerializeField]
        private SurveyButtonView _SurveyButtonView;

        [Header("Master")]
        [SerializeField]
        private MissionService _MissionService;

        /// <summary>選択中ミッション</summary>
        private Constants.MissionType _NowMission;

        /// <summary>選択中ミッション</summary>
        private Mission _Mission;
        #endregion

        void Start()
        {
            // GameManagerから選択したミッションを取得
            _NowMission = GameManager._NowMissionType;
            Debug.LogFormat("現在のミッション:{0}",_NowMission.ToString());

            // マスタからデータ取得
            _Mission = _MissionService.GetMission(_NowMission);

            // タイトル、ミッション内容を表示する
            _TitleView.SetText(_Mission.TitleText,_Mission.MissionText);

            // ボタンテキストを表示する
            _SurveyButtonView.SetSurveyButtonText(_Mission.MissionDetailList);
        }

        /// <summary>
        /// 「もどる」ボタン押下時アクション
        /// </summary>
        public void OnClickBackButton()
        {
            // 情報画面に遷移
            SceneManager.LoadScene(Constants.SCENE_TOP);
        }

        /// <summary>
        /// 調査ボタン押下時アクション
        /// </summary>
        public void OnClickServeyButton(int id)
        {
            GameManager._NowServeyId = id;
            // 情報画面に遷移
            SceneManager.LoadScene(Constants.SCENE_CONTENTS);
        }
    }
}