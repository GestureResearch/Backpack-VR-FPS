using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public string sceneName;

    void OnDestroy()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("finish"))
            Destroy(GameObject.Find("Regular_Character"));
        SceneManager.LoadScene(sceneName);
    }
}
