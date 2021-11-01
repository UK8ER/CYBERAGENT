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
        /// <summary>�~�b�V�����{�^��</summary>
        [SerializeField]
        private MissionButtonView _MissionButtonView;
        
        [Header("SoundManager")]
        /// <summary>�T�E���h�}�l�[�W��</summary>
        [SerializeField]
        private SoundManager _SoundManager;

        /// <summary>����t���O</summary>
        private bool _IsFirst;
        /// <summary>�~�b�V�����P�t���O</summary>
        private bool _Mission1ClearFlug;
        /// <summary>�~�b�V�����Q�t���O</summary>
        private bool _Mission2ClearFlug;
        /// <summary>���ݎ��g��ł���~�b�V�����t���O</summary>
        private bool _IsMission1;
        #endregion

        void Start()
        {
            // ����t���O���擾
            _IsFirst = SaveController.GetFirstFlug();

            // ����̏ꍇ
            if (_IsFirst)
            {
                // �~�b�V�����t���O��������
                SaveController.InitMissionFlug();
                // ����t���O������
                SaveController.SetFirstFlug();
            }
            // ����ł͂Ȃ��ꍇ
            else
            {
                // �~�b�V�����t���O���擾
                _Mission1ClearFlug = SaveController.GetMissonFlug(Constants.MissionType.Mission1);
            }
            // �~�b�V�����{�^���̕\������i�~�b�V�����P���N���A���Ă��Ȃ���΃~�b�V�����Q�͎�g�s�j
            _MissionButtonView.MissionButton2Active(_Mission1ClearFlug);
        }

        /// <summary>
        /// �{�^���������A�N�V����
        /// </summary>
        public void OnClickMissonButton(bool isMission1)
        {
            // �O���[�o���ϐ��ɃL���b�V��
            _IsMission1 = isMission1;

            // SE�Đ�
            _SoundManager.ButtonSESoundPlay(OnClickMissionButtonAction);

        }
        private void OnClickMissionButtonAction()
        {
            // GameManager�ɑI�������~�b�V������o�^
            if (_IsMission1)
            {
                GameManager._NowMissionType = Constants.MissionType.Mission1;
            }
            else
            {
                GameManager._NowMissionType = Constants.MissionType.Mission2;
            }
            // ����ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_MISSION);
        }
    }
}