using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChengeScene : MonoBehaviour {

    public string SecneName;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChengeSceneFunc()
    {
        SceneManager.LoadScene(SecneName);
    }
}
