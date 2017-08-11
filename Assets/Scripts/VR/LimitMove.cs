using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMove : MonoBehaviour {
    public GameObject head; //プレイヤーの位置
	
	// Update is called once per frame
	void Update () {
        transform.position = head.transform.position;
            transform.rotation= head.transform.rotation;
    }
}
