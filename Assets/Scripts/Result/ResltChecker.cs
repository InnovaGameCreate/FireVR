using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResltChecker : MonoBehaviour
{
    private GameObject[][] sc_fire = new GameObject[3][];     //炎の数(1次：スタート時/ 2次：クリア後/ 3次:現在の数)
    private GameObject[][] sc_npc = new GameObject[2][];    //逃げるであろうNPCの数(1次：スタート時/ 2次：クリア後)
    float firescore, npcscore;
    private float maxhp, lasthp;     //スタート時のHP,クリア後のHP
    private float time; //時間経過
    public int resttime = 120; //シーン移動まで時間  ※デバッグ用
    private bool LastFlag;
    public GameObject clearparticle;       //クリア時のパーティクル
    public Transform player;       //プレイヤー
    public GameObject clearui; //クリアUI
    private AudioSource[] se = new AudioSource[2]; //se
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        //スコア計測
        sc_fire[0] = GameObject.FindGameObjectsWithTag("Fire");
        sc_npc[0] = GameObject.FindGameObjectsWithTag("ScoreNPC");
        maxhp = lasthp = 100;
        LastFlag = false;
        se = GetComponents<AudioSource>();
     
    }
    private void Update()
    {
        if (LastFlag)
        {
            return;
        }
        sc_fire[2] = GameObject.FindGameObjectsWithTag("Fire");/*正直、無駄やと思うby横山*/

        if (time > resttime || sc_fire[2].Length == 0)
        {
            StartCoroutine(Clear());
            finish();
     
            LastFlag = true;
        }
        else if (time != -1)
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
    ////hpスコア 返り値 0(良)～1(悪)
    //public float get_hpscore()
    //{
    //    return (maxhp - lasthp) / maxhp;
    //}
    //Timeスコア 返り値 0(良)～1(悪)
    public float get_timescore()
    {
        return (time) / (float)resttime;
    }

    //シーン上のtagnameタグが付いたオブジェクトを数える
    void Check(GameObject[] tagObjects, string tagname)
    {
        tagObjects = GameObject.FindGameObjectsWithTag(tagname);
        Debug.Log(tagObjects.Length); //tagObjects.Lengthはオブジェクトの数
        if (tagObjects.Length == 0)
        {
            Debug.Log(tagname + "タグがついたオブジェクトはありません");
        }
    }

    //クリア
    IEnumerator Clear()
    {
        yield return new WaitForSeconds(1);
        GameObject ui;
        ui = Instantiate(clearui, player.position + player.forward * 2, player.rotation);
        ui.transform.parent = player;

        if (time > resttime)
        {
            ui.transform.FindChild("Text").gameObject.GetComponent<Text>().text = "時間切れ";
            se[1].Play();
        }
        else
        {
            se[0].Play();
            ui.transform.FindChild("Text").gameObject.GetComponent<Text>().text = "消化完了";
            GameObject[] particle = new GameObject[8];

            Vector3[] particlepos = new Vector3[8];
            for (int i = 0; i < particlepos.Length; i++)
                particlepos[i] = player.position;
            particlepos[0] += player.right;
            particlepos[1] -= player.right;
            particlepos[2] += player.up;
            particlepos[3] -= player.up;

            for (int i = 0; i < 4; i++)
            {
                particle[i] = Instantiate(clearparticle, particlepos[i], player.rotation);
                particle[i].transform.parent = player;
            }

            yield return new WaitForSeconds(1f);
            particlepos[4] += player.up;
            particlepos[4] += player.right;
            particlepos[5] += player.up;
            particlepos[5] -= player.right;
            particlepos[6] -= player.up;
            particlepos[6] -= player.right;
            particlepos[7] -= player.up;
            particlepos[7] += player.right;
            for (int i = 4; i < particlepos.Length; i++)
            {
                particle[i] = Instantiate(clearparticle, particlepos[i], player.rotation);
                particle[i].transform.parent = player;
            }
        }
        yield return new WaitForSeconds(5f);
        Application.LoadLevel("Result");        //リザルトシーンへ
    }
}
