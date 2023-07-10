using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class product : MonoBehaviour
{
    List<Vector3> trackList = new List<Vector3>();  //�����б�
    float transferSpeed = 3f;   //���͵��ٶ�
    float turningSpeed = 0.1f;    //ת���ٶ�
    Vector3 transferDirection;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        /*
         * ����һ�����������Ŀ�ʼ����
         */
         trackList = new List<Vector3>(new Vector3[] { new Vector3(0, 0, 0), new Vector3(10, 10, 0), new Vector3(10, 40, 60), new Vector3(40, 20, 30) });
        /*
         * ����һ�����������Ľ�������
         */
        MessageOp(trackList);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        transferDirection = trackList[i];
        if(this.transform.localPosition != transferDirection && i< trackList.Count) {
            //��û����һ���ڵ����ʱ���ƶ�
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, transferDirection, transferSpeed * Time.deltaTime);
        }
        else
        {
            //������һ���ڵ��ʱ����ת
            i += 1;
            transferDirection = trackList[i];
            //transform.rotation = Quaternion.LookRotation(transferDirection - transform.position);
            transform.LookAt(transferDirection);
        }
    }
    void MessageOp(List<Vector3> sendList)
    {
        //�����ű����ñ��ű�����������
        trackList = sendList;
        //��ʼ��λ���б����������������ڿ�ͷ
        trackList.Insert(0, this.transform.localPosition);
    }
}
