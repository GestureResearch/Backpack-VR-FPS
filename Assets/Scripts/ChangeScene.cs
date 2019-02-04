﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public string sceneName;

    public GameObject player;

    void OnDestroy()
    {
        Destroy(player);
        SceneManager.LoadScene(sceneName);        
    }

}
