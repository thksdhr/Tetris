using UnityEngine;

namespace Tetris
{
    public class QenerateObject : MonoBehaviour
    {
        public GameObject[] FindObject;//����һ�����Ԥ��������飬�����������
        private void Start()
        {
            andomBuilder();
        }
        public void andomBuilder()//public����������ط�����
        {
            //Instantiate���ɶ��󵽳�����--����(���ɶ�������λ�ã����ɶ������ת�Ƕ�)
            Instantiate(FindObject[Random.Range(0, FindObject.Length)], transform.position, Quaternion.identity);
        }

    }
}