using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFire : MonoBehaviour {
    private int count;      //着火までのカウンター
    public GameObject fire;  //炎オブジェクト
    private bool check;

    private void Update()
    {
   
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Fire"))
        {
           
            check = true;
        }
        if (!check) {
            if (other.CompareTag("Wood"))
            {
                count++;
            }
            if (count > 60 * 7 )
            {
                Instantiate(fire, transform.position, transform.rotation);
                check = true;
            }
        }
    }
}
