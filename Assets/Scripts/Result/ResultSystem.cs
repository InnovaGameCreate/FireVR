﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSystem : MonoBehaviour {
    public GameObject star;     //星3dモデル
    public GameObject[] starfirstpos ;      //星の位置
    private ResltChecker resultcheck;         //ゲームシーンで集計したリザルト結果引継ぎように格納
    private bool debug = false;
    //ボーダー　0に近いほど良い
    //HPボーダー
    public float hpborder_bad = 0.8f;           //★1　境界
    public float hpborder_good = 0.2f;          //★3　境界
     //炎ボーダー
    public float fireborder_bad = 0.8f;
    public float fireborder_good = 0.2f;
    //NPCボーダー
    public float npcborder_bad = 0.8f;
    public float npcborder_good = 0.2f;
    void makeStar(int category,float []border)
    {
        float score = 0;
        if (!debug)
        {
            switch (category)
            {
                case 0:
                    score = resultcheck.get_hpscore();
                    break;
                case 1:
                    score = resultcheck.get_firescore();

                    break;
                case 2:
                    score = resultcheck.get_npcscore();
                    break;
                default:

                    break;
            }
        }
        else
            score = 0;


        Instantiate(star, starfirstpos[category].transform.position , star.transform.rotation);
        for (int i = 0; i < border.Length; i++)
        {
            if (border[i] < score)
                break;

            Instantiate(star, starfirstpos[category].transform.position + new Vector3(0.8f * (i+1), 0, 0), star.transform.rotation);

        }
    }
	// Use this for initialization
	void Start () {
        if(!debug)
        resultcheck = GameObject.Find("ResultCheck").GetComponent<ResltChecker>();
        makeStar(0, new float[] { 0.8f, 0.2f});
        makeStar(1, new float[] { 0.8f, 0.2f });
        makeStar(2, new float[] { 0.8f,  0.2f });
    }
         
  
}
