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
            public List<Servey> ServeyList;
        }

        [System.Serializable]
        public class Servey
        {
            public int ServeyId;
            public string ServeyTitle;
            public string ServeyContents;
            public string AnswerText;
        }
    }
}