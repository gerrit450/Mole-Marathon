using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterScript : MonoBehaviour
{
    public displayPower displayPower;
    public float BoostIsOn = 40f;
    public float jumpBoostIsOn = 10f;
    public float enemiesAreOff = 15f;
    private float verticalForce;
    private static float speed;
    private float speedBoost;
    private Rigidbody body = new Rigidbody();
    private BoxCollider colider = new BoxCollider();
    private float xCoor;
    private float yCoor;
    private bool jump;
    private bool dig;
    private Animator animator;
    private AudioSource walking;
    public FoxScript fox;
    public Falcon falcon;
    public static string nameOfTheLevel;
    private AudioSource jumpSound;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        fox = FindObjectOfType<FoxScript>();
        falcon = FindObjectOfType<Falcon>();
        jumpSound = gameObject.GetComponent<AudioSource>();
        displayPower = FindObjectOfType<displayPower>();
        setSpeed(30f);
        setVerticalForce(900f);
        walking = gameObject.GetComponent<AudioSource>();
        body = gameObject.GetComponent<Rigidbody>();
        colider = GameObject.Find("GroundCollision").GetComponent<BoxCollider>();
        body.useGravity = true;
        body.drag = 2;
        body.angularDrag = 10;
        Physics.gravity = new Vector3(0f, -25f, 0f); //change gravity to the engine
        Time.timeScale = 1f;
        animator = GetComponent<Animator>();
        nameOfTheLevel = SceneManager.GetActiveScene().name;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        jumpFunction();
        speedBoostEnabled();
        jumpBoostEnabled();
        enemiesOffEnabled();
        getSpeed();
        getVerticalForce();
       
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
        if ((transform.position.y >= 0.3f && transform.position.y <= 0.35f) && jump == false)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumpSound.Play();
                body.AddForce(0f, verticalForce, 0f);
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
        

        if(body.velocity == new Vector3(0f,0f,0f)) //if speed is 0 you can jump (to help jump on the walls)
        {
            if(transform.position.y > 0.4 && Input.GetKeyDown(KeyCode.UpArrow))
            {
                body.AddForce(0f, 700f, 0f);
                jumpSound.Play();
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
            colider.enabled = false;
            body.AddForce(0f, -speed, 0f);
            animator.SetBool("SpeedKeyDig", true);
        }
        if (transform.position.y <= 0.3f && Input.GetKey(KeyCode.UpArrow)) // makes object dig upwards as long as up arrow is pressed and underground
        {
            body.AddForce(0f, speed, 0f);
            dig = true;
        }

        if (transform.position.y <= 0.3f && Input.GetKey(KeyCode.DownArrow)) // makes object dig upwards as long as up arrow is pressed and underground
        {
            body.AddForce(0f, -speed, 0f);
            dig = true;
        }

        else if (transform.position.y > 0 && transform.position.y < 0.3f) // if the object is -0.35 from the ground, it will be moved on the ground
        {
                transform.position = new Vector3(xCoor, 0.3f, -1f);
                body.drag = 2;
                body.useGravity = true;
                colider.enabled = true;
                dig = false;
                jumpFunction();
                animator.SetBool("SpeedKeyDig", false);
        }
        
    }
    private void rightFunction() //moves the object to the right
    {
        if (Input.GetKey(KeyCode.RightArrow)) // right arrow move the object right
        {
            body.AddForce(speed+20, 0f, 0f);
            animator.SetBool("SpeedKeyRight", true);
            spriteRenderer.flipX = false;
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
            body.AddForce(-speed-20, 0f, 0f);
            animator.SetBool("SpeedKeyLeft", true);
            spriteRenderer.flipX = true;
        }
    }

    private void leftFunctionRelease()
    {
        if (!Input.GetKey(KeyCode.LeftArrow)) //when the right arrow is released
        {
            animator.SetBool("SpeedKeyLeft", false);
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


    void jumpBoostEnabled()
    {
        if (displayPower.getJumpingBoost() == true)
        {
            setVerticalForce(1500f);
           
            jumpBoostIsOn -= Time.deltaTime;
         
            if (jumpBoostIsOn >= 0f && jumpBoostIsOn <= 2f)
            {
                displayPower.setJumpingBoost(false);
                setVerticalForce(900f);
            }
        }
        else
            setVerticalForce(900f);
    }

    void speedBoostEnabled()
    {
        if (displayPower.getSpeeding() == true)
        {
            setSpeed(90f);  
            BoostIsOn -= Time.deltaTime;
            if (BoostIsOn >= 0f && BoostIsOn <= 2f)
            {
                displayPower.setSpeeding(false);
                setSpeed(30f);
            }
        }
        else
            setSpeed(30f);
    }

    void enemiesOffEnabled()
    {
        if (displayPower.getEnemiesOffBoost() == true)
        {

            fox.GetComponent<Renderer>().enabled = false;
            fox.transform.position = new Vector3(700, 0, 0);
            falcon.GetComponent<Renderer>().enabled = false;
            falcon.transform.position = new Vector3(-600, -600, -600);
            enemiesAreOff -= Time.deltaTime;
           
            if (enemiesAreOff >= 0f && enemiesAreOff <= 2f)
            {
                displayPower.setEnemiesOffBoost(false);
                fox.GetComponent<Renderer>().enabled = true;
                falcon.GetComponent<Renderer>().enabled = true;
                falcon.transform.position = new Vector3(transform.position.x + 5, transform.position.y + 10, -1f);
                fox.transform.position = new Vector3(46.8f, 0f, 0f);
            }
        }
        
            
    }

    public void setVerticalForce(float vf)
    {
        verticalForce = vf;
    }

    public float getVerticalForce()
    {
        return verticalForce;
    }

    public void setSpeed(float boost)
    {
        speed = boost;
    }

    public float getSpeed()
    {
        return speed;
    }
}
