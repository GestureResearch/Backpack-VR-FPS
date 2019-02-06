using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayStatus : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        if(GameManagerScript.playerWon)
        {
            this.GetComponent<TextMesh>().text = "You WON!";
        }
        else
        {
            this.GetComponent<TextMesh>().text = "You LOST!";
        }
    }
}
