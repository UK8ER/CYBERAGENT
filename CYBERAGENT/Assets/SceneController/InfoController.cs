using Common;
using Master;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Info
{
    public class InfoController : MonoBehaviour
    {
        #region 
        [Header("Data")]
        [SerializeField]
        private InfomationData _InfoData;

        [Header("UI")]
        [SerializeField]
        private CommonButtonView _BackButton;

        [SerializeField]
        private GameObject _InfoButton;

        #endregion

        void Start()
        {
            // �}�X�^�f�[�^���擾
            
        }

        /// <summary>
        /// �u���ǂ�v�{�^���������A�N�V����
        /// </summary>
        public void OnClickBackButton()
        {
            // ����ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_TOP);
        }

        /// <summary>
        /// �u���v�{�^���������A�N�V����
        /// </summary>
        public void OnClickInfoButton(int id)
        {
            //// ����ʂɑJ��
            //SceneManager.LoadScene(Constants.SCENE_INFO);
        }

        /// <summary>
        /// �u���v�{�^���C���X�^���X���쐬
        /// </summary>
        private void CreateInfoButtons()
        {
            int num = 10;
        }
    }
}