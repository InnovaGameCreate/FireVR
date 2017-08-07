using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIctrl : MonoBehaviour {
    public GameObject Search;
    public GameObject camera;
    public GameObject Point;//UI出現ポイント
    //public float distance;
    public float MoveSpeed;

    private SearchPlayer _search;
    private Canvas _canvas;

	// Use this for initialization
	void Start () {
        _search = Search.GetComponent<SearchPlayer>();
        _canvas = GetComponent<Canvas>();

        _canvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (_search.isSercchPlayer() ) {
            _canvas.enabled = true;

            //カメラの方向を見る
            this.transform.LookAt(camera.transform);
        }
        else
        {
            _canvas.enabled = false;
        }
    }
}
