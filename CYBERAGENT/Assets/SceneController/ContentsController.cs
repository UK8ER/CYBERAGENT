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

        [Header("SoundManager")]
        /// <summary>�T�E���h�}�l�[�W��</summary>
        [SerializeField]
        private SoundManager _SoundManager;

        /// <summary>�I�𒆃~�b�V����</summary>
        private Constants.MissionType _NowMission;
        /// <summary>�I�𒆒���ID</summary>
        private int _NowServeyId;
        /// <summary>�I�𒆃~�b�V����</summary>
        private Mission _Mission;
        #endregion

        void Start()
        {
            // GameManager����I�������~�b�V�����ƒ���ID���擾
            _NowMission = GameManager._NowMissionType;
            _NowServeyId = GameManager._NowServeyId;
            Debug.LogFormat("���݂̃~�b�V����:{0}", _NowMission.ToString());
            Debug.LogFormat("���݂̒���ID:{0}", _NowServeyId.ToString());

            // �}�X�^����f�[�^�擾
            _Mission = _MissionService.GetMission(_NowMission);

            // �^�C�g���A�~�b�V�������e��\������
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
        /// ���̓{�b�N�X�������A�N�V����
        /// </summary>
        public void OnClickInputBox()
        {
            // SE�Đ�
            _SoundManager.ButtonSESoundPlay();
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