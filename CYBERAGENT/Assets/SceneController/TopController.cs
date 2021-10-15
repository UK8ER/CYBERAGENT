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
        private CommonButtonView _InfoButton;

        [SerializeField]
        private CommonButtonView _HackButton;

        #endregion

        void Start()
        {

        }

        /// <summary>
        /// �u���v�{�^���������A�N�V����
        /// </summary>
        public void OnClickInfoButton()
        {
            // ����ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_INFO);
        }

        /// <summary>
        /// �u�n�b�L���O�v�{�^���������A�N�V����
        /// </summary>
        public void OnClickHackButton()
        {
            // �n�b�L���O��ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_HACK);
        }
    }
}