using UnityEngine;


namespace Tetris
{
    public class TetrisControl : MonoBehaviour
    {
        public Vector3 mCoordinate;//旋转中心
        private float IntervalsTime = 0.8f;//间隔时间
        private float lastTime;//最后运动时间
        private static int Width = 9, Height = 16;
        private static Transform[,] Grid = new Transform[Width, Height];
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
                    AddToGrid();//添加块坐标到二位数组
                    this.enabled = false;//停用这个块
                    GameObject.Find("Builder").GetComponent<QenerateObject>().andomBuilder();
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
                if (nowX >= Width || nowX < 0 || nowY < 0)
                {
                    return false;
                }
                if (nowX < Width && nowY < Height)
                {
                    if (Grid[nowX, nowY] != null)
                    {
                        return false;
                    }

                }
            }
            return (true);
        }
        private void Rotate()//旋转方块
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //transform.RotateAround改变位置和旋转--传入参数（旋转的坐标"必须是世界坐标"，按照那个轴旋转，旋转角度）
                //Transform.TransformPoint将'传入'的本地[相对]坐标变换为'世界'[绝对]坐标
                transform.RotateAround(transform.TransformPoint(mCoordinate), new Vector3(0, 0, 1), 90);
                if (!ValidMove())//如果超出边界，就朝相反方向移动来抵消
                {
                    transform.RotateAround(transform.TransformPoint(mCoordinate), new Vector3(0, 0, 1), -90);
                }
            }
        }
        private void AddToGrid()//添加块到网格
        {
            foreach (Transform element in transform)
            {
                int nowX = Mathf.RoundToInt(element.transform.position.x);
                int nowY = Mathf.RoundToInt(element.transform.position.y);
                Grid[nowX, nowY] = element;//将每个小格子的坐标添加到二位数组
            }
        }
    }
}
