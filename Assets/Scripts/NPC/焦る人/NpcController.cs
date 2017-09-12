using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{

    private bool confused;
    private bool exiting;
    NavMeshAgent agent;     //ナビメッシュ格納
    public Transform exit;
    private Animator ani;
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!confused)
            {
                confused = true;
                ani.SetLayerWeight(1, 1);
                ani.SetTrigger("Confused");
            }
            else
            {
                exiting = true;
                ani.SetLayerWeight(1, 0);
 
            }
        }
       
        if (exiting)
        {
            agent.SetDestination(exit.position);

            if (Vector3.Distance(exit.position, transform.position) <= agent.stoppingDistance)
            {

                ani.SetTrigger("Idle");
                
               // GetComponent<Animator>().applyRootMotion = false;
                exiting = false;
            }
        }
    }
}
