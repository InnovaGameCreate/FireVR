using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincameracontroller : MonoBehaviour {
    public GameObject camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(camera==null)
            Application.LoadLevel("NewStage");//LoadSceneが何故か使えないので旧形式で
    }
}
