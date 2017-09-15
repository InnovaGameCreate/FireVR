using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class AutoActive : MonoBehaviour
{
    private Canvas canvas;//キャンバス
    [SerializeField]
    private GameObject area;//範囲の当たり判定を持ったオブジェクト
    public GameObject camera0;//カメラ

    public float active_distance = 0;//表示する距離

    // Use this for initialization
    void Start()
    {
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
        //キャンバスをカメラの向きに
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(transform.position.x - camera0.transform.position.x, 0.0f, transform.position.z - camera0.transform.position.z)), 1.0f);
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
        //カメラが範囲内に入った
        if (other.gameObject.name == "[VRTK][AUTOGEN][FootColliderContainer]")
        {
            canvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //カメラが範囲内から出た
        if (other.gameObject.name == "[VRTK][AUTOGEN][FootColliderContainer]")
        {
            canvas.enabled = false;
        }
    }
}
