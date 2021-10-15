using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Master
{
    [CreateAssetMenu(menuName ="MyScriptable/Create HackData")]
    public class HackData : ScriptableObject
    {
        [SerializeField]
        private List<Info> _HackList;

        [System.Serializable]
        private class Info
        {
            public int HackId;
            public string IPAdress;
            public string Password;
        }

        /// <summary>
        /// IPアドレスを取得
        /// </summary>
        public string GetIPAdress(int hackId)
        {
            foreach(Info data in _HackList)
            {
                if (data.HackId == hackId)
                {
                    return data.IPAdress;
                }
            }
            return "";
        }

        /// <summary>
        /// パスワードを取得
        /// </summary>
        public string GetPassword(int hackId)
        {
            foreach (Info data in _HackList)
            {
                if (data.HackId == hackId)
                {
                    return data.Password;
                }
            }
            return "";
        }
    }
}