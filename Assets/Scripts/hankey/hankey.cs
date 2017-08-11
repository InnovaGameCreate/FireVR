using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hankey : MonoBehaviour
{

    [SerializeField]
    public Camera eye;//目
    [SerializeField]
    public float enable_distance = 0.2f;//ハンカチを有効にする距離

    private Text text;//Text(UI)

    // Use this for initialization
    void Start()
    {
        text = GameObject.Find("ハンカチ/Canvas/Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //ハンカチを掴んでいる && 目との距離が0.2
        if (!GetComponent<VRTK.VRTK_InteractableObject>().isGrabbable && Vector3.Distance(eye.transform.position, transform.position) < enable_distance)
        {
            text.text = "OK";//OKを表示
        }
        else
        {
            text.text = "ハンカチ";
        }
    }
}
