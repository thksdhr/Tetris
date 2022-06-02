using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tetris
{
    public class TetrisControl : MonoBehaviour
    {
        private Vector3 nowCoordinate;//���ת��������
        private float IntervalsTime = 0.8f;//���ʱ��
        private float lastTime;//����˶�ʱ��
        private static int Width = 9, Height = 16;
        void Start()
        {

        }
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
                //transform.RotateAround�ı�λ�ú���ת--����������任������"��������������"�������Ǹ�����ת����ת�Ƕȣ�
                //Transform.TransformPoint��'����'�ı�������任Ϊ'����'����
                transform.RotateAround(transform.TransformPoint(nowCoordinate), new Vector3(1, 0, 0), 90);
                if (!ValidMove())//��������߽磬�ͳ��෴�����ƶ�������
                {
                    transform.RotateAround(transform.TransformPoint(nowCoordinate), new Vector3(0, 0, 1), -90);
                }
            }
        }
    }
}
