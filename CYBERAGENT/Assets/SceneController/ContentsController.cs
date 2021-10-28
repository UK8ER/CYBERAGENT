using Common;
using Master;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Master.MissionData;

namespace ContentsPackage
{
    public class ContentsController : MonoBehaviour
    {
        #region Field
        [SerializeField]
        private ServeyTitleView _ServeyTitleView;

        [SerializeField]
        private ContentsTextView _ContentsTextView;

        [Header("Master")]
        [SerializeField]
        private MissionService _MissionService;

        /// <summary>選択中ミッション</summary>
        private Constants.MissionType _NowMission;
        /// <summary>選択中調査ID</summary>
        private int _NowServeyId;
        /// <summary>選択中ミッション</summary>
        private Mission _Mission;
        #endregion

        void Start()
        {
            // GameManagerから選択したミッションと調査IDを取得
            _NowMission = GameManager._NowMissionType;
            _NowServeyId = GameManager._NowServeyId;
            Debug.LogFormat("現在のミッション:{0}", _NowMission.ToString());
            Debug.LogFormat("現在の調査ID:{0}", _NowServeyId.ToString());

            // マスタからデータ取得
            _Mission = _MissionService.GetMission(_NowMission);

            // タイトル、ミッション内容を表示する

            for(int i = 0; i < _Mission.MissionDetailList.Count; i++)
            {
                if (_Mission.MissionDetailList[i].MissionId == _NowServeyId)
                {
                    _ServeyTitleView.SetText(_Mission.MissionDetailList[i].ServeyTitle);
                    _ContentsTextView.SetContentsText(_Mission.MissionDetailList[i].ServeyContents);
                }
            }
        }

        /// <summary>
        /// 「もどる」ボタン押下時アクション
        /// </summary>
        public void OnClickBackButton()
        {
            // 情報画面に遷移
            SceneManager.LoadScene(Constants.SCENE_MISSION);
        }

        /// <summary>
        /// コード入力ボタン押下時アクション
        /// </summary>
        public void OnClickInputCodeButton(int id)
        {
            // 情報画面に遷移
            SceneManager.LoadScene(Constants.SCENE_CONTENTS);
        }
    }
}