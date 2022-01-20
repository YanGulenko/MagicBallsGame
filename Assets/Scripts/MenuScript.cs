using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject MenueScreen;
    private GameObject currentScreen;
    public AudioSource click;
    public AudioSource gt;
    public static float sl1 = 1;
    public static float sl2 = 1;


    private void Start()
    {
        gt.Play();
        MenueScreen.SetActive(true);
        currentScreen = MenueScreen;
    }

    public void ChangeScreen(GameObject screen)
    {

        if (currentScreen != null)
        {
            currentScreen.SetActive(false);
            screen.SetActive(true);
            currentScreen = screen;
        }

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Click()
    {
        click.Play();
    }
    public void ChooseLvl(int index)
    {
        
        SceneManager.LoadScene(index);
        PauseScript.ng = true;
    }
}
