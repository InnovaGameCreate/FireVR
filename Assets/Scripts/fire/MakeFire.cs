using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//着火候補に燃えるものがあれば着火
public class MakeFire : MonoBehaviour
{
    private int count;      //着火までのカウンター
    public GameObject fire;  //炎オブジェクト
    public int firetime = 7;     //燃え移るまでの時間
    private bool check;      //燃えるものに接触してるか　　着火は一回きり 再燃焼なし

    private void OnTriggerStay(Collider other)
    {
        //着火候補に既に炎があれば　着火しない
        if (other.CompareTag("Fire"))
        {
            check = true;
        }

        //着火可能
        if (!check)
        {
            //材質が木なら
            if (other.CompareTag("Wood"))
            {
                count++;
            }
            //約firetime秒後に着火
            if (count > 60 * firetime)
            {
                Instantiate(fire, transform.position, transform.rotation);
                check = true;
            }
        }
    }
}
