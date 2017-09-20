using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Examples;

public class StopPosition : MonoBehaviour {
    private Animator anim ;     //アニメーターコンポーネント
    private OpeHose ope;        //ホースコンポーネント
    public Vector3 localtra;    //解放時の初期化位置
    public Quaternion localrad; //解放時の初期化回転
    // Use this for initialization
    void Start () {
       anim = gameObject.GetComponent<Animator>();
        ope = GetComponent<OpeHose>();
    }
	
	// Update is called once per frame
	void Update () {

        if (ope.section == 1)
        {
            GetComponent<Animator>().enabled = true;
            Destroy(GetComponent<Rigidbody>());
            //アニメーション再生が終了してれば解放時の初期化位置を保存
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                localtra = transform.localPosition;
                localrad = transform.localRotation;
                ope.section = 2;
            }
        }
   
    }
}
