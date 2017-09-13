using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyPos : MonoBehaviour {
    private Vector3 firstpos;
	// Use this for initialization
	void Start () {
        firstpos = transform.position;
	}
	
    public void set_firstpos()
    {
        firstpos = transform.position;
    }
	// Update is called once per frame
	void Update () {
        if (transform.position.y < -0.6)
            transform.position = firstpos;
	}
}
