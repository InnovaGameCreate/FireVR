using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportFloor : MonoBehaviour {
    public GameObject tospace;
    public float moveheight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3( tospace.transform.position.x,moveheight, tospace.transform.position.z);
            other.transform.rotation = tospace.transform.rotation;
        }
    }
}
