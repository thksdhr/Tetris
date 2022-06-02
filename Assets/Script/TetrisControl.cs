using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tetris
{
    public class TetrisControl : MonoBehaviour
    {
        private Vector3 nowCoordinate;//存放转换的坐标
        private float IntervalsTime = 0.8f;//间隔时间
        private float lastTime;//最后运动时间
        private static int Width = 9, Height = 16;
        void Start()
        {

        }
        void Update()
        {
            TetrisMove();
            Rotate();//旋转块
        }
        private void TetrisMove()
        {
            //手动控制左右移动

            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position += new Vector3(-1, 0, 0);
            }

            if (!ValidMove())//如果超出边界，就朝相反方向移动来抵消
            {
                transform.position += new Vector3(1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0);
            }

            if (!ValidMove())//如果超出边界，就朝相反方向移动来抵消
            {
                transform.position += new Vector3(-1, 0, 0);
            }

            //自动向下移动或者手动向下移动
            if (Time.time - lastTime > (Input.GetKeyDown(KeyCode.S) ? IntervalsTime / 10 : IntervalsTime))//如果按下空格IntervalsTime/10，否则不改变
            {
                transform.position += new Vector3(0, -1, 0);
                lastTime = Time.time;
                if (!ValidMove())//如果超出边界，就朝相反方向移动来抵消
                {
                    transform.position += new Vector3(0, 1, 0);
                }
            }
        }
        private bool ValidMove()//是否有效移动
        {
            foreach (Transform element in transform)//迭代所有对象的transform组件（组成这个块的所有小方块的transform组件）
            {
                //获取角色当前的取整XY值
                int nowX = Mathf.RoundToInt(element.transform.position.x);
                int nowY = Mathf.RoundToInt(element.transform.position.y);
                if (nowX >= Width || nowY >= Height || nowX < 0 || nowY < 0)
                {
                    return false;
                }
            }
            return (true);
        }
        private void Rotate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //transform.RotateAround改变位置和旋转--传入参数（变换的坐标"必须是世界坐标"，按照那个轴旋转，旋转角度）
                //Transform.TransformPoint将'传入'的本地坐标变换为'世界'坐标
                transform.RotateAround(transform.TransformPoint(nowCoordinate), new Vector3(1, 0, 0), 90);
                if (!ValidMove())//如果超出边界，就朝相反方向移动来抵消
                {
                    transform.RotateAround(transform.TransformPoint(nowCoordinate), new Vector3(0, 0, 1), -90);
                }
            }
        }
    }
}
