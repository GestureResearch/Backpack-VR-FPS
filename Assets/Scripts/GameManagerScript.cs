using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject player;
    
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
        if(count == 2)
        {
            Destroy(player);
            SceneManager.LoadScene("finish");
        }
    }
}
