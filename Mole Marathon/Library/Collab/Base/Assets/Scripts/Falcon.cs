using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falcon : MonoBehaviour
{
    Rigidbody falcon = new Rigidbody();
    private Vector3 pos;
    public Transform target; //target position- player position
    public bool moving;
    //float falconSpeed = 1.5f;
    private Vector3 turningPoint;


    void Start()
    {
        falcon = gameObject.GetComponent<Rigidbody>();
        falcon.useGravity = false;
        moving = true;
        pos = new Vector3(5f, 10f, -1f);
        transform.position = pos; //sets the position of the falcon
        turningPoint = new Vector3(3f, 8f, -1f);
        falcon.AddForce(-2f, -2f, 0f);

    }

    void Update()
    {

        // falcon.AddForce(-2f, 0f, 0f);
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        chasing();
    }

    void chasing()
    {
        //if(transform.position == turningPoint) //falcon reaches certain point
        if (moving == true)
        {
            //falcon.AddForce(-2f, 0f, 0f);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, .05f);


            //MovePosition moves the rigidBody towards specified position
            //falcon.MovePosition(target.position);
        }


    }
}

