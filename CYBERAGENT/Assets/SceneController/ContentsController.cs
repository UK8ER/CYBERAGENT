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
        [Header("MissionService")]
        /// <summary>ミッションサービス</summary>
        [SerializeField]
        private MissionService _MissionService;

        [Header("Title")]
        /// <summary>タイトルビュー</summary>
        [SerializeField]
        private ServeyTitleView _ServeyTitleView;

        [Header("Contents")]
        /// <summary>コンテンツビュー</summary>
        [SerializeField]
        private ContentsTextView _ContentsTextView;

        [Header("Button")]
        /// <summary>InputCodeボタン</summary>
        [SerializeField]
        private InputCodeButtonView _InputCodeButtonView;

        [Header("Modal")]
        /// <summary>モーダルビュー</summary>
        [SerializeField]
        private ModalView _ModalView;

        [Header("InputField")]
        /// <summary>入力ボックス</summary>
        [SerializeField]
        private InputFieldView _InputFieldView;

        [Header("AnswerArea")]
        /// <summary>解答エリア</summary>
        [SerializeField]
        private AnswerAreaView _AnswerAreaView;

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

        /// <summary>Surveyクリアフラグ</summary>
        private bool _IsSuccess = false;

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
            // アニメーション初期化
            _AnimationView.AnimationInit();

            //すでに調査をクリアしている場合は、クリアモードに変更
            if (SaveController.GetMissonFlug(_NowMission, _NowServeyId) != 0)
            {
                SetClearMode();
            }
            else
            {
                SetUnclearMode();
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
                
                // クリアフラグをキャッシュ
                _IsSuccess = true;
            }
            else
            {
                Debug.Log("不正解");
                _AnimationView.SetAnimationText("FAILED");
                _SoundManager.NgSoundPlay();
            }

            // アニメーション再生
            _AnimationView.StartAnimation(AfterAnimation);
            
        }
        
        /// <summary>
        /// アニメーション再生終了後に呼び出される
        /// </summary>
        public void AfterAnimation()
        {
            Debug.Log("アニメーション終了");
            
            // クリアしていたら
            if (_IsSuccess)
            {
                // クリアモードに変更
                SetClearMode(); ;
                // PlayerPrefに保存
                SaveController.SetMissonFlug(_NowMission, _NowServeyId, 3);
            }
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

        /// <summary>
        /// クリアモード
        /// </summary>
        private void SetClearMode()
        {
            // InputCodeボタンを非表示
            _InputCodeButtonView.InactiveButton();
            // 解答エリアを表示
            _AnswerAreaView.SetAnswerText(_Servey.AnswerText);
            _AnswerAreaView.ActiveAnswerArea();
        }

        /// <summary>
        /// アンクリアモード
        /// </summary>
        private void SetUnclearMode()
        {
            // InputCodeボタンを表示
            _InputCodeButtonView.ActiveButton();
            // クリアしていない場合は、解答エリアを表示しない
            _AnswerAreaView.InactiveAnswerArea();
        }
    }
}