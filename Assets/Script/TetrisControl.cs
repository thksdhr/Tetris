using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tetris
{
    public class TetrisControl : MonoBehaviour
    {
        private float IntervalsTime = 0.8f;//���ʱ��
        void Start()
        {

        }
        void Update()
        {
            TetrisMove();
        }
        private void TetrisMove()
        {
            //�ֶ����������ƶ�
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0);
            }
            //�Զ������ƶ������ֶ������ƶ�
            if (Time.time > IntervalsTime)
            {
                transform.position += new Vector3(0, -1, 0);
            }
        }
    }
}
