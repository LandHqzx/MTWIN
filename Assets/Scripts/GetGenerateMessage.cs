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
        //�洢�ź����ݵĽṹ��
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
        //������Ʒ�ĺ���
        Instantiate(product, position, transform.rotation);

    }
    void MessageOp(GenerateMessages generateMessage)
    {
        //�����ű����ñ��ű�����������
        gameObj = generateMessage.product;
        objPosition = generateMessage.position;
        obj = GameObject.Find("Assets/Prefabs/" + gameObj);
        GenerateObj(obj, objPosition);
    }
}
