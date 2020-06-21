﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class displayPower : MonoBehaviour
{
    private bool speeding = false;// P1 is not used yet
    private bool jumpingBoost;
    private bool enemiesOff;

    private Store storeInfo = new Store();
    Button[] powerButton = new Button[3];
    [SerializeField] Text[] powerText = new Text[3];
    private void Start()
    {
        storeInfo = FindObjectOfType<Store>();
        powerButton[0] = GameObject.Find("P#1").GetComponent<Button>();
        powerButton[1] = GameObject.Find("P#2").GetComponent<Button>();
        powerButton[2] = GameObject.Find("P#3").GetComponent<Button>();
        powerText[0].text = ""+ Store.PowerUp1Bought;
        powerText[1].text = "" + Store.PowerUp2Bought;
        powerText[2].text = "" + Store.PowerUp3Bought;
        powerButton[0].onClick.AddListener(power1Decrease);
        powerButton[1].onClick.AddListener(power2Decrease);
        powerButton[2].onClick.AddListener(power3Decrease);

    }
    void Update()
    {
     

    }

    public void power1Decrease()
    {
        if(Store.PowerUp1Bought > 0)
        {
          
            Store.PowerUp1Bought = Store.PowerUp1Bought - 1;
            powerText[0].text = "" + Store.PowerUp1Bought;
            setSpeeding(true);
            getSpeeding();
           
        }
        else
        {
            powerText[0].text = "N/A";
        }
       
    }
    public void power2Decrease()
    {
        if(Store.PowerUp2Bought > 0)
        {
            Store.PowerUp2Bought = Store.PowerUp2Bought - 1;
            powerText[1].text = "" + Store.PowerUp2Bought;
            setJumpingBoost(true);
            getJumpingBoost();

        }
        else
        {

            powerText[1].text = "N/A";
        }
    }
    public void power3Decrease()
    {
        if(Store.PowerUp3Bought > 0)
        {
            Store.PowerUp3Bought = Store.PowerUp3Bought - 1;
            powerText[2].text = "" + Store.PowerUp3Bought;
            setEnemiesOffBoost(true);
            getEnemiesOffBoost();
        }
        else
        {
            powerText[2].text = "N/A";
        }
       
    
    }


    public bool getSpeeding()
    {
        return speeding;
    }

    public void setSpeeding(bool sp)
    {
        speeding = sp;
    }

    public bool getJumpingBoost()
    {
        return jumpingBoost;
    }

    public void setJumpingBoost(bool jb)
    {
        jumpingBoost = jb;
    }

    public bool getEnemiesOffBoost()
    {
        return enemiesOff;
    }

    public void setEnemiesOffBoost(bool eOf)
    {
        enemiesOff = eOf;
    }

}
