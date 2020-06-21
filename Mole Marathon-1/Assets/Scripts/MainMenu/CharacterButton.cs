using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CharacterButton : MonoBehaviour, IPointerEnterHandler
{
    private Button click;
    private AudioSource sound = new AudioSource();

    private void Start()
    {
        sound = GameObject.Find("MenuClickSound").GetComponent<AudioSource>();
        click = GameObject.Find("Inventory Button").GetComponent<Button>();
        click.onClick.AddListener(mouse);
    }

    private void mouse()
    {
        SceneManager.LoadScene("Character");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        sound.Play();
    }
}
