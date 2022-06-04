using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Tetris
{
    public class ShowMe : MonoBehaviour
    {
        private int ScoreNumber = 0;
        private TMP_Text ScoreText;
        private TMP_Text TimeCost;
        private void Start()
        {
            ScoreText = transform.Find("Info/Score").GetComponent<TMP_Text>();
            TimeCost = transform.Find("Info/TimeC").GetComponent<TMP_Text>();
        }
        private void Update()
        {
            float NowTime = Time.realtimeSinceStartup;
            TimeCost.text = NowTime.ToString("0.00");
        }
        public void AddAndShowScore()
        {
            ScoreNumber += 1;
            ScoreText.text = "Score:" + ScoreNumber.ToString();
        }

    }

}