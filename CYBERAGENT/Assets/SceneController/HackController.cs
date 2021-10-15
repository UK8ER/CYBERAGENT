using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Hack
{
    public class HackController : MonoBehaviour
    {
        #region 
        [SerializeField]
        private CommonButtonView _BackButton;

        [SerializeField]
        private InputField _InputFieldIP;

        [SerializeField]
        private InputField _InputFieldPW;

        [SerializeField]
        private CommonButtonView _EnterButton;

        #endregion



        void Start()
        {

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
        /// �uEnter�v�{�^���������A�N�V����
        /// </summary>
        public void OnClickEnterButton()
        {
            // �n�b�L���O��ʂɑJ��
            SceneManager.LoadScene(Constants.SCENE_HACK);
        }
    }
}