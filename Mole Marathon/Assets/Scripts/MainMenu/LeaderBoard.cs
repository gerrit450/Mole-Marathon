using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using UnityEngine.EventSystems;

public class LeaderBoard : MonoBehaviour, IPointerEnterHandler
{
    private Button click;
    private AudioSource sound = new AudioSource();
=======

public class LeaderBoard : MonoBehaviour
{
    private Button click;
>>>>>>> master

    private void Start()
    {
        click = GameObject.Find("Leaderboard Button").GetComponent<Button>();
<<<<<<< HEAD
        sound = GameObject.Find("MenuClickSound").GetComponent<AudioSource>();
=======
>>>>>>> master
        click.onClick.AddListener(mouse);
    }

    private void mouse()
    {
        SceneManager.LoadScene("Leaderboard");
    }
<<<<<<< HEAD

    public void OnPointerEnter(PointerEventData eventData)
    {
        sound.Play();
    }
=======
>>>>>>> master
}
