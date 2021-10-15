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
        /// 「情報」ボタン押下時アクション
        /// </summary>
        public void OnClickInfoButton()
        {
            // 情報画面に遷移
            SceneManager.LoadScene(Constants.SCENE_INFO);
        }

        /// <summary>
        /// 「ハッキング」ボタン押下時アクション
        /// </summary>
        public void OnClickHackButton()
        {
            // ハッキング画面に遷移
            SceneManager.LoadScene(Constants.SCENE_HACK);
        }
    }
}