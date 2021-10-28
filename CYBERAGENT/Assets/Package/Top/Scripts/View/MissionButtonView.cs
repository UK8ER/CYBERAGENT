using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopPackage
{
    public class MissionButtonView : MonoBehaviour
    {
        #region 
        [SerializeField]
        private CommonButtonView _Misson1Button;

        [SerializeField]
        private CommonButtonView _Misson2Button;

        #endregion

        /// <summary>
        /// ミッション１ボタンの表示制御 
        /// </summary>
        public void MissionButton1Active(bool flug)
        {
            if (flug)
            {
                // ボタン表示
                _Misson1Button.UnlockButton();
            }
            else
            {
                // ボタン非活性表示
                _Misson1Button.LockButton();
            }
        }

        /// <summary>
        /// ミッション２ボタンの表示制御 
        /// </summary>
        public void MissionButton2Active(bool flug)
        {
            if (flug)
            {
                // ボタン表示
                _Misson2Button.UnlockButton();
            }
            else
            {
                // ボタン非活性表示
                _Misson2Button.LockButton();
            }
        }
    }
}