using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{

    private bool confused;
    NavMeshAgent agent;     //ナビメッシュ格納
    public Transform exit;
    private Animator ani;
    
    private bool exiting;//逃げろと言われたフラグ
    [SerializeField] private GameObject UIImage;

    public void setToExiting()
    {
        exiting = true;
        ani.SetLayerWeight(1, 0);
    }
    private bool toReport = false;//通報しろと言われたフラグ

    public void SetActtive()
    {
        UIImage.SetActive(true);
        toReport = true;
        ani.SetTrigger("Idle");//通報中は動き止める
    }

    public void SetNonActtive()
    {
        UIImage.SetActive(false);
        toReport = false;
    }

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();

        confused = true;
        ani.SetLayerWeight(1, 1);
        ani.SetTrigger("Confused");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    if (!confused)
        //    {
        //        confused = true;
        //        ani.SetLayerWeight(1, 1);
        //        ani.SetTrigger("Confused");
        //    }
        //    else
        //    {
        //        exiting = true;
        //        ani.SetLayerWeight(1, 0);

        //    }
        //}


        if (exiting)
        {
            //ani.SetLayerWeight(1, 0);
            agent.SetDestination(exit.position);

            if (Vector3.Distance(exit.position, transform.position) <= agent.stoppingDistance)
            {
                
                ani.SetTrigger("Idle");
                
               // GetComponent<Animator>().applyRootMotion = false;
                exiting = false;
            }
        }
        if (Vector3.Distance(exit.position, transform.position) < 2)
            Destroy(this.gameObject);
    }
}
