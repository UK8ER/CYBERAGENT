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
        [SerializeField]
        private TitleView _TitleView;

        [SerializeField]
        private SurveyButtonView _SurveyButtonView;

        [Header("Master")]
        [SerializeField]
        private MissionService _MissionService;

        /// <summary>�I�𒆃~�b�V����</summary>
        private Constants.MissionType _NowMission;

        /// <summary>�I�𒆃~�b�V����</summary>
        private Mission _Mission;
        #endregion

        void Start()
        {
            // GameManager����I�������~�b�V�������擾
            _NowMission = GameManager._NowMissionType;
            Debug.LogFormat("���݂̃~�b�V����:{0}",_NowMission.ToString());

            // �}�X�^����f�[�^�擾
            _Mission = _MissionService.GetMission(_NowMission);

            // �^�C�g���A�~�b�V�������e��\������
            _TitleView.SetText(_Mission.TitleText,_Mission.MissionText);

            // �{�^���e�L�X�g��\������
            _SurveyButtonView.SetSurveyButtonText(_Mission.MissionDetailList);
        }

        /// <summary>
        /// �u���ǂ�v�{�^���������A�N�V����
        /// </summary>
        public void OnClickBackButton()
        {
            // ����ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_TOP);
        }

        /// <summary>
        /// �����{�^���������A�N�V����
        /// </summary>
        public void OnClickServeyButton(int id)
        {
            GameManager._NowServeyId = id;
            // ����ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_CONTENTS);
        }
    }
}