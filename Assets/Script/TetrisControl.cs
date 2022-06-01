using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tetris
{
    public class TetrisControl : MonoBehaviour
    {
        private float IntervalsTime = 0.8f;//间隔时间
        private float lastTime;//最后运动时间
        private static int Width=9, Height=16;
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
            if (Time.time - lastTime > (Input.GetKeyDown(KeyCode.Space) ? IntervalsTime / 10 : IntervalsTime))//如果按下空格IntervalsTime/10，否则不改变
            {
                transform.position += new Vector3(0, -1, 0);
                lastTime = Time.time;
            }
        }
        //是否有效移动
        private bool ValidMove()
        {
            foreach(Transform element in transform)//迭代所有对象的transform组件（组成这个块的所有小方块的transform组件）
            {
                //获取角色当前的取整XY值
                int nowX = Mathf.RoundToInt(element.transform.position.x);
                int nowY = Mathf.RoundToInt(element.transform.position.y);
            }
            return(false);
        }
    }
}
