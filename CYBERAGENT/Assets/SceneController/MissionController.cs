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
        [Header("Title")]
        /// <summary>タイトル</summary>
        [SerializeField]
        private TitleView _TitleView;

        [Header("SurveyButton")]
        /// <summary>調査ボタン</summary>
        [SerializeField]
        private SurveyButtonGroupView _SurveyGroupButtonView;

        [Header("MissionAnswer")]
        /// <summary>ミッションの答え</summary>
        [SerializeField]
        private MissionAnswerView _MissionAnswerView;

        [Header("Modal")]
        /// <summary>モーダル</summary>
        [SerializeField]
        private ModalView _ModalView;

        [Header("Master")]
        /// <summary>ミッションサービス</summary>
        [SerializeField]
        private MissionService _MissionService;

        [Header("SoundManager")]
        /// <summary>サウンドマネージャ</summary>
        [SerializeField]
        private SoundManager _SoundManager;

        /// <summary>選択中ミッション</summary>
        private Constants.MissionType _NowMission;

        /// <summary>選択中ミッション</summary>
        private Mission _Mission;

        /// <summary>カウンター</summary>
        private int _Counter;
        #endregion

        void Start()
        {
            // GameManagerから選択したミッションを取得
            _NowMission = GameManager._NowMissionType;
            Debug.LogFormat("現在のミッション:{0}", _NowMission.ToString());

            // マスタからデータ取得
            _Mission = _MissionService.GetMission(_NowMission);

            // タイトル、ミッション内容を表示する
            _TitleView.SetText(_Mission.TitleText, _Mission.MissionText);

            // ボタンのイメージを初期化
            _SurveyGroupButtonView.SetSurveyButtonImage(_NowMission);

            // ボタンテキストを表示する
            _SurveyGroupButtonView.SetSurveyButtonText(_Mission.ServeyList);

            // モーダルは非表示
            _ModalView.CloseModal();

            // ミッション内の調査をすべてクリアしている場合
            _Counter = 0;
            for (int i = 0; i < 4; i++)
            {
                if (SaveController.GetMissonFlug(_NowMission, i) != 0)
                {
                    _Counter++;
                }
            }
            if (_Counter == 4)
            {
                // AnserTextを表示
                _MissionAnswerView.ActiveAnswerText();
            }
            else
            {
                // AnserTextを非表示
                _MissionAnswerView.InactiveAnswerText();
            }
        } 

        /// <summary>
        /// 「もどる」ボタン押下時アクション
        /// </summary>
        public void OnClickBackButton()
        {
            // SE再生
            _SoundManager.ButtonSESoundPlay(OnClickBackButtonAction);
        }
        private void OnClickBackButtonAction()
        {
            // 情報画面に遷移
            SceneManager.LoadScene(Constants.SCENE_TOP);
        }

        /// <summary>
        /// 調査ボタン押下時アクション
        /// </summary>
        public void OnClickServeyButton(int id)
        {
            // GameManagerに選択したボタンIDをキャッシュ
            GameManager._NowServeyId = id;
            // SE再生
            _SoundManager.ButtonSESoundPlay(OnClickServeyButtonAction);

        }
        private void OnClickServeyButtonAction()
        {
            // 情報画面に遷移
            SceneManager.LoadScene(Constants.SCENE_CONTENTS);
        }

        /// <summary>
        /// TouchHereボタン押下時アクション
        /// </summary>
        public void OnClickTouchHereButton()
        {
            // SE再生
            _SoundManager.ButtonSESoundPlay(OnClickTouchHereButtonAction);
        }
        private void OnClickTouchHereButtonAction()
        {
            // AnswerWordをセット
            _ModalView.SetAnswerWord(_Mission.AnswerWord);
            // モーダルを表示
            _ModalView.OpenModal();
        }

        /// <summary>
        /// モーダルのClose押下時アクション
        /// </summary>
        public void OnClickCloseButton()
        {
            // SE再生
            _SoundManager.ButtonSESoundPlay(OnClickCloseButtonAction);
        }
        private void OnClickCloseButtonAction()
        {
            // モーダルを表示
            _ModalView.CloseModal();
        }
    }
}