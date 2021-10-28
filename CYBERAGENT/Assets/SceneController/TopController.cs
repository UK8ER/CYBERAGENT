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
        [SerializeField]
        private MissionButtonView _MissionButtonView;

        /// <summary>����t���O</summary>
        private bool _IsFirst;
        /// <summary>�~�b�V�����P�t���O</summary>
        private bool _Mission1ClearFlug;
        /// <summary>�~�b�V�����Q�t���O</summary>
        private bool _Mission2ClearFlug;

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
                Debug.LogFormat("M1:{0} M2:{1}",_Mission1ClearFlug,_Mission2ClearFlug);
            }
            // �~�b�V�����{�^���̕\������i�~�b�V�����P���N���A���Ă��Ȃ���΃~�b�V�����Q�͎�g�s�j
            _MissionButtonView.MissionButton2Active(_Mission1ClearFlug);
        }

        /// <summary>
        /// �{�^���������A�N�V����
        /// </summary>
        public void OnClickMissonButton(bool isMission1)
        {
            // GameManager�ɑI�������~�b�V������o�^
            if (isMission1)
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