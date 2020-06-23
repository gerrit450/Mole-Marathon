using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falcon : MonoBehaviour
{
    Rigidbody falcon = new Rigidbody();
    public FoxScript foxScript;
    private Vector3 pos;
    public Transform target; //mole's position
    public bool moving;
    private Vector3 turningPoint;
    private Vector3 tP;
    public float falconSpeed;



    void Start()
    {
        falcon = gameObject.GetComponent<Rigidbody>();
        GetComponent<BoxCollider>().enabled = false;
        falcon.useGravity = false;
        moving = true;
        pos = new Vector3(target.position.x + 5, target.position.y + 10, -1f);
        transform.position = pos; //sets the position of the falcon
        turningPoint = new Vector3(-20f, 20f, -1f);
        falconSpeed = 5f;
        falcon.velocity = new Vector3(-2.2f, -2.2f, 0f);
        foxScript = FindObjectOfType<FoxScript>(); // returns the pobject that matches
        
        
    }

    void Update()
    {
        chasing();
        checkOrientation();
    }

    void chasing()
    {

        if (moving == true)
        {

            falcon.transform.position = Vector3.MoveTowards(falcon.transform.position, target.transform.position, .05f);
            //doesn't subtract the vectors, but compares them, which means it never returns negative value
            float distance = Vector3.Distance(falcon.transform.position, target.transform.position); //calculates the distance between the falcon and the character
            
            if (distance < 1.5f)  //falcon attacks the mole and flies away, mole looses health points
            {
                moving = false;
                foxScript.healthSystem(); // decrease health points
            }
            if (target.transform.position.y <-0.5f) // if the mole goes under ground
            {
                moving = false;
                tP = new Vector3(target.transform.position.x, 1.2f, -1f); // a point just above the mole
                falcon.velocity = new Vector3(5f, -2f, 0f);

                falcon.transform.position = Vector3.MoveTowards(falcon.transform.position, tP, .05f); //falcon moves toward that position

                Vector3 mPosition = (turningPoint - falcon.transform.position).normalized;

                falcon.MovePosition(falcon.transform.position + mPosition * falconSpeed * Time.deltaTime);
                falcon.velocity = new Vector3(6f, 2f, 0f);
            }
        }
        else
        {
            falcon.transform.position = Vector3.MoveTowards(falcon.transform.position, turningPoint, .05f); //falcon flies away
            falcon.velocity = new Vector3(2f, 2f, 0f);

        }
        if (transform.position.y > 20)
        {
            moving = true;
            falcon.isKinematic = true;
            falcon.isKinematic = false;
            pos = new Vector3(target.position.x + 6, target.position.y + 15, -1f);
            transform.position = pos;
            StartCoroutine("Pause");

        }

    }

    public void checkOrientation()
    {
        if(falcon.transform.position.x > target.position.x)
        {
            var rotation = transform.rotation.eulerAngles;
            rotation.y = 0;
            falcon.transform.rotation = Quaternion.Euler(rotation);
        }
        else if (falcon.transform.position.x < target.position.x)
        {
            var rotation = transform.rotation.eulerAngles;
            rotation.y = 180;
            falcon.transform.rotation = Quaternion.Euler(rotation);
        }
    }
    IEnumerator Pause()
    {
        enabled = false;

        yield return new WaitForSeconds(4f);

        enabled = true;

    }

}

