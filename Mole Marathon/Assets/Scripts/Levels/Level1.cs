using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
<<<<<<< HEAD
using UnityEngine.EventSystems;

public class Level1 : MonoBehaviour, IPointerEnterHandler
{
    private Button click;
    private AudioSource sound = new AudioSource();


    private void Start()
    {
        sound = GameObject.Find("Music").GetComponent<AudioSource>();
        click = GameObject.Find("Level 1").GetComponent<Button>();
        click.onClick.AddListener(mouse);
        
=======

public class Level1 : MonoBehaviour
{
    private Button click;

    private void Start()
    {
        
        click = GameObject.Find("Level 1").GetComponent<Button>();
        click.onClick.AddListener(mouse);

>>>>>>> master
    }

    private void mouse()
    {
        SceneManager.LoadScene("Level 1");
    }

<<<<<<< HEAD
    public void OnPointerEnter(PointerEventData eventData)
    {
        sound.Play();
    }

=======
>>>>>>> master
}
