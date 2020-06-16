using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using System.Runtime.CompilerServices;
=======
>>>>>>> master

public class FoxScript : MonoBehaviour
{
    
    private Rigidbody body = new Rigidbody();
    private Vector3 position;
    private float areaOfTrigger;
<<<<<<< HEAD
    private float yTrigger;
=======
>>>>>>> master
    public static int health;
    public Transform target;
    public Text Damage;
    
    void Start()
    {
        /*
         * This should be seperated from fox script to a new script called 'characterHealth'
         * 
         */
        body = gameObject.GetComponent<Rigidbody>();
        body.useGravity = false;
        areaOfTrigger = 1f;
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        body.freezeRotation.Equals(true);
       
        switch (DifficultyValues.Difficulty)
        {
            case DifficultyValues.Difficulties.Easy:
                health = 5;
                Damage.text = "❤ ❤ ❤ ❤ ❤";
                break;
            case DifficultyValues.Difficulties.Medium:
                health = 3;
                Damage.text = "❤ ❤ ❤";
                break;
            case DifficultyValues.Difficulties.Hard:
                health = 1;
                Damage.text = "❤";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        body.AddForce(-0.7f, 0f, 0f);
        yTrigger = 0 + target.position.y;
        print("Trigger: "+ yTrigger);
        if (target.position.x <= transform.position.x)
        {
            if (target.position.x > transform.position.x - areaOfTrigger) // x coordinate trigger
            {
                
                if (target.position.y == yTrigger) // y coordinate trigger
                {
                    print("3works");
=======
        body.AddForce(-0.5f, 0f, 0f);

        if (target.position.x <= transform.position.x)
        {
            if (target.position.x > transform.position.x - areaOfTrigger)
            {
                if (target.position.y == transform.position.y)
                {
>>>>>>> master
                    healthSystem();
                    StartCoroutine("Pause");
                }
            }
        }
    }

    /*
         * This should be seperated from fox script to a new script called 'characterHealth'
         * 
         */
    public void healthSystem()
    {
        health--;

        switch (health)
        {
            case 0:
                Damage.text = "GAME OVER!";
                GameOver.popUp.enabled = true;
               // gameOver.enabled = true;
                //SceneManager.LoadScript("Menu");
                body.isKinematic = true;
                break;

            case 1:
                Damage.text = "❤";
                break;

            case 2:
                Damage.text = "❤ ❤";
                break;
            case 3:
                Damage.text = "❤ ❤ ❤";
                break;
            case 4:
                Damage.text = "❤ ❤ ❤ ❤";
                break;
            case 5:
                Damage.text = "❤ ❤ ❤ ❤ ❤";
                break;


        }

       print(health);
    }
    IEnumerator Pause()
    {
        enabled = false;

        yield return new WaitForSeconds(.7f);
        
        enabled = true;

    }

}
