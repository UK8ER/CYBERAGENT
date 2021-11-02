using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MissionPackage
{
    public class MissionAnswerView : MonoBehaviour
    {
        [SerializeField]
        private GameObject _AnswerText;

        public void ActiveAnswerText()
        {
            _AnswerText.SetActive(true);
        }

        public void InactiveAnswerText()
        {
            _AnswerText.SetActive(false);
        }
    }
}