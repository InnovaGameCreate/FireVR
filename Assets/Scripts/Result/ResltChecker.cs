using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResltChecker : MonoBehaviour {
    private GameObject[][] sc_fire=new GameObject[3][];     //炎の数(1次：スタート時/ 2次：クリア後/ 3次:現在の数)
    private GameObject[][] sc_npc = new GameObject[2][];    //逃げるであろうNPCの数(1次：スタート時/ 2次：クリア後)
    float firescore,npcscore;
    private float maxhp,lasthp;     //スタート時のHP,クリア後のHP
    private float time; //時間経過
    public int resttime =120; //シーン移動まで時間  ※デバッグ用
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        //スコア計測
        sc_fire[0] = GameObject.FindGameObjectsWithTag("Fire");
        sc_npc[0] = GameObject.FindGameObjectsWithTag("ScoreNPC");
        maxhp = lasthp = 100;
      
    }
    private void Update()
    {
        sc_fire[2] = GameObject.FindGameObjectsWithTag("Fire");/*正直、無駄やと思うby横山*/

        if (time > resttime || sc_fire[2].Length == 0)
        {
              finish();
            time = -1;
            Application.LoadLevel("Result");        //リザルトシーンへ
           
        }
        else if(time!=-1)
            time += Time.deltaTime;
    }
    //ゲーム終了時(時間切れ)によぶこと
    public void finish()
    {
        //スコア計測
        sc_fire[1] = GameObject.FindGameObjectsWithTag("Fire");
        sc_npc[1] = GameObject.FindGameObjectsWithTag("ScoreNPC");
        firescore = (float)(sc_fire[1].Length) / (float)(sc_fire[0].Length);
        npcscore = (float)(sc_npc[1].Length) / (float)(sc_npc[0].Length);
    }

    //炎の消火率     返り値 0(良)～1(悪)
    public float get_firescore()
    {
        return firescore;
    }
    //npcフラグ解決率     返り値 0(良)～1(悪)
    public float get_npcscore()
    {
        return npcscore;
    }
    //hpスコア 返り値 0(良)～1(悪)
    public float get_hpscore()
    {
        return (maxhp - lasthp) / maxhp;
    }

    //シーン上のtagnameタグが付いたオブジェクトを数える
    void Check(GameObject[] tagObjects,string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数
        if (tagObjects.Length == 0)
        {
            Debug.Log(tagname + "タグがついたオブジェクトはありません");
        }
    }
}
