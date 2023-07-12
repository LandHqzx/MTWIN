using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class product : MonoBehaviour
{
    List<Vector3> trackList = new List<Vector3>();  //坐标列表
    float transferSpeed = 3f;   //传送的速度
    Vector3 transferDirection;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        /*
         * 这是一个测试用例的开始部分
         */
        if (gameObject.tag == "Plastic rings")
        {
            if (transform.position == new Vector3((float)83.4800034, (float)2.1730001, (float)16.0400009))
            {
                trackList = new List<Vector3>(new Vector3[] { new Vector3((float)83.4800034, (float)2.1730001, (float)12.3800001), new Vector3((float)101.610001, (float)2.1730001, (float)12.3800001), new Vector3((float)101.610001, (float)2.1730001, (float)53.62) , new Vector3((float)95.5100021, (float)2.1730001, (float)53.6199989), new Vector3((float)95.5100021, (float)2.1730001, (float)68.7300034) });
            }

            else if (transform.position == new Vector3((float)76.7089996, (float)2.1730001, (float)16.0400009))
            {
                trackList = new List<Vector3>(new Vector3[] { new Vector3((float)76.709, (float)2.1730001, (float)12.3800001), new Vector3((float)101.610001, (float)2.1730001, (float)12.3800001), new Vector3((float)101.610001, (float)2.1730001, (float)53.62), new Vector3((float)95.5100021, (float)2.1730001, (float)53.6199989), new Vector3((float)95.5100021, (float)2.1730001, (float)68.7300034) });
            }

            else if (transform.position == new Vector3((float)90.1200027, (float)2.1730001, (float)16.0400009))
            {
                trackList = new List<Vector3>(new Vector3[] { new Vector3((float)90.12, (float)2.1730001, (float)12.3800001), new Vector3((float)101.610001, (float)2.1730001, (float)12.3800001), new Vector3((float)101.610001, (float)2.1730001, (float)53.62), new Vector3((float)95.5100021, (float)2.1730001, (float)53.6199989),new Vector3((float)95.5100021, (float)2.1730001, (float)68.7300034) });
            }
        }
        else if (gameObject.tag == "fan")
        {
            trackList = new List<Vector3>(new Vector3[] { new Vector3((float)29.0419998, (float)1.54700005, (float)43.2700005), new Vector3((float)46.3440018, (float)1.54700005, (float)44.2700005), new Vector3((float)46.3440018, (float)1.54700005, (float)52.4399986), new Vector3((float)96.4599991, (float)1.54700005, (float)53.4399986), new Vector3((float)96.4599991, (float)1.54700005, (float)67.9800034) });
        }

        else if (gameObject.tag == "Carbon fiber")
        {
            trackList = new List<Vector3>(new Vector3[] { new Vector3((float)44.7, (float)2.94000006, (float)19.12), new Vector3((float)44.7, (float)2.94000006, (float)54.1100006), new Vector3((float)95.3399963, (float)2.94000006, (float)54.1100006), new Vector3((float)95.3399963, (float)2.94000006, (float)69.6200027) });
        }

        else if (gameObject.tag == "Lens mount")
        {
            trackList = new List<Vector3>(new Vector3[] { new Vector3((float)152.113007, (float)2.61500001, (float)12.7229996), new Vector3((float)163.350006, (float)2.61500001, (float)12.7200003), new Vector3((float)163.350006, (float)2.61500001, (float)53.5900017),new Vector3((float)95.4800034, (float)2.61500001, (float)53.5900017),new Vector3((float)95.4800034, (float)2.61500001, (float)69.5) });
        }

        else if (gameObject.tag == "Antenna holder")
        {
            trackList = new List<Vector3>(new Vector3[] { new Vector3((float)145.554, (float)1.4, (float)12.7229996), new Vector3((float)163.350006, (float)1.4, (float)12.7200003), new Vector3((float)163.350006, (float)1.4, (float)53.5900017), new Vector3((float)95.4800034, (float)1.4, (float)53.5900017), new Vector3((float)95.4800034, (float)1.4, (float)69.5) });
        }

        else if (gameObject.tag == "Camera mount")
        {
            trackList = new List<Vector3>(new Vector3[] { new Vector3((float)138.557, (float)1.34, (float)12.7229996), new Vector3((float)163.350006, (float)1.34, (float)12.7200003), new Vector3((float)163.350006, (float)1.34, (float)53.5900017), new Vector3((float)95.4800034, (float)1.34, (float)53.5900017), new Vector3((float)95.4800034, (float)1.34, (float)69.5) });
        }
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
        if (i >= trackList.Count)
        {
            // 已经遍历完trackList，停止执行FixedUpdate
            // 在到达最后一个点后销毁物品
            //if (gameObject != null)
            //{
            //  Destroy(gameObject);
            //}
            return;
        }
        transferDirection = trackList[i];
        if(this.transform.localPosition != transferDirection ) {
            //当没在下一个节点的是时候移动
            gameObject.transform.localPosition = Vector3.MoveTowards(gameObject.transform.localPosition, transferDirection, transferSpeed * Time.deltaTime);
        }
        else
        {
            //当在下一个节点的时候旋转
            i += 1;
            if (i < trackList.Count)
            {
                transferDirection = trackList[i];
                transform.LookAt(transferDirection);
            }
        }
    }
    void MessageOp(List<Vector3> sendList)
    {
        //其他脚本调用本脚本的启动函数
        trackList = sendList;
        //初始化位置列表，并将物件坐标放置在开头
        trackList.Insert(0, this.transform.localPosition);
    }
    private bool IsReferenced(GameObject obj)
    {
        var referencedObjects = GameObject.FindObjectsOfType<Component>();
        foreach (var referencedObject in referencedObjects)
        {
            if (referencedObject != null && referencedObject.gameObject == obj)
            {
                return true;
            }
        }
        return false;
    }
}
