using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TakeRemoveFire : MonoBehaviour
{
    public Transform player;          //プレイヤー
    NavMeshAgent agent;     //ナビメッシュ格納
    private Faze state = Faze.WAIT;    //消火器持ってくるアクション段階
    private GameObject[] tagobjs;      //マップ上すべての消火器obj
    private GameObject nearobj; //NPCから最も近い消火器
    private bool toTakeRemoveFire = false;//消化器をもってこいと言われたフラグ
 
    //待機→消火器に向かう→消火器もってくる→終了　
    enum Faze
    {
        WAIT,          //待機状態
        PRETAKE,       //消火器にむかう
        TAKE,          //消火器を持ってくる
        FINISH         //終了
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();       //ナビメッシュ取得
        tagobjs = GameObject.FindGameObjectsWithTag("RemoveFire");

    }
    //最も近い消火器を計算
    void nearRemoveFire()
    {
        GameObject nearobj = null;      //最も近い消火器オブジェクト
        float mindistance = -1;　　//最小距離
        //マップ上すべての消火器タグのついたものを調べる  ただし採用するのは煙残量100%のもののみ
        foreach (GameObject removefire in tagobjs)
        {
            //消火器までの距離
            float distance = Vector3.Distance(transform.position, removefire.transform.position);
            //距離が短ければデータ更新 
             if (mindistance == -1 || mindistance > distance && removefire.GetComponent<VRTK.Examples.FireRemove>().get_smokepercent() == 100) 
            {
                mindistance = distance;
                nearobj = removefire;
            }

        }
        this.nearobj = nearobj;
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
               
                if (toTakeRemoveFire )
                {
                    nearRemoveFire();
                    //煙残量100%の消火器が見つからなければ持ってこない
                    if (get_nearobj() == null)
                        return;
       
                    state = Faze.PRETAKE;
                    agent.SetDestination(get_nearobj().transform.position);     //消火器へ移動
                    GetComponent<Animator>().SetTrigger("Run");
                
                }
                break;
            case Faze.PRETAKE:
                //ナビゲーション距離が一定以上になるとagent.remainingDistance が0になるため agent.remainingDistance != 0
                if (agent.remainingDistance <= agent.stoppingDistance && agent.remainingDistance != 0)
                {
                 
                    state = Faze.TAKE;
                    //消火器をNPCの子にして位置補正
                    get_nearobj().transform.parent = transform;
                    get_nearobj().transform.localPosition = new Vector3(0, 1.2f, 0.4f);
                    get_nearobj().transform.localRotation = Quaternion.Euler(0, 180, 0);
                    get_nearobj().GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    
                    agent.stoppingDistance = 2;     //agent.stoppingDistance =1 だとプレイヤーと近いため2に更新
                    GetComponent<IKControl>().ikActive = true;  //ik有効
                    agent.SetDestination(player.position);       //プレイヤーへ移動
                }
                break;
            case Faze.TAKE:


                if (agent.remainingDistance <= agent.stoppingDistance && agent.remainingDistance != 0)
                {
                    state = Faze.FINISH;
                    GetComponent<Animator>().SetTrigger("Idle");        
                    get_nearobj().GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    GetComponent<IKControl>().ikActive = false; //ik無効
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
