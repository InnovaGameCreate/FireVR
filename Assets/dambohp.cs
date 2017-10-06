using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dambohp : MonoBehaviour
{
    private float count;
    public Material kogeta;
    const float outtime = 60 * 4;
    const float safetime = 60 * 2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if (count > safetime)
        {
            GetComponent<Renderer>().material = kogeta;
            if (outtime > count)
            {
                GetComponent<Renderer>().material.color = new Color((outtime - count) / (outtime - safetime) * 0.7f + 0.3f, (outtime - count) / (outtime - safetime) * 0.7f + 0.3f, (outtime - count) / (outtime - safetime) * 0.7f + 0.3f);
            }
            else
                GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 0.3f);
        }

    }
}
