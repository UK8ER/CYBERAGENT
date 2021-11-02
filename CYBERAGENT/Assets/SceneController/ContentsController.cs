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
        /// <summary>�~�b�V�����T�[�r�X</summary>
        [SerializeField]
        private MissionService _MissionService;

        [Header("Title")]
        /// <summary>�^�C�g���r���[</summary>
        [SerializeField]
        private ServeyTitleView _ServeyTitleView;

        [Header("Contents")]
        /// <summary>�R���e���c�r���[</summary>
        [SerializeField]
        private ContentsTextView _ContentsTextView;

        [Header("Button")]
        /// <summary>InputCode�{�^��</summary>
        [SerializeField]
        private InputCodeButtonView _InputCodeButtonView;

        [Header("Modal")]
        /// <summary>���[�_���r���[</summary>
        [SerializeField]
        private ModalView _ModalView;

        [Header("InputField")]
        /// <summary>���̓{�b�N�X</summary>
        [SerializeField]
        private InputFieldView _InputFieldView;

        [Header("AnswerArea")]
        /// <summary>�𓚃G���A</summary>
        [SerializeField]
        private AnswerAreaView _AnswerAreaView;

        [Header("Animator")]
        /// <summary>�A�j���[�V�����r���[</summary>
        [SerializeField]
        private AnimationView _AnimationView;

        [Header("SoundManager")]
        /// <summary>�T�E���h�}�l�[�W��</summary>
        [SerializeField]
        private SoundManager _SoundManager;

        /// <summary>�I�𒆃~�b�V����</summary>
        private Constants.MissionType _NowMission;
        /// <summary>�I�𒆒���ID</summary>
        private int _NowServeyId;
        /// <summary>�I��Survey���X�g</summary>
        private List<Servey> _ServeyList;
        /// <summary>�I��Survey���</summary>
        private Servey _Servey;

        /// <summary>Survey�N���A�t���O</summary>
        private bool _IsSuccess = false;

        #endregion

        void Start()
        {
            // GameManager����I�������~�b�V�����ƒ���ID���擾
            _NowMission = GameManager._NowMissionType;
            _NowServeyId = GameManager._NowServeyId;
            Debug.LogFormat("���݂̃~�b�V����:{0}", _NowMission.ToString());
            Debug.LogFormat("���݂̒���ID:{0}", _NowServeyId.ToString());

            // �}�X�^����f�[�^�擾
            _ServeyList = _MissionService.GetMission(_NowMission).ServeyList;

            for(int i = 0; i < _ServeyList.Count; i++)
            {
                if (_ServeyList[i].ServeyId == _NowServeyId)
                {
                    _Servey = _ServeyList[i];
                }
            }

            // �^�C�g���A�~�b�V�������e��\������
            _ServeyTitleView.SetText(_Servey.ServeyTitle);
            _ContentsTextView.SetContentsText(_Servey.ServeyContents);

            // ���[�_���͏����\�����Ȃ�
            _ModalView.CloseModal();
            // �A�j���[�V����������
            _AnimationView.AnimationInit();

            //���łɒ������N���A���Ă���ꍇ�́A�N���A���[�h�ɕύX
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
        /// �u���ǂ�v�{�^���������A�N�V����
        /// </summary>
        public void OnClickBackButton()
        {
            // SE�Đ�
            _SoundManager.ButtonSESoundPlay(OnClickBackButtonAction);
        }
        private void OnClickBackButtonAction()
        {
            // ����ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_MISSION);
        }

        /// <summary>
        /// �R�[�h���̓{�^���������A�N�V����
        /// </summary>
        public void OnClickInputCodeButton()
        {
            // ���̓t�B�[���h�̃e�L�X�g�����Z�b�g
            _InputFieldView.ResetInputWord();
            // SE�Đ�
            _SoundManager.ButtonSESoundPlay(OnClickInputCodeButtonAction);
        }
        private void OnClickInputCodeButtonAction()
        {
            // ���[�_���\��
            _ModalView.OpenModal();
        }

        /// <summary>
        /// Submit�{�^���������A�N�V����
        /// </summary>
        public void OnClickSubmitButton()
        {
            // ���[�_�������
            _ModalView.CloseModal();
            // SE�Đ�
            _SoundManager.ButtonSESoundPlay(OnClickSubmitButtonAction);
        }
        private void OnClickSubmitButtonAction()
        {
            // ���딻��
            if(_InputFieldView.IsSuccess(_Servey.AnswerText))
            {
                Debug.Log("����");
                _AnimationView.SetAnimationText("SUCCESS");
                _SoundManager.SuccessPlay();
                
                // �N���A�t���O���L���b�V��
                _IsSuccess = true;
            }
            else
            {
                Debug.Log("�s����");
                _AnimationView.SetAnimationText("FAILED");
                _SoundManager.NgSoundPlay();
            }

            // �A�j���[�V�����Đ�
            _AnimationView.StartAnimation(AfterAnimation);
            
        }
        
        /// <summary>
        /// �A�j���[�V�����Đ��I����ɌĂяo�����
        /// </summary>
        public void AfterAnimation()
        {
            Debug.Log("�A�j���[�V�����I��");
            
            // �N���A���Ă�����
            if (_IsSuccess)
            {
                // �N���A���[�h�ɕύX
                SetClearMode(); ;
                // PlayerPref�ɕۑ�
                SaveController.SetMissonFlug(_NowMission, _NowServeyId, 3);
            }
        }

        /// <summary>
        /// ���[�_����ŕ���{�^���������A�N�V����
        /// </summary>
        public void OnClickCloseModalButton()
        {
            // SE�Đ�
            _SoundManager.ButtonSESoundPlay(OnClickCloseModalButtonAction);
        }
        private void OnClickCloseModalButtonAction()
        {
            // ���[�_�������
            _ModalView.CloseModal();
        }

        /// <summary>
        /// �N���A���[�h
        /// </summary>
        private void SetClearMode()
        {
            // InputCode�{�^�����\��
            _InputCodeButtonView.InactiveButton();
            // �𓚃G���A��\��
            _AnswerAreaView.SetAnswerText(_Servey.AnswerText);
            _AnswerAreaView.ActiveAnswerArea();
        }

        /// <summary>
        /// �A���N���A���[�h
        /// </summary>
        private void SetUnclearMode()
        {
            // InputCode�{�^����\��
            _InputCodeButtonView.ActiveButton();
            // �N���A���Ă��Ȃ��ꍇ�́A�𓚃G���A��\�����Ȃ�
            _AnswerAreaView.InactiveAnswerArea();
        }
    }
}