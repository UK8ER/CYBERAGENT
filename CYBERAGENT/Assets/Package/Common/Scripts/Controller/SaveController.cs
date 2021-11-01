using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public static class SaveController
    {
        #region ����t���O
        /// <summary>
        /// ����t���O����������
        /// </summary>
        public static void SetFirstFlug()
        {
            PlayerPrefs.SetInt(Constants.FIRST_FLUG, 0);
            Save();
        }

        /// <summary>
        /// ����t���O���擾����{0:����ł͂Ȃ�}{1:����}
        /// </summary>
        public static bool GetFirstFlug()
        {
            if (PlayerPrefs.GetInt(Constants.FIRST_FLUG) == 1 || !PlayerPrefs.HasKey(Constants.FIRST_FLUG))
            {
                Debug.Log("����");
                return true;
            }
            else
            {
                Debug.Log("����ł͂Ȃ�");
                return false;
            }
        }
        #endregion

        #region �~�b�V�����t���O
        /// <summary>
        /// �~�b�V�����t���O������������
        /// </summary>
        public static void InitMissionFlug()
        {
            PlayerPrefs.SetInt(Constants.MISSION1 + "-0", 0);
            PlayerPrefs.SetInt(Constants.MISSION1 + "-1", 0);
            PlayerPrefs.SetInt(Constants.MISSION1 + "-2", 0);
            PlayerPrefs.SetInt(Constants.MISSION1 + "-3", 0);

            PlayerPrefs.SetInt(Constants.MISSION2 + "-0", 0);
            PlayerPrefs.SetInt(Constants.MISSION2 + "-1", 0);
            PlayerPrefs.SetInt(Constants.MISSION2 + "-2", 0);
            PlayerPrefs.SetInt(Constants.MISSION2 + "-3", 0);
            
            Save();
        }

        /// <summary>
        /// �w��̃~�b�V�����̃N���A�󋵂��Z�[�u����
        /// </summary>
        public static void SetMissonFlug(Constants.MissionType missionType, int serveyId, int clearNo)
        {
            switch (missionType)
            {
                case Constants.MissionType.Mission1:
                    PlayerPrefs.SetInt(Constants.MISSION1+"-"+serveyId, clearNo);
                    break;
                case Constants.MissionType.Mission2:
                    PlayerPrefs.SetInt(Constants.MISSION2+"-"+serveyId, clearNo);
                    break;
                default:
                    Debug.LogError("�������s���ł�");
                    break;
            }
        }

        /// <summary>
        /// �w��̃~�b�V�����̃N���A�󋵂��擾����
        /// </summary>
        public static int GetMissonFlug(Constants.MissionType missionType,int serveyId)
        {
            int result;
            switch (missionType)
            {
                case Constants.MissionType.Mission1:
                    result = PlayerPrefs.GetInt(Constants.MISSION1 + "-" + serveyId);
                    break;
                case Constants.MissionType.Mission2:
                    result = PlayerPrefs.GetInt(Constants.MISSION2 + "-" + serveyId);
                    break;
                default:
                    result = 0;
                    Debug.LogError("�������s���ł�");
                    break;
            }
            return result;
        }
        #endregion

        #region �Z�[�u
        public static void Save()
        {
            PlayerPrefs.Save();
        }
        #endregion
    }
}