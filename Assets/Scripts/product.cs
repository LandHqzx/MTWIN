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
                trackList = new List<Vector3>(new Vector3[] { new Vector3((float)83.4800034, (float)2.1730001, (float)12.07), new Vector3((float)101.610001, (float)2.1730001, (float)12.07), new Vector3((float)101.610001, (float)2.1730001, (float)53.62) , new Vector3((float)95.5100021, (float)2.1730001, (float)53.6199989), new Vector3((float)95.5100021, (float)2.1730001, (float)68.7300034) });
            }

            else if (transform.position == new Vector3((float)76.7089996, (float)2.1730001, (float)16.0400009))
            {
                trackList = new List<Vector3>(new Vector3[] { new Vector3((float)76.709, (float)2.1730001, (float)12.07), new Vector3((float)101.610001, (float)2.1730001, (float)12.07), new Vector3((float)101.610001, (float)2.1730001, (float)53.62), new Vector3((float)95.5100021, (float)2.1730001, (float)53.6199989), new Vector3((float)95.5100021, (float)2.1730001, (float)68.7300034) });
            }

            else if (transform.position == new Vector3((float)90.1200333, (float)2.17300034, (float)16.039999))
            {
                trackList = new List<Vector3>(new Vector3[] { new Vector3((float)90.12, (float)2.1730001, (float)12.07), new Vector3((float)101.610001, (float)2.1730001, (float)12.07), new Vector3((float)101.610001, (float)2.1730001, (float)53.62), new Vector3((float)95.5100021, (float)2.1730001, (float)53.6199989),new Vector3((float)95.5100021, (float)2.1730001, (float)68.7300034) });
            }
        }
        else if (gameObject.tag == "fan")
        {
            trackList = new List<Vector3>(new Vector3[] { new Vector3((float)29.008, (float)1.209, (float)43.378), new Vector3((float)46.214, (float)1.209, (float)43.378), new Vector3((float)46.2900009, (float)1.209, (float)52.735), new Vector3((float)96.5599976, (float)1.209, (float)52.735), new Vector3((float)96.5599976, (float)1.209, (float)69.2200012) });
        }

        else if (gameObject.tag == "Carbon fiber")
        {
            trackList = new List<Vector3>(new Vector3[] { new Vector3((float)44.92, (float)1.145, (float)19.12), new Vector3((float)44.92, (float)1.145, (float)54.1100006), new Vector3((float)95.3399963, (float)1.145, (float)54.1100006), new Vector3((float)95.3399963, (float)1.145,(float)69.6200027) });
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

        else if (gameObject.tag == "drone")
        {
            if (transform.position == new Vector3((float)117.449997, (float)1.90699995, (float)129.606003))
            {
                trackList = new List<Vector3>(new Vector3[] { new Vector3((float)124.309998, (float)1.90699995, (float)129.606003), new Vector3((float)124.309998, (float)1.90999997, (float)110.730003), new Vector3((float)112.316002, (float)1.90999997, (float)110.730003), new Vector3((float)112.316002, (float)1.90999997, (float)101.440002) });
            }
            else if(transform.position == new Vector3((float)117.449997, (float)1.90699995, (float)142.979996))
            {
                trackList = new List<Vector3>(new Vector3[] { new Vector3((float)124.309998, (float)1.90699995, (float)142.979996), new Vector3((float)124.309998, (float)1.90999997, (float)110.730003), new Vector3((float)112.316002, (float)1.90999997, (float)110.730003), new Vector3((float)112.316002, (float)1.90999997, (float)101.440002) });
            }
            else if (transform.position == new Vector3((float)117.449997, (float)1.90699995, (float)155.410004))
            {
                trackList = new List<Vector3>(new Vector3[] { new Vector3((float)124.309998, (float)1.907, (float)155.410004), new Vector3((float)124.309998, (float)1.90999997, (float)110.730003), new Vector3((float)112.316002, (float)1.90999997, (float)110.730003), new Vector3((float)112.316002, (float)1.90999997, (float)101.440002) });
            }
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
            if (gameObject != null)
            {
              Destroy(gameObject);
            }
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
