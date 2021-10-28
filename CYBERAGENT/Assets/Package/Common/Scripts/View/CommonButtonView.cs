using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class CommonButtonView : MonoBehaviour
    {
        [SerializeField]
        private Button _Button;


        public void Initialized()
        {
            
        }

        public void LockButton()
        {
            _Button.interactable = false;
        }

        public void UnlockButton()
        {
            _Button.interactable = true;
        }
    }
}