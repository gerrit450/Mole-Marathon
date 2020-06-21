﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class Level8 : MonoBehaviour, IPointerEnterHandler
{
    private Button click;
    private AudioSource sound = new AudioSource();


    private void Start()
    {
        sound = GameObject.Find("Music").GetComponent<AudioSource>();
        //click = GameObject.Find("Level 8").GetComponent<Button>();
        //click.onClick.AddListener(mouse);

    }

    private void mouse()
    {
        SceneManager.LoadScene("Level 8");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sound.Play();
    }
}
