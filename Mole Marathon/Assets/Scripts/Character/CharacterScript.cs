using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    private Rigidbody body = new Rigidbody();
<<<<<<< HEAD
    private BoxCollider colider = new BoxCollider();
=======
>>>>>>> master
    private float xCoor;
    private float yCoor;
    private bool jump;
    private bool dig;
    private Animator animator;
    private AudioSource walking;
    void Start()
    {
        walking = gameObject.GetComponent<AudioSource>();
        body = gameObject.GetComponent<Rigidbody>();
<<<<<<< HEAD
        colider = gameObject.GetComponent<BoxCollider>();
        body.useGravity = true;
        body.drag = 2;
        body.angularDrag = 10;
=======
        body.useGravity = false;
        body.drag = 1;
        body.angularDrag = 5;
>>>>>>> master
        Physics.gravity = new Vector3(0f, -25f, 0f); //change gravity to the engine
        Time.timeScale = 1f;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        jumpFunction();
      //  inventory();
    }

    void FixedUpdate()
    {
        xCoor = transform.position.x;
        yCoor = transform.position.y;
        leftFunction();
        rightFunction();
        diggingFunction();
        inventory();
        rightFunctionRelease();
        jumpFunctionRelease();
    }

    private void jumpFunction()
    {
<<<<<<< HEAD
        if ((transform.position.y >= 0.3f && transform.position.y <= 0.35f) && jump == false)
=======
        if (transform.position.y == 0)
>>>>>>> master
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                body.AddForce(0f, 900f, 0f);
                body.useGravity = true;
                jump = true;
            }
        }
<<<<<<< HEAD
        if (transform.position.y > 0.31f)
        {
            animator.SetBool("SpeedKeyJump", true);
        }
        if(transform.position.y >= 0.3f && transform.position.y <= 0.31f)
        {
            animator.SetBool("SpeedKeyJump", false);
        }

        if(transform.position.y >= 0.3f && transform.position.y < 0.32f)
        {
            jump = false;
        }
        //if ((transform.position.y >= 0 && transform.position.y <= 0.3f) && jump == false)
        //{
        //    jump = true;
        //    body.useGravity = false;
        //    transform.position = new Vector3(xCoor, 0, -1f);
        //    stopObject();
        //}

        if(body.velocity == new Vector3(0f,0f,0f)) //if speed is 0 you can jump (to help jump on the walls)
        {
            if(transform.position.y > 0.4 && Input.GetKeyDown(KeyCode.UpArrow))
            {
                body.AddForce(0f, 700f, 0f);
            }
=======
        if (transform.position.y > 0)
        {
            jump = false;
            animator.SetBool("SpeedKeyJump", true);
        }
        if ((transform.position.y > 0 && transform.position.y <= 0.3f) && jump == false)
        {
            jump = true;
            body.useGravity = false;
            transform.position = new Vector3(xCoor, 0, -1f);
            stopObject();
>>>>>>> master
        }
    }

    private void jumpFunctionRelease()
    {
            if (!Input.GetKeyDown(KeyCode.UpArrow))
            {
                animator.SetBool("SpeedKeyJump", false);
            }
    }
    private void diggingFunction()
    {
<<<<<<< HEAD
        if ((transform.position.y >= 0.3f && transform.position.y <= 0.32f) && Input.GetKey(KeyCode.DownArrow)) // digging downwards as long as below ground and downkey is pressed
        {
            body.useGravity = false;
            body.drag = 3;
            colider.enabled = false;
            body.AddForce(0f, -30f, 0f);
        }
        if(transform.position.y < 0)
        {
            colider.enabled = true;
        }
        if (transform.position.y <= 0.3f && Input.GetKey(KeyCode.UpArrow)) // makes object dig upwards as long as up arrow is pressed and underground
=======
        if (transform.position.y < 0 && Input.GetKey(KeyCode.UpArrow)) // makes object dig upwards as long as up arrow is pressed and underground
>>>>>>> master
        {
            body.AddForce(0f, 30f, 0f);
            dig = true;
        }

<<<<<<< HEAD
        if (transform.position.y <= 0.3f && Input.GetKey(KeyCode.DownArrow)) // makes object dig upwards as long as up arrow is pressed and underground
        {
            body.AddForce(0f, -30f, 0f);
            dig = true;
        }

        if (transform.position.y > 0 && transform.position.y < 0.3f) // if the object is -0.35 from the ground, it will be moved on the ground
        {
            if (Input.GetKey(KeyCode.UpArrow))
                {
                transform.position = new Vector3(xCoor, 0.3f, -1f);
                body.drag = 2;
                // stopObject();
                body.useGravity = true;
                colider.enabled = true;
                dig = false;
                jumpFunction();
                }
        }
        
=======
        if ((transform.position.y > -0.35 && transform.position.y < 0) && dig == true) // if the object is -0.35 from the ground, it will be moved on the ground
        {
            transform.position = new Vector3(xCoor, 0, -1f);
            // stopObject();
            body.useGravity = true;
            dig = false;
            jumpFunction();
        }
        if (transform.position.y <= 0 && Input.GetKey(KeyCode.DownArrow)) // digging downwards as long as below ground and downkey is pressed
        {
            body.AddForce(0f, -30f, 0f);
        }
>>>>>>> master
    }
    private void rightFunction() //moves the object to the right
    {
        if (Input.GetKey(KeyCode.RightArrow)) // right arrow move the object right
        {
<<<<<<< HEAD
            body.AddForce(50f, 0f, 0f);
=======
            body.AddForce(30f, 0f, 0f);
>>>>>>> master
            animator.SetBool("SpeedKeyRight", true);
            
        }
    }

    private void rightFunctionRelease()
    {
        if (!Input.GetKey(KeyCode.RightArrow)) //when the right arrow is released
        {
            animator.SetBool("SpeedKeyRight", false);
        }
    }
    private void leftFunction() //move the object to the left
    {
        if (Input.GetKey(KeyCode.LeftArrow)) //left arrow move the object left
        {
<<<<<<< HEAD
            body.AddForce(-50f, 0f, 0f);
=======
            body.AddForce(-30f, 0f, 0f);
>>>>>>> master
            
        }
    }
    private void stopObject()
    {
        body.isKinematic = true;
        body.isKinematic = false;
    }

    private void inventory()
    {
        if(Input.GetKey(KeyCode.L))
        {
            SceneManager.LoadScene("Character");
        }
    }
}
