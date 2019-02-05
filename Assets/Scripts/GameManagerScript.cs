using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public string sceneName = "finish";

    public GameObject[] enemies = new GameObject[2];

    // Use this for initialization
    void Start()
    {

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
        if(count == enemies.Length)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
