using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using UnityEngine.EventSystems;

public class QuitButton : MonoBehaviour, IPointerEnterHandler
{
    private Button click;
    private AudioSource sound = new AudioSource();

    private void Start()
    {
        sound = GameObject.Find("MenuClickSound").GetComponent<AudioSource>();
=======

public class QuitButton : MonoBehaviour
{
    private Button click;

    private void Start()
    {
>>>>>>> master
        click = GameObject.Find("Quit Button").GetComponent<Button>();
        click.onClick.AddListener(mouse);
    }

    private void mouse()
    {
        Application.Quit(0);
    }
<<<<<<< HEAD
    public void OnPointerEnter(PointerEventData eventData)
    {
        sound.Play();
    }
=======
>>>>>>> master
}
