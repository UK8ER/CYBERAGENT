using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MissionPackage
{
    public class ModalView : MonoBehaviour
    {
        [Header("ModalCanvas")]
        [SerializeField]
        private Canvas _ModalCanvas;

        [SerializeField]
        private Text _AnswerWord;


        /// <summary>
        /// モーダルテキストをセットする
        /// </summary>
        public void SetAnswerWord(string text)
        {
            _AnswerWord.text = text.Replace("/", "\n");
        }

        /// <summary>
        /// モーダルを表示する
        /// </summary>
        public void OpenModal()
        {
            _ModalCanvas.enabled = true;
        }

        /// <summary>
        /// モーダルを閉じる
        /// </summary>
        public void CloseModal()
        {
            _ModalCanvas.enabled = false;
        }
    }
}