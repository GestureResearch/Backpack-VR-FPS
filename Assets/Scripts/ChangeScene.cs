using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public string sceneName;

    void OnDestroy()
    {
        GameObject player = GameObject.Find("Regular_Character");
        player.GetComponent<Health>().currentHealth = player.GetComponent<Health>().startingHealth;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
