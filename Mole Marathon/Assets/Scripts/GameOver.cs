using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static Canvas popUp;
    bool popUpIsOn;

    void Start()
    {
        popUp = gameObject.GetComponent<Canvas>();
        popUp.planeDistance = 0;
        popUpIsOn = false;

    }

    // Update is called once per frame
    void Update()
    {
        gameOver();
    }

    void gameOver()
    {
        if(FoxScript.health == 0 && popUpIsOn == false)
        {
            popUp.planeDistance = 10;
            popUpIsOn = true;
        }
    }
}
