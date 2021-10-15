using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    [CreateAssetMenu(menuName ="MyScriptable/Create InfomationData")]
    public class InfomationData : ScriptableObject
    {
        [SerializeField]
        private List<Info> _InfoList;

        [System.Serializable]
        private class Info
        {
            public int InfoId;
            public string InfoTitle;
            public string InfoContents;
            public bool DefaultOpenFlug;
        }

        /// <summary>
        /// ���̃^�C�g�����擾
        /// </summary>
        public string GetInfoTitle(int infoId)
        {
            foreach(Info data in _InfoList)
            {
                if (data.InfoId == infoId)
                {
                    return data.InfoTitle;
                }
            }
            return "";
        }

        /// <summary>
        /// ���̓��e���擾
        /// </summary>
        public string GetInfoContents(int infoId)
        {
            foreach (Info data in _InfoList)
            {
                if (data.InfoId == infoId)
                {
                    return data.InfoContents;
                }
            }
            return "";
        }

        /// <summary>
        /// ���̊J���t���O���擾
        /// </summary>
        public bool GetDefaultOpenFlug(int infoId)
        {
            foreach (Info data in _InfoList)
            {
                if (data.InfoId == infoId)
                {
                    return data.DefaultOpenFlug;
                }
            }
            return false;
        }
    }
}