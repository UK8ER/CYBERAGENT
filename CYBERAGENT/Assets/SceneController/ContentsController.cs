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
        /// <summary>�^�C�g���r���[</summary>
        [SerializeField]
        private ServeyTitleView _ServeyTitleView;

        [Header("Contents")]
        /// <summary>�R���e���c�r���[</summary>
        [SerializeField]
        private ContentsTextView _ContentsTextView;

        [Header("Modal")]
        /// <summary>���[�_���r���[</summary>
        [SerializeField]
        private ModalView _ModalView;

        [Header("MissionService")]
        /// <summary>�~�b�V�����T�[�r�X</summary>
        [SerializeField]
        private MissionService _MissionService;

        [Header("InputField")]
        /// <summary>���̓{�b�N�X</summary>
        [SerializeField]
        private InputField _InputField;
        /// <summary>���̓{�b�N�X�e�L�X�g</summary>
        [SerializeField]
        private Text _InputFieldText;

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
        private Servey _Servey;
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

            // Animation�������\�����Ȃ�
            _AnimationView.StopAnimation();
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
            // SE�Đ�
            _SoundManager.ButtonSESoundPlay(OnClickSubmitButtonAction);
        }
        private void OnClickSubmitButtonAction()
        {
            // ���딻��
            if(_InputField.text== _Servey.AnswerText)
            {
                Debug.Log("����");
                _AnimationView.SetAnimationText("SUCCESS");

            }
            else
            {
                Debug.Log("�s����");
                _AnimationView.SetAnimationText("FAILED");
            }

            // �A�j���[�V�����Đ�
            _AnimationView.StartAnimation();
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
    }
}