using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResltChecker : MonoBehaviour {
    private GameObject[][] sc_fire=new GameObject[2][];     //炎の数(1次：スタート時/ 2次：クリア後)
    private GameObject[][] sc_npc = new GameObject[2][];    //逃げるであろうNPCの数(1次：スタート時/ 2次：クリア後)
    private float maxhp,lasthp;     //スタート時のHP,クリア後のHP
    private float time; //時間経過
    public int resttime =120; //シーン移動まで時間  ※デバッグ用
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        //スコア計測
        Check(sc_fire[0], "Fire");
        Check(sc_npc[0], "ScoreNPC");
    }
    private void Update()
    {
      
        if (time > resttime)
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
        Check(sc_fire[1], "Fire");
        Check(sc_npc[1], "ScoreNPC");
    }

    //炎の消火率     返り値 0(良)～1(悪)
    public float get_sc_fire()
    {
        return (float)sc_fire[1].Length / (float)sc_fire[0].Length;
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
