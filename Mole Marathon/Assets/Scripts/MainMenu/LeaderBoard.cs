using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LeaderBoard : MonoBehaviour, IPointerEnterHandler
{
    private Button click;
    private AudioSource sound = new AudioSource();

    private void Start()
    {
        click = GameObject.Find("Leaderboard Button").GetComponent<Button>();
        sound = GameObject.Find("MenuClickSound").GetComponent<AudioSource>();
        click.onClick.AddListener(mouse);
    }

    private void mouse()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sound.Play();
    }
}
