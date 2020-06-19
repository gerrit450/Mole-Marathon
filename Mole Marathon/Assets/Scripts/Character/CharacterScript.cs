using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    private BoxCollider GroundCollider = new BoxCollider();
    private int speed;
    private int speedBoost;
    private Rigidbody body = new Rigidbody();
    private bool jump;
    private bool dig;
    private Animator animator;
    private AudioSource walking;
    private bool falling;
    void Start()
    {
        GroundCollider = GameObject.Find("GroundCollision").GetComponent<BoxCollider>();
        speed = 30;
        speedBoost = 0;
        walking = gameObject.GetComponent<AudioSource>();
        body = gameObject.GetComponent<Rigidbody>();
        body.useGravity = true;
        body.drag = 2;
        body.angularDrag = 10;
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
        leftFunction();
        rightFunction();
        diggingFunction();
        inventory();
        rightFunctionRelease();
        jumpFunctionRelease();
    }

    private void jumpFunction()
    {
        if ((transform.position.y >= 0.3f && transform.position.y <= 0.35f) && jump == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                body.AddForce(0f, 900f, 0f);
                body.useGravity = true;
                jump = true;
            }
        }
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
        if ((transform.position.y >= 0.3f && transform.position.y <= 0.32f) && Input.GetKey(KeyCode.DownArrow)) // digging downwards as long as below ground and downkey is pressed
        {
            jump = false;
            body.useGravity = false;
            body.drag = 3;
            GroundCollider.enabled = false;
            body.AddForce(0f, -speed, 0f);
        }
        //if(transform.position.y < 0.143f)
        //{
        //    colider.enabled = true;
        //}
        if (transform.position.y <= 0.3f && Input.GetKey(KeyCode.UpArrow)) // makes object dig upwards as long as up arrow is pressed and underground
        {
            body.AddForce(0f, speed+speedBoost, 0f);
            dig = true;
        }

        if (transform.position.y <= 0.3f && Input.GetKey(KeyCode.DownArrow)) // makes object dig upwards as long as up arrow is pressed and underground
        {
            body.AddForce(0f, -speed-speedBoost, 0f);
            dig = true;
        }

        else if (transform.position.y > 0.1 && transform.position.y < 0.3f) // if the object is -0.35 from the ground, it will be moved on the ground
        {
                //transform.position = new Vector3(xCoor, 0.3f, -1f);
                body.drag = 2;
                body.useGravity = true;
                GroundCollider.enabled = true;
                dig = false;
                jumpFunction();
        }
        
    }
    private void rightFunction() //moves the object to the right
    {
        if (Input.GetKey(KeyCode.RightArrow)) // right arrow move the object right
        {
            body.AddForce(speed+20+speedBoost, 0f, 0f);
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
            body.AddForce(-speed-20+speedBoost, 0f, 0f);
            
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

    public void setSpeedBoost(int boost)
    {
        speedBoost = boost;
    }
}
