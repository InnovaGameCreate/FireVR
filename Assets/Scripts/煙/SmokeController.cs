using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeController : MonoBehaviour
{
    private bool issmoking;         //煙出してるかどうか
    ParticleSystem smoke;           //煙パーティクルコンポーネント
    // Use this for initialization
    void Start()
    {
        smoke = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            if (!issmoking)
                smoke.Play();
            issmoking = true;
        }
        else if(issmoking)
        {
            smoke.Stop();
            issmoking = false;
        }
    }
}
