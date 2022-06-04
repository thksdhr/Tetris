using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Tetris
{
    public class StratGame : MonoBehaviour
    {
        private GameObject GameStart;
        void Start()
        {
            GameStart = transform.Find("GameStart").gameObject;
            GameStart.transform.Find("PlayGame").GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Tetris");
            });
        }
    }
}