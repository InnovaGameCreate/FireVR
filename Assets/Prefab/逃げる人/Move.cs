using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour {
    public Transform goal;
    Vector3 start;

    // Use this for initialization
    void Start () {

    }
	
	 //Update is called once per frame
	void Update () {
        Animator anim = GetComponent<Animator>();
        if (Input.GetKey("space"))
        {
            anim.SetBool("human", true);

            // 最初の位置を覚えておく
            start = transform.position;
            // NavMeshAgentを取得して
            var agent = GetComponent<NavMeshAgent>();

            // ゴールを設定。
            agent.destination = goal.position;
        }
    }
}
