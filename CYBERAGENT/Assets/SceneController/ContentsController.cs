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
        private InputFieldView _InputFieldView;

        [Header("Animator")]
        /// <summary>アニメーションビュー</summary>
        [SerializeField]
        private AnimationView _AnimationView;

        [Header("SoundManager")]
        /// <summary>サウンドマネージャ</summary>
        [SerializeField]
        private SoundManager _SoundManager;

        /// <summary>選択中ミッション</summary>
        private Constants.MissionType _NowMission;
        /// <summary>選択中調査ID</summary>
        private int _NowServeyId;
        /// <summary>選択中Surveyリスト</summary>
        private List<Servey> _ServeyList;
        /// <summary>選択中Survey情報</summary>
        private Servey _Servey;

        #endregion

        void Start()
        {
            // GameManagerから選択したミッションと調査IDを取得
            _NowMission = GameManager._NowMissionType;
            _NowServeyId = GameManager._NowServeyId;
            Debug.LogFormat("現在のミッション:{0}", _NowMission.ToString());
            Debug.LogFormat("現在の調査ID:{0}", _NowServeyId.ToString());

            // マスタからデータ取得
            _ServeyList = _MissionService.GetMission(_NowMission).ServeyList;

            for(int i = 0; i < _ServeyList.Count; i++)
            {
                if (_ServeyList[i].ServeyId == _NowServeyId)
                {
                    _Servey = _ServeyList[i];
                }
            }

            // タイトル、ミッション内容を表示する
            _ServeyTitleView.SetText(_Servey.ServeyTitle);
            _ContentsTextView.SetContentsText(_Servey.ServeyContents);

            // モーダルは初期表示しない
            _ModalView.CloseModal();

            // Animationを初期表示しない
            _AnimationView.StopAnimation();

            _AnimationView.FinishAnimation.AddListener(AfterAnimation);
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
            // 入力フィールドのテキストをリセット
            _InputFieldView.ResetInputWord();
            // SE再生
            _SoundManager.ButtonSESoundPlay(OnClickInputCodeButtonAction);
        }
        private void OnClickInputCodeButtonAction()
        {
            // モーダル表示
            _ModalView.OpenModal();
        }

        /// <summary>
        /// Submitボタン押下時アクション
        /// </summary>
        public void OnClickSubmitButton()
        {
            // モーダルを閉じる
            _ModalView.CloseModal();
            // SE再生
            _SoundManager.ButtonSESoundPlay(OnClickSubmitButtonAction);
        }
        private void OnClickSubmitButtonAction()
        {
            // 正誤判定
            if(_InputFieldView.IsSuccess(_Servey.AnswerText))
            {
                Debug.Log("正解");
                _AnimationView.SetAnimationText("SUCCESS");
                _SoundManager.SuccessPlay();
            }
            else
            {
                Debug.Log("不正解");
                _AnimationView.SetAnimationText("FAILED");
                _SoundManager.NgSoundPlay();
            }

            // アニメーション再生
            _AnimationView.StartAnimation();
            
        }
        
        /// <summary>
        /// アニメーション再生終了後に呼び出される
        /// </summary>
        public void AfterAnimation()
        {
            Debug.Log("アニメーション終了");
            _AnimationView.StopAnimation();
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