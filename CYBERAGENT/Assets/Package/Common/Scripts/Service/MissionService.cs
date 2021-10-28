using Common;
using Master;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Master.MissionData;

namespace Master
{
    public class MissionService : MonoBehaviour
    {
        [SerializeField]
        private MissionData _MissionData;

        /// <summary>
        /// ミッションテキストを返す
        /// </summary>
        public Mission GetMission(Constants.MissionType missionType)
        {
            foreach(Mission mission in _MissionData._MissionList)
            {
                if (mission.MissionType == missionType)
                {
                    return mission;
                }
            }
            Debug.LogError("missionがnullです");
            return null;
        }
    }
}