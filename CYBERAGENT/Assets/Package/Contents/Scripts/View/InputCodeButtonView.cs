using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ContentsPackage
{
    public class InputCodeButtonView : MonoBehaviour
    {
        [SerializeField]
        private Button _InputCodeButton;

        public void InactiveButton()
        {
            _InputCodeButton.gameObject.SetActive(false);
        }

        public void ActiveButton()
        {
            _InputCodeButton.gameObject.SetActive(true);
        }
    }
}