using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIforTitle : MonoBehaviour {
    public bool Yrot;
    public GameObject _camera;
    private Vector3 mevec;

	// Use this for initialization
	void Start () {
        //_camera = GameObject.Find("Camera (eye)");//カメラ探してきて代入 名前違いに注意

    }
	
	// Update is called once per frame
	void Update () {
        //this.transform.LookAt(_camera.transform);
        if(Yrot)
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(transform.position - _camera.transform.position),1.0f);
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3( transform.position.x - _camera.transform.position.x , 0.0f , transform.position.z - _camera.transform.position.z)), 1.0f);
        }
    }

    
    

}
