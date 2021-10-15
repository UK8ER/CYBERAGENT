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
            // マスタデータを取得
            
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
        /// 「情報」ボタン押下時アクション
        /// </summary>
        public void OnClickInfoButton(int id)
        {
            //// 情報画面に遷移
            //SceneManager.LoadScene(Constants.SCENE_INFO);
        }

        /// <summary>
        /// 「情報」ボタンインスタンスを作成
        /// </summary>
        private void CreateInfoButtons()
        {
            int num = 10;
        }
    }
}