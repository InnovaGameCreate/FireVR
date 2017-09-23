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

    //消火器
    [SerializeField]
    private GameObject remove_fire;

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

    //消火器
    private bool RemoveFire()
    {
        return false;
    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine("StateUpdate");
    }

    IEnumerator StateUpdate()
    {
        //移動
        sub.text = "移動";
        body.text = "1.「Touchpad」を押してポインタを出します\n";
        body.text += "2.ポインタを移動したい方向に向けボタンを離します\n";
        body.text += "\n赤い物体に近づいてみてください\n";
        move_target = Instantiate(move_target_prefab);
        yield return new WaitUntil(Move);
        //消火器
        sub.text = "消火器";
        body.text = "1.手を消化器に近づけ「Grip」ボタンで握ってください\n";
        body.text += "2.握った手で「Touchpad」を、手前から奥にスライドして安全ピンを外します\n";
        body.text += "3.もう片方の手でホース先を握り火元に向け「Trigger」ボタンで発射します\n";
        body.text += "\n火を消してみてください\n";
        remove_fire.transform.position = new Vector3(0.0f, 0.3f, 0.0f);
        yield return new WaitUntil(RemoveFire);
        //次のシーンへ遷移
        SceneManager.LoadScene("yokoyama");
    }
}
