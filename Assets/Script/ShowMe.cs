using UnityEngine;
using TMPro;

namespace Tetris
{
    public class ShowMe : MonoBehaviour
    {
        private TMP_Text ScoreText;
        private TMP_Text TimeCost;
        public bool Timer = true;
        public float NowTime;
        public int ScoreNumber = 0;
        private void Start()
        {
            ScoreText = transform.Find("Info/Score").GetComponent<TMP_Text>();
            TimeCost = transform.Find("Info/TimeC").GetComponent<TMP_Text>();
        }
        private void Update()
        {
            if (Timer)
            {
                NowTime = Time.timeSinceLevelLoad;//�ӳ������ؾͿ�ʼ��ʱ
                TimeCost.text = NowTime.ToString("0.00");
            }
        }
        public void AddAndShowScore()
        {
            ScoreNumber += 1;
            ScoreText.text = "Score:" + ScoreNumber.ToString();
        }

    }

}