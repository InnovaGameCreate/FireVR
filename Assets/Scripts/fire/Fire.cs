using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public int hp = 10;       //炎耐久値
    void OnParticleCollision(GameObject obj)
    {

        //処理内容
        //衝突したオブジェクトタグがSmokeだった場合、炎耐久値を減らす　0以下で消滅
        if (obj.gameObject.tag == "Smoke")
        {
            hp--;
            if(hp<=0)
            Destroy(this.gameObject);
        }
    }
}
