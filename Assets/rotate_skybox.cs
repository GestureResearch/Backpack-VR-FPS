using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_skybox : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        RenderSettings.skybox.SetFloat("_Rotation", 76.6f);

    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }
}

