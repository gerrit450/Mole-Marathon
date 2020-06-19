using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;
using System.Collections.Specialized;

public class CharacterScript : MonoBehaviour
{
    private Rigidbody body = new Rigidbody();
    private float xCoor;
    private float yCoor;
    private bool jump;
    private bool dig;
    private Animator animator;
<<<<<<< Updated upstream
=======
    private AudioSource walking;
    private bool falling;
    private SpriteRenderer spriteRenderer;
>>>>>>> Stashed changes
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        body.useGravity = false;
        body.drag = 1;
        body.angularDrag = 5;
        Physics.gravity = new Vector3(0f, -25f, 0f); //change gravity to the engine
        Time.timeScale = 1f;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        leftFunctionRelease();
        jumpFunctionRelease();
    }

    private void jumpFunction()
    {
        if (transform.position.y == 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                body.AddForce(0f, 900f, 0f);
                body.useGravity = true;
                jump = true;
            }
        }
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
        if (transform.position.y < 0 && Input.GetKey(KeyCode.UpArrow)) // makes object dig upwards as long as up arrow is pressed and underground
        {
            body.AddForce(0f, 30f, 0f);
            dig = true;
        }

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
    }
    private void rightFunction() //moves the object to the right
    {
        if (Input.GetKey(KeyCode.RightArrow)) // right arrow move the object right
        {
            body.AddForce(30f, 0f, 0f);
            animator.SetBool("SpeedKeyRight", true);
<<<<<<< Updated upstream
=======
            spriteRenderer.flipX = false;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
            body.AddForce(-30f, 0f, 0f);
=======
            body.AddForce(-speed-20+speedBoost, 0f, 0f);
            animator.SetBool("SpeedKeyLeft", true);
            spriteRenderer.flipX = true;
        }
    }

    private void leftFunctionRelease()
    {
        if (!Input.GetKey(KeyCode.LeftArrow)) //when the right arrow is released
        {
            animator.SetBool("SpeedKeyLeft", false);
>>>>>>> Stashed changes
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
