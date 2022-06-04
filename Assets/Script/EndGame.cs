using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tetris
{
    public class EndGame : MonoBehaviour
    {
        private GameObject GameOver;
        void Start()
        {
            GameOver = transform.Find("GameOver").gameObject;
            GameOver.transform.Find("EndGame").GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene("GamePlay");//���س���
            });
            GameOver.SetActive(false);
        }
        public void GameOverUI()
        {
            GameOver.SetActive(true);//������Ϸ��������
        }
    }
}
