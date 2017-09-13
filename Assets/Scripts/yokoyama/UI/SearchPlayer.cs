using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlayer : MonoBehaviour {

    private bool FoundPlayer;

	// Use this for initialization
	void Start () {
        FoundPlayer = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider coll)
    {
        //Debug.Log(coll.gameObject.name);
        if (coll.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            FoundPlayer = true;
            //Debug.Log("nanndedesuka");
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            FoundPlayer = false;
            Debug.Log(coll.gameObject.name);
        }
    }

    //プレイヤーが範囲に入ってるどうか
    public bool isSercchPlayer()
    {
        return FoundPlayer;
    }
}
