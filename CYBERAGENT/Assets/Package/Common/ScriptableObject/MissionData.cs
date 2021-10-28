using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    [CreateAssetMenu(menuName ="MyScriptable/Create MissionData")]
    public class MissionData : ScriptableObject
    {
        public List<Mission> _MissionList;

        [System.Serializable]
        public class Mission
        {
            public Constants.MissionType MissionType;
            public string TitleText;
            public string MissionText;
            public List<MissionDetail> MissionDetailList;
        }

        [System.Serializable]
        public class MissionDetail
        {
            public int MissionId;
            public string ServeyTitle;
            public string ServeyContents;
            public string AnswerText;
        }
    }
}