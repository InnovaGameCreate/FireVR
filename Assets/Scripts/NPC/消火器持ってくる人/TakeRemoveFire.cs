using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TakeRemoveFire : MonoBehaviour {
    public Transform player;          //プレイヤー
    NavMeshAgent agent;     //ナビメッシュ格納
    private Faze state = Faze.WAIT;    //消火器持ってくるアクション段階
    private GameObject[] tagobjs;      //マップ上すべての消火器obj
    private GameObject nearobj; //NPCから最も近い消火器

    //待機→消火器に向かう→消火器もってくる→終了　
    enum Faze
    {
        WAIT,
        PRETAKE,
        TAKE,
        FINISH
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
         tagobjs = GameObject.FindGameObjectsWithTag("RemoveFire");

    }
    //最も近い消火器を計算
    void nearRemoveFire()
    {
        GameObject nearobj= null;
        float mindistance = -1;
        foreach (GameObject removefire in tagobjs)
        {
            float distance = Vector3.Distance(transform.position, removefire.transform.position);
            if (mindistance == -1|| mindistance > distance)
            {
                mindistance = distance;
                nearobj = removefire;
            }

        }
        this.nearobj=nearobj;
    }

    //最も近い消火器を返す
    public GameObject get_nearobj()
    {
        return nearobj;
    }
    void Update()
    {
        switch (state)
        {
            case Faze.WAIT:
                if (Input.GetKeyDown(KeyCode.J))
                {
                    nearRemoveFire();
                    // agent.SetDestination(target.position);
                    state = Faze.PRETAKE;
                    agent.SetDestination(get_nearobj().transform.position);
                    GetComponent<Animator>().SetTrigger("Run");
                }
                    break;
            case Faze.PRETAKE:
                if (agent.remainingDistance <= agent.stoppingDistance&& agent.remainingDistance!=0)
                {
                 
                    state = Faze.TAKE;
                    get_nearobj().transform.parent = transform;
                    get_nearobj().transform.localPosition = new Vector3(0, 1.2f, 0.4f);
                    get_nearobj().transform.localRotation = Quaternion.Euler(0, 180, 0);

                    get_nearobj().GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    agent.stoppingDistance = 2;
                    GetComponent<IKControl>().ikActive = true;
                    agent.SetDestination(player.position);
                }
                break;
            case Faze.TAKE:
          
                
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    state = Faze.FINISH;
                    GetComponent<Animator>().SetTrigger("Idle");
                    get_nearobj().GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    GetComponent<IKControl>().ikActive = false;
                }
                //else
                //{
                //    GetComponent<Animator>().SetTrigger("Run");
                //}
                break;
            case Faze.FINISH:
                break;
            default:
                break;
        }
   
    }

}
