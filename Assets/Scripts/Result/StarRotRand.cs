using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotRand : MonoBehaviour {
    private float rand;         //待機時間　乱数
    private float timer;        //経過時間
	// Use this for initialization
	void Start () {
        rand = Random.value*3;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > rand)
            GetComponent<Animator>().enabled = true;
		
	}
}
