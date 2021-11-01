using Common;
using Master;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Master.MissionData;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ContentsPackage
{
    public class ContentsController : MonoBehaviour
    {
        #region Field
        [Header("Title")]
        /// <summary>タイトルビュー</summary>
        [SerializeField]
        private ServeyTitleView _ServeyTitleView;

        [Header("Contents")]
        /// <summary>コンテンツビュー</summary>
        [SerializeField]
        private ContentsTextView _ContentsTextView;

        [Header("Modal")]
        /// <summary>モーダルビュー</summary>
        [SerializeField]
        private ModalView _ModalView;

        [Header("MissionService")]
        /// <summary>ミッションサービス</summary>
        [SerializeField]
        private MissionService _MissionService;

        [Header("InputField")]
        /// <summary>入力ボックス</summary>
        [SerializeField]
        private InputField _InputField;
        /// <summary>入力ボックステキスト</summary>
        [SerializeField]
        private Text _InputFieldText;

        [Header("SoundManager")]
        /// <summary>サウンドマネージャ</summary>
        [SerializeField]
        private SoundManager _SoundManager;

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
            _InputField.OnSelect();
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
            SceneManager.LoadScene(Constants.SCENE_MISSION);
        }

        /// <summary>
        /// コード入力ボタン押下時アクション
        /// </summary>
        public void OnClickInputCodeButton()
        {
            // SE再生
            _SoundManager.ButtonSESoundPlay(OnClickInputCodeButtonAction);
        }
        private void OnClickInputCodeButtonAction()
        {
            // モーダル表示
            _ModalView.OpenModal();
        }

        /// <summary>
        /// 入力ボックス押下時アクション
        /// </summary>
        public void OnClickInputBox()
        {
            // SE再生
            _SoundManager.ButtonSESoundPlay();
        }



        /// <summary>
        /// モーダル上で閉じるボタン押下時アクション
        /// </summary>
        public void OnClickCloseModalButton()
        {
            // SE再生
            _SoundManager.ButtonSESoundPlay(OnClickCloseModalButtonAction);
        }
        private void OnClickCloseModalButtonAction()
        {
            // モーダルを閉じる
            _ModalView.CloseModal();
        }
    }
}