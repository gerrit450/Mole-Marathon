using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Start()
    {
        
    }
    void Update()
    {
        Jump();
        Vector3 obMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += obMovement * Time.deltaTime * moveSpeed;
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {//ForceMode.Impulse adds impulse to the body using its mass
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 5f));//, ForceMode2D.Impulse);
        }
       
    }


    //private Rigidbody body = new Rigidbody();
    //void Start()
    //{
    //    body = gameObject.GetComponent<Rigidbody>();
    //}

    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        body.AddForce(10f, 0f, 0f);
    //    }
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        body.AddForce(-10f, 0f, 0f);
    //    }
    //    if (Input.GetKey(KeyCode.UpArrow))
    //    {
    //        body.AddForce(0f, 0.5f, 0f);
    //    }
    //    //Vector3 yPos = transform.position;

    //    float yCoord = transform.position.y;
    //    float xCoord = transform.position.x;
    //    if (transform.position.y >= 5)
    //    {
    //        do
    //        {
    //            //yPos -= 2.0f;
    //            yCoord -= 1.0f;
    //            transform.position = new Vector3(xCoord, yCoord, -1);
    //        }
    //        while (yCoord >= 0f);
    //    }

    //    if (Input.GetKey(KeyCode.DownArrow))
    //    {
    //        body.AddForce(0f, -10f, 0f);
    //    }
    //    // body.AddForce(1f, 0f, 0f);
    //}
}
