using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoxScript : MonoBehaviour
{
    private Rigidbody body = new Rigidbody();
    private Vector3 position;
    private float areaOfTrigger;
    private int health;
    public Transform target;
    public Text Damage;
    
    
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
        body.useGravity = false;
        areaOfTrigger = 1f;
        health = 3;
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        body.AddForce(-0.5f, 0f, 0f);

        if (target.position.x <= transform.position.x)
        {
            if (target.position.x > transform.position.x - areaOfTrigger)
            {
                if (target.position.y == transform.position.y)
                {
                    healthSystem();
                    StartCoroutine("Pause");
                }
            }
        }
    }

    private void healthSystem()
    {
        health--;

        switch (health)
        {
            case 0:
                Damage.text = "GAME OVER!";
                body.isKinematic = true;
                break;

            case 1:
                Damage.text = "❤";
                break;

            case 2:
                Damage.text = "❤ ❤";
                break;

        }
    }
    IEnumerator Pause()
    {
        enabled = false;

        yield return new WaitForSeconds(1.5f);
        
        enabled = true;

    }

}
