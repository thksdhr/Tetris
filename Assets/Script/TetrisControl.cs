using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tetris
{
    public class TetrisControl : MonoBehaviour
    {
        private float IntervalsTime = 0.8f;//���ʱ��
        private float lastTime;//����˶�ʱ��
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
            if (Time.time - lastTime > (Input.GetKeyDown(KeyCode.Space) ? IntervalsTime / 10 : IntervalsTime))//������¿ո�IntervalsTime/10�����򲻸ı�
            {
                transform.position += new Vector3(0, -1, 0);
                lastTime = Time.time;
            }
        }
        //�Ƿ���Ч�ƶ�
        private bool ValidMove()
        {
            foreach(Transform element in transform)//�������ж����transform������������������С�����transform�����
            {
                //��ȡ��ɫ��ǰ��ȡ��XYֵ
                int nowX = Mathf.RoundToInt(element.transform.position.x);
                int nowY = Mathf.RoundToInt(element.transform.position.y);
            }
            return(false);
        }
    }
}
