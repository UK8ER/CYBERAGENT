using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ContentsPackage
{
    public class AnswerAreaView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _AnswerArea;

        [SerializeField]
        private Text _AnswerText;


        public void SetAnswerText(string text)
        {
            _AnswerText.text = text;
        }

        public void InactiveAnswerArea()
        {
            _AnswerArea.SetActive(false);
        }

        public void ActiveAnswerArea()
        {
            _AnswerArea.SetActive(true);
        }
    }
}