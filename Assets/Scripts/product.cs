using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class product : MonoBehaviour
{
    List<Vector3> trackList = new List<Vector3>();  //坐标列表
    float transferSpeed = 3f;   //传送的速度
    float turningSpeed = 0.1f;    //转向速度
    Vector3 transferDirection;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        /*
         * 这是一个测试用例的开始部分
         */
         trackList = new List<Vector3>(new Vector3[] { new Vector3(0, 0, 0), new Vector3(10, 10, 0), new Vector3(10, 40, 60), new Vector3(40, 20, 30) });
        /*
         * 这是一个测试用例的结束部分
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
            //当没在下一个节点的是时候移动
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, transferDirection, transferSpeed * Time.deltaTime);
        }
        else
        {
            //当在下一个节点的时候旋转
            i += 1;
            transferDirection = trackList[i];
            //transform.rotation = Quaternion.LookRotation(transferDirection - transform.position);
            transform.LookAt(transferDirection);
        }
    }
    void MessageOp(List<Vector3> sendList)
    {
        //其他脚本调用本脚本的启动函数
        trackList = sendList;
        //初始化位置列表，并将物件坐标放置在开头
        trackList.Insert(0, this.transform.localPosition);
    }
}
