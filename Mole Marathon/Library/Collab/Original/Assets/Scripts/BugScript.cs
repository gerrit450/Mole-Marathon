using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugScript : MonoBehaviour
{
    
    Rigidbody bug;
    Vector3 bugPosition;
    Vector3 molePos;
    Vector3 bugDestination;
    GameObject mole;
    Transform moleTransform;
    float distance;
    List<GameObject> bugCount; //creating a list of GameObjects


    void Start()
    {
        bug = gameObject.GetComponent<Rigidbody>();
        bug.useGravity = false;
        bugPosition = new Vector3(10f, -5f, -1f);
        bugDestination = new Vector3(25f, -5f, -1f);
        mole = GameObject.FindGameObjectWithTag("character");
        moleTransform = mole.transform;
        molePos = moleTransform.position;
        bug.drag = 2.5f;
        bugCount = new List<GameObject>();

    }

   
    void Update()
    {
        
        mole = GameObject.FindGameObjectWithTag("character");
        moleTransform = mole.transform;
        molePos = moleTransform.position;
        consumed();

    }

    void consumed()
    {
        bugPosition = Vector3.MoveTowards(transform.position, bugDestination, 0.05f);
        bug.AddForce(transform.right);
        distance = Vector3.Distance(transform.position, molePos);
        

        if (distance < 1.3f)
        {
          gameObject.GetComponent<Renderer>().enabled = false;

        }
        
        
    }

}
