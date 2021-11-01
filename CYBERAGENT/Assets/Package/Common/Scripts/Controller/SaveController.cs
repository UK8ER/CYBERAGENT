using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public static class SaveController
    {
        #region 初回フラグ
        /// <summary>
        /// 初回フラグを解除する
        /// </summary>
        public static void SetFirstFlug()
        {
            PlayerPrefs.SetInt(Constants.FIRST_FLUG, 0);
            Save();
        }

        /// <summary>
        /// 初回フラグを取得する{0:初回ではない}{1:初回}
        /// </summary>
        public static bool GetFirstFlug()
        {
            if (PlayerPrefs.GetInt(Constants.FIRST_FLUG) == 1 || !PlayerPrefs.HasKey(Constants.FIRST_FLUG))
            {
                Debug.Log("初回");
                return true;
            }
            else
            {
                Debug.Log("初回ではない");
                return false;
            }
        }
        #endregion

        #region ミッションフラグ
        /// <summary>
        /// ミッションフラグを初期化する
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
        /// 指定のミッションのクリア状況をセーブする
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
                    Debug.LogError("引数が不正です");
                    break;
            }
        }

        /// <summary>
        /// 指定のミッションのクリア状況を取得する
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
                    Debug.LogError("引数が不正です");
                    break;
            }
            return result;
        }
        #endregion

        #region セーブ
        public static void Save()
        {
            PlayerPrefs.Save();
        }
        #endregion
    }
}