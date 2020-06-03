using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
     public static Canvas popUp;
     private bool popUpIsOn;
    void Start()
    {
        popUp = gameObject.GetComponent<Canvas>();
        popUp.planeDistance = 0;
        popUpIsOn = false;

    }
    void Update()
    {
        gameOver();
    }
    private void gameOver()
    {
        if(FoxScript.health == 0 && popUpIsOn == false)
        {
            popUp.planeDistance = 10;
            popUpIsOn = true;
        }
    }
}
