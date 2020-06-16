using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using UnityEngine.EventSystems;

public class CharacterButton : MonoBehaviour, IPointerEnterHandler
{
    private Button click;
    private AudioSource sound = new AudioSource();

    private void Start()
    {
        sound = GameObject.Find("MenuClickSound").GetComponent<AudioSource>();
=======

public class CharacterButton : MonoBehaviour
{
    private Button click;

    private void Start()
    {
>>>>>>> master
        click = GameObject.Find("Character Button").GetComponent<Button>();
        click.onClick.AddListener(mouse);
    }

    private void mouse()
    {

    }
<<<<<<< HEAD
    public void OnPointerEnter(PointerEventData eventData)
    {
        sound.Play();
    }
=======
>>>>>>> master
}
