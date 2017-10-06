using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//このコンポーネントを付けたオブジェクトの子に炎を設置すること
public class FireSound : MonoBehaviour
{
    private List<GameObject> fire = new List<GameObject>();   //子の炎  
    private int num;       //炎の数
    private AudioSource []firese;       //炎効果音
    // Use this for initialization
    void Start()
    {
        firese = GetComponents<AudioSource>();

        //Fireタグのオブジェクトを格納  リスト格納数 数え上げ
        foreach (Transform child in transform)
        {
            foreach (Transform childchild in child)
            {
                if (childchild.gameObject.CompareTag("Fire"))
                {
                    fire.Add(childchild.gameObject);
                    num++;
                }
            }
        }


    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < num; i++)
        {
            //炎が消えてたらリスト除去
            if (fire[i] == null)
            {
                num--;
                fire.Remove(fire[i]);
            }
        }
        Debug.Log(num);
        //子の炎がすべて消えたときに音を消す
        if (num == 0)
        {
            for (int j = 0; j < firese.Length; j++)
                firese[j].Stop();
        }


    }
    private void OnTriggerEnter(Collider other)
    {

    }
}
