using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Top
{
    public class TopController : MonoBehaviour
    {
        #region 
        [SerializeField]
        private CommonButtonView _Misson1Button;

        [SerializeField]
        private CommonButtonView _Misson2Button;

        #endregion

        void Start()
        {

        }

        /// <summary>
        /// �{�^���������A�N�V����
        /// </summary>
        public void OnClickMisson1Button(int buttonId)
        {
            // GameManager�ɑI�������{�^��ID��o�^
            GameManager._MissionNumber = buttonId;

            // ����ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_INFO);
        }
    }
}