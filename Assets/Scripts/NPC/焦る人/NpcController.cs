using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour {

    private bool confused;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K)&&!confused)
        {
            confused = true;
            GetComponent<Animator>().SetLayerWeight(1, 1);
            GetComponent<Animator>().SetTrigger("Confused");
        }

    }
}
