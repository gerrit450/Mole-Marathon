using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
    private Transform player;
    private FoxScript health = new FoxScript();
    private float AreaOfTrigger = 1;
    private void Start()
    {
        player = GameObject.Find("character").GetComponent<Transform>();
        health = FindObjectOfType<FoxScript>();
    }
    void Update()
    {
        if (player.transform.position.x <= (transform.position.x + AreaOfTrigger) && player.transform.position.x > (transform.position.x - AreaOfTrigger))
        {
            if (player.transform.position.y <= (transform.position.y + AreaOfTrigger) && player.transform.position.y > (transform.position.y - AreaOfTrigger))
            {
                print("lost health!");
                health.healthSystem();
                StartCoroutine("Pause");
            }
        }
    }

    IEnumerator Pause()
    {
        enabled = false;

        yield return new WaitForSeconds(3f);

        enabled = true;

    }
}
