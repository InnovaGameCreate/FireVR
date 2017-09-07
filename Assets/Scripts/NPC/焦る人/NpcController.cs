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
    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (!confused)
            {
                confused = true;
                GetComponent<Animator>().SetLayerWeight(1, 1);
                GetComponent<Animator>().SetTrigger("Confused");
            }
            else
            {
                exiting = true;
                GetComponent<Animator>().SetLayerWeight(1, 0);
 
            }
        }
       
        if (exiting)
        {
            agent.SetDestination(exit.position);

            if (Vector3.Distance(exit.position, transform.position) <= agent.stoppingDistance)
            {
              
                GetComponent<Animator>().SetTrigger("Idle");
                
               // GetComponent<Animator>().applyRootMotion = false;
                exiting = false;
            }
        }
    }
}
