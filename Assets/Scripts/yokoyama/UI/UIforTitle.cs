﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIforTitle : MonoBehaviour {

    public GameObject _camera;

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(_camera.transform);
    }

    
    private void OnTriggerStay(Collider coll)
    {
        Debug.Log("hoge:" + coll.gameObject.name );
        
    }

    /*  [VRTK_Scripts] /LeftControllerとRightControllerのコンポーネント
     *  VRTK_Pointer内のEnable Teleportのチェックを外すとテレポ機能の削除ができる
     *  
     */

}
