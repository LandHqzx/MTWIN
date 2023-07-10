using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectionsMovement : MonoBehaviour
{
    GenerateMessages generateMessage;
    public string gameObj;
    GameObject obj;
    Vector3 objPosition;
    struct GenerateMessages
    {
        //存储信号内容的结构体
        public string product;
        public Vector3 position;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void GenerateObj(GameObject product, Vector3 position)
    {
        //生成物品的函数
        Instantiate(product, position, transform.rotation);

    }
    void MessageOp(GenerateMessages generateMessage)
    {
        //其他脚本调用本脚本的启动函数
        gameObj = generateMessage.product;
        objPosition = generateMessage.position;
        obj = GameObject.Find("Assets/Prefabs/" + gameObj);
        GenerateObj(obj, objPosition);
    }
}
