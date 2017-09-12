using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFloor : MonoBehaviour {
    public GameObject tospace;
    public float moveheight;
    private GameObject player;  //プレイヤー
 
    private void Update()
    {
        if (player == null)
            player = GameObject.Find("[VRTK][AUTOGEN][BodyColliderContainer]");
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            Debug.Log(other.gameObject.name);
            other.transform.position = new Vector3( tospace.transform.position.x,moveheight, tospace.transform.position.z);
            other.transform.rotation = tospace.transform.rotation;
        }
    }
}
