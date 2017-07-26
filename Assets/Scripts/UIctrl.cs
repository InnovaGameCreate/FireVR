using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIctrl : MonoBehaviour {
    public GameObject camera;
    public GameObject Point;
    public float distance;
    public float MoveSpeed;

    //private Vector3 distance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        //カメラの前に現れる
        //this.transform.position = Point.transform.position;
        this.transform.position = Vector3.Slerp(this.transform.position, Point.transform.position, MoveSpeed);
        //カメラの方向を見る
        this.transform.LookAt(camera.transform);
    }
}
