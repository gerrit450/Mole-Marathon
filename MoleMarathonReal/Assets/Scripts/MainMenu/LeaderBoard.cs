﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderBoard : MonoBehaviour
{
    private Button click;

    private void Start()
    {
        click = GameObject.Find("Leaderboard Button").GetComponent<Button>();
        click.onClick.AddListener(mouse);
    }

    private void mouse()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}
