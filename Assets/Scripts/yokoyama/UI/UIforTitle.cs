using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIforTitle : MonoBehaviour {

    public GameObject _camera;

	// Use this for initialization
	void Start () {
        //_camera = GameObject.Find("Camera (eye)");//カメラ探してきて代入 名前違いに注意

    }
	
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(_camera.transform);
    }

    
    //private void OnTriggerStay(Collider coll)
    //{
    //    Debug.Log("hoge:" + coll.gameObject.name );
        
    //}

    /*  [VRTK_Scripts] /LeftControllerとRightControllerのコンポーネント
     *  VRTK_Pointer内のEnable Teleportのチェックを外すとテレポ機能の削除ができる
     *  
     */

}
