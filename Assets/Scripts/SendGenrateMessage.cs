using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendGenrateMessage : MonoBehaviour
{
    GameObject cardboardBox_02;
    struct sendMessage
    {
        public string obj;
        public Vector3 position;
    }
    sendMessage msg;
    // Start is called before the first frame update
    void Start()
    {
        msg.obj = "cardboardBox_02";
        msg.position = new Vector3(0, 0, 0);
        //FindObjectOfType<GetGenerateMessage> ().SendMessage("MessageOp", msg);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
