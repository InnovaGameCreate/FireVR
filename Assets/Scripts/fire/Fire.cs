using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public int hp = 10;       //炎耐久値
    void OnParticleCollision(GameObject obj)
    {
      
        //処理内容
        //例）衝突したオブジェクトタグがenemyだった場合、オブジェクトを破壊する
        if (obj.gameObject.tag == "Smoke")
        {
            hp--;
            if(hp<=0)
            Destroy(this.gameObject);
        }
    }
}
