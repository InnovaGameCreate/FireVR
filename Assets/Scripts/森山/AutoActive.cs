using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class AutoActive : MonoBehaviour
{
    private Canvas canvas;//キャンバス
    private SphereCollider col;//コライダー

    public float active_distance = 0;//表示する距離

    // Use this for initialization
    void Start()
    {
        canvas = GetComponent<Canvas>();
        //当たり判定追加
        col = gameObject.AddComponent<SphereCollider>();
        col.radius = active_distance;
        col.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        //当たり判定の大きさを更新
        if (active_distance != col.radius)
        {
            col.radius = active_distance;
        }
    }

    void OnTriggerStay(Collider other)
    {
        //カメラが範囲内に入った
        if (other.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            canvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //カメラが範囲内から出た
        if (other.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            canvas.enabled = false;
        }
    }
}
