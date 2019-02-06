using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static bool playerWon;

    public string sceneName = "finish";

    public GameObject[] enemies = new GameObject[2];

    GameObject player;

    Health playerHealthScript;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Regular_Character");
        playerHealthScript = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        for(int i = 0; i < enemies.Length;  i++)
        {
            if(enemies[i] == null)
            {
                count++;
            }
        }
        if(playerHealthScript.currentHealth < 0)
        {
            playerWon = false;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
        if(count == enemies.Length)
        {
            playerWon = true;
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
