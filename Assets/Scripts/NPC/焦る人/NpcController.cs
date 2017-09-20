using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{

    private bool confused;  //焦り逃げ回っているか
    NavMeshAgent agent;     //ナビメッシュ格納
    public Transform exit;  //逃げ先
    private Animator ani;   //アニメーションコンポーネント
    
    private bool exiting;//逃げろと言われたフラグ
    [SerializeField] private GameObject UIImage;

    //逃げ先へ逃げる始める
    public void setToExiting()
    {
        exiting = true; //逃げている
        ani.SetLayerWeight(1, 0);   //回転アニメーションのレイヤーウェイトを0に
        agent.SetDestination(exit.position);    //ルート決定
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
        ani.SetLayerWeight(1, 1);   //回転アニメーションのレイヤーウェイトを1に
        ani.SetTrigger("Confused");     //走るアニメーションへ
     
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
        if(Input.GetKeyDown(KeyCode.K))
            setToExiting();
        //逃げ先まで2ユニット未満の距離なら消える
        if (Vector3.Distance(exit.position, transform.position) < 2)
            Destroy(this.gameObject);
    }
}
