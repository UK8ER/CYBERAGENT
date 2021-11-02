using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TopPackage
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField]
        private Text _Score;

        private int _BaseScore;

        private void Start()
        {
            UpdateScore();
        }

        public void UpdateScore()
        {
            _BaseScore = 0;

            for (int i = 0; i < 4; i++)
            {
                _BaseScore += SaveController.GetMissonFlug(Constants.MissionType.Mission1, i)
                    + SaveController.GetMissonFlug(Constants.MissionType.Mission2, i);
            }

            _Score.text = (10000 * _BaseScore).ToString();
        }
    }
}