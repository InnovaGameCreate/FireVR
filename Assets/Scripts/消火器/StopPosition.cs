using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Examples;

public class StopPosition : MonoBehaviour {
    private Animator anim ;
    private OpeHose ope;
    public Vector3 localtra;
    public Quaternion localrad;
    // Use this for initialization
    void Start () {
       anim = gameObject.GetComponent<Animator>();
        ope = GetComponent<OpeHose>();
    }
	
	// Update is called once per frame
	void Update () {

        if (ope.section == 1)
        {
            GetComponent<Animator>().enabled = true;
            Destroy(GetComponent<Rigidbody>());
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
            {
                localtra = transform.localPosition;
                localrad = transform.localRotation;
                ope.section = 2;
            }
        }
   
    }
}
