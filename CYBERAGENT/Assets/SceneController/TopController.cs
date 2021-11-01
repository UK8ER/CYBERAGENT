using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TopPackage
{
    public class TopController : MonoBehaviour
    {
        #region Field
        [Header("MissionButton")]
        /// <summary>ミッションボタン</summary>
        [SerializeField]
        private MissionButtonView _MissionButtonView;
        
        [Header("SoundManager")]
        /// <summary>サウンドマネージャ</summary>
        [SerializeField]
        private SoundManager _SoundManager;

        /// <summary>初回フラグ</summary>
        private bool _IsFirst;
        /// <summary>ミッション１フラグ</summary>
        private bool _Mission1ClearFlug;
        /// <summary>ミッション２フラグ</summary>
        private bool _Mission2ClearFlug;
        /// <summary>現在取り組んでいるミッションフラグ</summary>
        private bool _IsMission1;
        #endregion

        void Start()
        {
            // 初回フラグを取得
            _IsFirst = SaveController.GetFirstFlug();

            // 初回の場合
            if (_IsFirst)
            {
                // ミッションフラグを初期化
                SaveController.InitMissionFlug();
                // 初回フラグを解除
                SaveController.SetFirstFlug();
            }
            // 初回ではない場合
            else
            {
                // ミッションフラグを取得
                _Mission1ClearFlug = SaveController.GetMissonFlug(Constants.MissionType.Mission1);
            }
            // ミッションボタンの表示制御（ミッション１をクリアしていなければミッション２は取組不可）
            _MissionButtonView.MissionButton2Active(_Mission1ClearFlug);
        }

        /// <summary>
        /// ボタン押下時アクション
        /// </summary>
        public void OnClickMissonButton(bool isMission1)
        {
            // グローバル変数にキャッシュ
            _IsMission1 = isMission1;

            // SE再生
            _SoundManager.ButtonSESoundPlay(OnClickMissionButtonAction);

        }
        private void OnClickMissionButtonAction()
        {
            // GameManagerに選択したミッションを登録
            if (_IsMission1)
            {
                GameManager._NowMissionType = Constants.MissionType.Mission1;
            }
            else
            {
                GameManager._NowMissionType = Constants.MissionType.Mission2;
            }
            // 情報画面に遷移
            SceneManager.LoadScene(Constants.SCENE_MISSION);
        }
    }
}