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
        /// 「もどる」ボタン押下時アクション
        /// </summary>
        public void OnClickBackButton()
        {
            // 情報画面に遷移
            SceneManager.LoadScene(Constants.SCENE_TOP);
        }

        /// <summary>
        /// 「Enter」ボタン押下時アクション
        /// </summary>
        public void OnClickEnterButton()
        {
            // ハッキング画面に遷移
            SceneManager.LoadScene(Constants.SCENE_HACK);
        }
    }
}