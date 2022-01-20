using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject deathWindow;
    [SerializeField] private AudioSource click;
    public GameObject textMessage;
    public GameObject settingsWindow;
    public static bool ng;

    private void Start()
    {
        Time.timeScale = 1;
        if (ng)
        {
            Time.timeScale = 0;
            textMessage.SetActive(true);
        }
        
    }
    
    private void Update()
    {
        if (deathWindow.activeSelf == true && (Input.GetKeyUp(KeyCode.KeypadEnter)|| Input.GetKeyUp(KeyCode.Return))) { ResetLvl(); }
        if (Input.GetButtonUp("Cancel"))
        {

            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    public void Back()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Click()
    {
        click.Play();
    }
    public void ResetLvl()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene((SceneManager.GetActiveScene()).buildIndex);
    }
    public void NextLvl()
    {
        ng = true;
        Time.timeScale = 1;
        SceneManager.LoadScene((SceneManager.GetActiveScene()).buildIndex + 1);
    }
    public void CloseWindow()
    {
        textMessage.SetActive(false);
        Time.timeScale = 1;
        ng = false;
    }
    public void OpenSettings()
    {
        settingsWindow.SetActive(true);
    }
    public void CloseSettings()
    {
        settingsWindow.SetActive(false);
    }
}
