using UnityEngine;


namespace Tetris
{
    public class TetrisControl : MonoBehaviour
    {
        public Vector3 mCoordinate;//�����ת����
        private float IntervalsTime = 0.8f;//���ʱ��
        private float lastTime;//����˶�ʱ��
        private static int Width = 9, Height = 16;
        private static Transform[,] Grid = new Transform[Width, Height];
        void Update()
        {
            TetrisMove();
            Rotate();//��ת��
        }
        private void TetrisMove()
        {
            //�ֶ����������ƶ�

            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position += new Vector3(-1, 0, 0);
            }

            if (!ValidMove())//��������߽磬�ͳ��෴�����ƶ�������
            {
                transform.position += new Vector3(1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0);
            }

            if (!ValidMove())//��������߽磬�ͳ��෴�����ƶ�������
            {
                transform.position += new Vector3(-1, 0, 0);
            }

            //�Զ������ƶ������ֶ������ƶ�
            if (Time.time - lastTime > (Input.GetKeyDown(KeyCode.S) ? IntervalsTime / 10 : IntervalsTime))//������¿ո�IntervalsTime/10�����򲻸ı�
            {
                transform.position += new Vector3(0, -1, 0);
                lastTime = Time.time;
                if (!ValidMove())//��������߽磬�ͳ��෴�����ƶ�������
                {
                    transform.position += new Vector3(0, 1, 0);
                    AddToGrid();//��ӿ����굽��λ����
                    this.enabled = false;//ͣ�������
                    GameObject.Find("Builder").GetComponent<QenerateObject>().andomBuilder();
                    aClearLine();
                }
            }
        }
        private bool ValidMove()//�Ƿ���Ч�ƶ�
        {
            foreach (Transform element in transform)//�������ж����transform������������������С�����transform�����
            {
                //��ȡ��ɫ��ǰ��ȡ��XYֵ
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
        private void Rotate()//��ת����
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //transform.RotateAround�ı�λ�ú���ת--���ò����ֱ�Ϊ����תĿ������ꡢ��ת��������ת���ٶȡ�
                //Transform.TransformPoint��'����'�ı���[���]����任Ϊ'����'[����]����
                transform.RotateAround(transform.TransformPoint(mCoordinate), new Vector3(0, 0, 1), 90);
                if (!ValidMove())//��������߽磬�ͳ��෴�����ƶ�������
                {
                    transform.RotateAround(transform.TransformPoint(mCoordinate), new Vector3(0, 0, 1), -90);
                }
            }
        }
        private void AddToGrid()//��ӿ鵽����
        {
            foreach (Transform element in transform)
            {
                int nowX = Mathf.RoundToInt(element.transform.position.x);
                int nowY = Mathf.RoundToInt(element.transform.position.y);
                Grid[nowX, nowY] = element;//��ÿ��С���ӵ�������ӵ���λ����
            }
        }
        private void aClearLine()
        {
            //�������¼��ÿһ��
            for (int i = Height - 1; i >= 0; i--)
            {
                if (CheckLine(i))
                {
                    //ɾ������
                    ClearLine(i);
                    //�������������
                    MoveDownForLine(i);
                }
            }
        }
        private bool CheckLine(int i)//������Ƿ�����
        {
            //������е�ÿһ�����Ӷ���Ϊ�գ�����true
            for (int j = 0; j < Width; j++)
            {
                if (Grid[j, i] == false)
                {
                    return false;
                }
            }
            return true;
        }
        private void ClearLine(int i)//�����ǰһ�еĿ飬���뵱ǰ������
        {
            for (int j = 0; j < Width; j++)
            {
                Destroy(Grid[j, i].gameObject);
                Grid[j, i] = null;
            }
            GameObject.Find("Canvas").GetComponent<ShowMe>().AddAndShowScore();
        }
        private void MoveDownForLine(int i)//�����Ϸ��ķ���
        {
            for (int f = i; f < Height; f++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (Grid[j, f] != null)
                    {
                        Grid[j, f - 1] = Grid[j, f];
                        Grid[j, f] = null;
                        Grid[j, f - 1].transform.position -= new Vector3(0, 1, 0);
                    }
                }
            }
        }
    }
}
