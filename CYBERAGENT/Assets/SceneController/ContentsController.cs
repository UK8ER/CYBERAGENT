using Common;
using Master;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Master.MissionData;

namespace ContentsPackage
{
    public class ContentsController : MonoBehaviour
    {
        #region Field
        [SerializeField]
        private ServeyTitleView _ServeyTitleView;

        [SerializeField]
        private ContentsTextView _ContentsTextView;

        [Header("Master")]
        [SerializeField]
        private MissionService _MissionService;

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
        }

        /// <summary>
        /// �u���ǂ�v�{�^���������A�N�V����
        /// </summary>
        public void OnClickBackButton()
        {
            // ����ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_MISSION);
        }

        /// <summary>
        /// �R�[�h���̓{�^���������A�N�V����
        /// </summary>
        public void OnClickInputCodeButton(int id)
        {
            // ����ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_CONTENTS);
        }
    }
}