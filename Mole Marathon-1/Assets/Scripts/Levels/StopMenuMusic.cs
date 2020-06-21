using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMenuMusic : MonoBehaviour
{
    void Start()
    {
        GameObject.Find("MenuMusic").GetComponent<MusicScript>().Destroy();
    }
}
