using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class AutoActive : MonoBehaviour
{
    [SerializeField]
    private GameObject main_panel;//メインパネル
    private Canvas canvas;//キャンバス
    Vector3 default_position;
    Vector3 default_local_position;
    [SerializeField]
    private GameObject area;//範囲の当たり判定を持ったオブジェクト
    public GameObject camera0;//カメラ

    //焦る人につけるときに使用
    [SerializeField]
    private NpcController npc_controller;

    public float active_distance = 0;//表示する距離

    // Use this for initialization
    void Start()
    {
        if (npc_controller)
        {
            default_position = main_panel.transform.position;
            default_local_position = main_panel.transform.localPosition;
        }
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //当たり判定の大きさを更新
        if (active_distance != area.transform.localScale.x)
        {
            area.transform.localScale = new Vector3(active_distance, 0.1f, active_distance);
        }
        if (npc_controller)
        {
            //NPCが焦っているときUIが動かないように
            if (npc_controller.isConfused())
            {
                main_panel.transform.position = default_position;
            }
            else
            {
                main_panel.transform.localPosition = default_local_position;
            }
        }
        //キャンバスをカメラの向きに
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(transform.position.x - camera0.transform.position.x, 0.0f, transform.position.z - camera0.transform.position.z)), 1.0f);
    }

    public void EnableCanvas(bool b)
    {
        canvas.enabled = b;
    }
}
