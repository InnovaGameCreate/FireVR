using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area : MonoBehaviour {

    [SerializeField]
    private GameObject canvas;
    private AutoActive auto_active;

    private void Start()
    {
        auto_active = canvas.GetComponent<AutoActive>();
    }

    void OnTriggerStay(Collider other)
    {
        //カメラが範囲内にいる
        if (other.gameObject.name == "[VRTK][AUTOGEN][FootColliderContainer]")
        {
            auto_active.EnableCanvas(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //カメラが範囲内から出た
        if (other.gameObject.name == "[VRTK][AUTOGEN][FootColliderContainer]")
        {
            auto_active.EnableCanvas(false);
        }
    }
}
