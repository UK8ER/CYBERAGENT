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
        /// <summary>����t���O</summary>
        public const string FIRST_FLUG = "First_Flug";
        /// <summary>�~�b�V�����P�����t���O</summary>
        public const string MISSION1 = "Mission1";
        /// <summary>�~�b�V�����Q�����t���O</summary>
        public const string MISSION2 = "Mission2";
        #endregion

        public enum MissionType
        {
            Mission1,
            Mission2,
        }
    }
}