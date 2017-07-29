using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Examples;

public class StopPosition : MonoBehaviour {
    private Animation anim ;
    private OpeHose ope;
    public Transform localtra;
    // Use this for initialization
    void Start () {
       anim = gameObject.GetComponent<Animation>();
        ope = GetComponent<OpeHose>();
    }
	
	// Update is called once per frame
	void Update () {

        if (ope.section == 1 && anim["Hose"].normalizedTime > 1)
        {
            localtra = transform;
            Destroy(anim);
            Destroy(GetComponent<Rigidbody>());
            ope.section = 2;
        }
        transform.localPosition = localtra.localPosition;
        transform.localRotation = localtra.localRotation;
    }
}
