using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurorialController : MonoBehaviour
{
    //説明用テキスト
    [SerializeField]
    private Text sub;
    [SerializeField]
    private Text body;

    //VRカメラ
    [SerializeField]
    private Camera eye;
    //移動目標
    [SerializeField]
    private GameObject move_target_prefab;
    private GameObject move_target;
    //Npc
    private GameObject max;
    private TakeRemoveFire takeRemoveFire;
    //消火器
    private GameObject remove_fire;

    //効果音
    private AudioSource audio_source;//AudioSource

    //移動
    private bool Move()
    {
        //移動目標に近づけば
        if (Vector3.Distance(eye.transform.position, move_target.transform.position) < 2.0)
        {
            Destroy(move_target);//移動目標削除
            return true;//次のチュートリアルへ
        }
        return false;
    }

    //NPC
    private bool Npc()
    {
        //消化器を持ってくるフェーズに入れば次に進む
        if (takeRemoveFire.getState() == TakeRemoveFire.Faze.TAKE)
            return true;
        //消火器残量がなくなれば次に進む
        if (remove_fire.GetComponent<VRTK.Examples.FireRemove>().get_smokepercent() <= 0)
            return true;
        return false;
    }

    //消火器
    private bool RemoveFire()
    {
        //消火器残量がなくなれば次に進む
        if (remove_fire.GetComponent<VRTK.Examples.FireRemove>().get_smokepercent() <= 0)
            return true;
        return false;
    }

    // Use this for initialization
    void Start()
    {
        //Inspectorで登録するとうまく動作しなかったので検索で登録
        remove_fire = GameObject.Find("/消火器ver2");
        remove_fire.SetActive(false);//消火器消す
        max = GameObject.Find("/消火器持ってくるMAX");
        takeRemoveFire = max.GetComponent<TakeRemoveFire>();
        //SE
        audio_source = GetComponent<AudioSource>();
        //チュートリアル開始
        StartCoroutine("StateUpdate");
    }

    IEnumerator StateUpdate()
    {
        //移動
        sub.text = "移動";
        body.text = "1.「タッチパッド」を押してポインタを出します\n";
        body.text += "2.ポインタを移動したい方向に向けボタンを離します\n";
        body.text += "\n赤い物体に近づいてみてください\n";
        move_target = Instantiate(move_target_prefab);
        audio_source.Play();
        yield return new WaitUntil(Move);
        //NPC
        sub.text = "指示";
        body.text = "1.おじさんに近づいてください\n";
        body.text += "2.「Touchpad」を押してポインタを出し、おじさん上部のパネルから指示します\n";
        body.text += "\n消化器を持ってきてもらいましょう\n";
        max.transform.localPosition = new Vector3(0.0f, 0.3f, 0.0f);//NPC出現
        remove_fire.SetActive(true);//消火器出現
        max.GetComponent<TakeRemoveFire>().updateTagobjs();
        audio_source.Play();
        yield return new WaitUntil(Npc);
        //消火器
        sub.text = "消火器";
        body.text = "1.手を消化器に近づけ「グリップ」ボタンで握ってください\n";
        body.text += "2.握った手で「パッド」を、手前から奥にスライドして安全ピンを外します\n";
        body.text += "3.もう片方の手でホース先を握り火元に向け「トリガー」ボタンで発射します\n";
        body.text += "\n火を消してみてください\n";
        audio_source.Play();
        yield return new WaitUntil(RemoveFire);
        //次のシーンへ遷移
        sub.text = "";
        body.text = "これでチュートリアル終了です3秒後にゲーム開始です";
        audio_source.Play();
        yield return new WaitForSeconds(3.0f);
        Application.LoadLevel("maincamera");//LoadSceneが何故か使えないので旧形式で
    }
}
