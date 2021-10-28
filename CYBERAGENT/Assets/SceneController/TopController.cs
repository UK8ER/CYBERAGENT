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
        /// ボタン押下時アクション
        /// </summary>
        public void OnClickMisson1Button(int buttonId)
        {
            // GameManagerに選択したボタンIDを登録
            GameManager._MissionNumber = buttonId;

            // 情報画面に遷移
            SceneManager.LoadScene(Constants.SCENE_INFO);
        }
    }
}