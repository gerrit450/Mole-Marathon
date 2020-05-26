using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    private Rigidbody body = new Rigidbody();
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.AddForce(10f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.AddForce(-10f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.AddForce(0f, 10f, 0f);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            body.AddForce(0f, -10f, 0f);
        }
        // body.AddForce(1f, 0f, 0f);
    }
}
