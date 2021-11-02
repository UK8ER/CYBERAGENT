using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class Constants
    {
        #region Scene
        public const string SCENE_TOP = "Top";
        public const string SCENE_MISSION = "Mission";
        public const string SCENE_CONTENTS = "Contents";

        #endregion

        #region PlayerPref
        /// <summary>初回フラグ</summary>
        public const string FIRST_FLUG = "First_Flug";
        /// <summary>ミッション１完了フラグ</summary>
        public const string MISSION1 = "Mission1";
        /// <summary>ミッション２完了フラグ</summary>
        public const string MISSION2 = "Mission2";
        /// <summary>間違えた数カウント</summar>
        public const string MISSCOUNT = "MissCount";
        #endregion

        public enum MissionType
        {
            Mission1,
            Mission2,
        }
    }
}