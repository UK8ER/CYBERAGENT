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
        /// �~�b�V�����P�{�^���̕\������ 
        /// </summary>
        public void MissionButton1Active(bool flug)
        {
            if (flug)
            {
                // �{�^���\��
                _Misson1Button.UnlockButton();
            }
            else
            {
                // �{�^���񊈐��\��
                _Misson1Button.LockButton();
            }
        }

        /// <summary>
        /// �~�b�V�����Q�{�^���̕\������ 
        /// </summary>
        public void MissionButton2Active(bool flug)
        {
            if (flug)
            {
                // �{�^���\��
                _Misson2Button.UnlockButton();
            }
            else
            {
                // �{�^���񊈐��\��
                _Misson2Button.LockButton();
            }
        }
    }
}