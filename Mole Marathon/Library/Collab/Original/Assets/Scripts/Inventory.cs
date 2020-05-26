using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int[] Bugs = new int[4];
    public int yellowBugs;
    public int greenBugs;
    public int redBugs;
    public int blueBugs;
    

    // Update is called once per frame
    void Update()
    {
        Bugs[0] = yellowBugs;
        Bugs[1] = redBugs;
        Bugs[2] = blueBugs;
        Bugs[3] = greenBugs;

        print("yellow " + Bugs[0] + " green " + Bugs[1] + " blue " + Bugs[2] + " red " + Bugs[3]);
    }
}
