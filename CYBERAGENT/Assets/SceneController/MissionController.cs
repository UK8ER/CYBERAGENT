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
        /// <summary>�^�C�g��</summary>
        [SerializeField]
        private TitleView _TitleView;

        [Header("SurveyButton")]
        /// <summary>�����{�^��</summary>
        [SerializeField]
        private SurveyButtonGroupView _SurveyGroupButtonView;

        [Header("MissionAnswer")]
        /// <summary>�~�b�V�����̓���</summary>
        [SerializeField]
        private MissionAnswerView _MissionAnswerView;

        [Header("Master")]
        /// <summary>�~�b�V�����T�[�r�X</summary>
        [SerializeField]
        private MissionService _MissionService;

        [Header("SoundManager")]
        /// <summary>�T�E���h�}�l�[�W��</summary>
        [SerializeField]
        private SoundManager _SoundManager;

        /// <summary>�I�𒆃~�b�V����</summary>
        private Constants.MissionType _NowMission;

        /// <summary>�I�𒆃~�b�V����</summary>
        private Mission _Mission;

        /// <summary>�J�E���^�[</summary>
        private int _Counter;
        #endregion

        void Start()
        {
            // GameManager����I�������~�b�V�������擾
            _NowMission = GameManager._NowMissionType;
            Debug.LogFormat("���݂̃~�b�V����:{0}", _NowMission.ToString());

            // �}�X�^����f�[�^�擾
            _Mission = _MissionService.GetMission(_NowMission);

            // �^�C�g���A�~�b�V�������e��\������
            _TitleView.SetText(_Mission.TitleText, _Mission.MissionText);

            // �{�^���̃C���[�W��������
            _SurveyGroupButtonView.SetSurveyButtonImage(_NowMission);

            // �{�^���e�L�X�g��\������
            _SurveyGroupButtonView.SetSurveyButtonText(_Mission.ServeyList);

            _Counter = 0;
            // �~�b�V�������̒��������ׂăN���A���Ă���ꍇ
            for (int i = 0; i < 4; i++)
            {
                if (SaveController.GetMissonFlug(_NowMission, i) != 0)
                {
                    _Counter++;
                }
            }
            if (_Counter == 4)
            {
                _MissionAnswerView.ActiveAnswerText();
            }
            else
            {
                _MissionAnswerView.InactiveAnswerText();
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
            SceneManager.LoadScene(Constants.SCENE_TOP);
        }

        /// <summary>
        /// �����{�^���������A�N�V����
        /// </summary>
        public void OnClickServeyButton(int id)
        {
            // GameManager�ɑI�������{�^��ID���L���b�V��
            GameManager._NowServeyId = id;
            // SE�Đ�
            _SoundManager.ButtonSESoundPlay(OnClickServeyButtonAction);

        }
        private void OnClickServeyButtonAction()
        {
            // ����ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_CONTENTS);
        }
    }
}