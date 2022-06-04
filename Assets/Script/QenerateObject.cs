using UnityEngine;

namespace Tetris
{
    public class QenerateObject : MonoBehaviour
    {
        public GameObject[] FindObject;//定义一个存放预制体的数组，用于随机生成
        private void Start()
        {
            andomBuilder();
        }
        public void andomBuilder()//public方便从其他地方调用
        {
            //Instantiate生成对象到场景中--传参(生成对象，生成位置，生成对象的旋转角度)
            Instantiate(FindObject[Random.Range(0, FindObject.Length)], transform.position, Quaternion.identity);
        }

    }
}