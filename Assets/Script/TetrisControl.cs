using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tetris
{
    public class TetrisControl : MonoBehaviour
    {
        private float IntervalsTime = 0.8f;//间隔时间
        void Start()
        {

        }
        void Update()
        {
            TetrisMove();
        }
        private void TetrisMove()
        {
            //手动控制左右移动
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0);
            }
            //自动向下移动或者手动向下移动
            if (Time.time > IntervalsTime)
            {
                transform.position += new Vector3(0, -1, 0);
            }
        }
    }
}
