using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResltChecker : MonoBehaviour {
    private GameObject[][] sc_fire=new GameObject[2][];
    private GameObject[][] sc_npc = new GameObject[2][];
    private float lasthp,maxhp;
    float time;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        Check(sc_fire[0], "Fire");
        Check(sc_npc[0], "ScoreNPC");
    }
    private void Update()
    {
      
        if (time > 20)
        {
              finish();
            time = -1;
            Application.LoadLevel("Result");
           
        }
        else if(time!=-1)
            time += Time.deltaTime;
    }
    //ゲーム終了時(時間切れ)によぶこと
    public void finish()
    {
        Check(sc_fire[1], "Fire");
        Check(sc_npc[1], "ScoreNPC");
    }
    public float get_sc_fire()
    {
        return (float)sc_fire[1].Length / (float)sc_fire[0].Length;
    }

    //シーン上のBlockタグが付いたオブジェクトを数える
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
