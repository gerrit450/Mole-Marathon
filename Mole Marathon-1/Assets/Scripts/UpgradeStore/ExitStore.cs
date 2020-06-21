using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitStore : MonoBehaviour
{
    Button exitButton;// Start is called before the first frame update
    void Start()
    {
        exitButton = GameObject.Find("exitStore").GetComponent<Button>();
        exitButton.onClick.AddListener(exit);
    }

    // Update is called once per frame
    void exit()
    {
        SceneManager.LoadScene(CharacterScript.nameOfTheLevel);
    }
}
