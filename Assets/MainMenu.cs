using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject trans;

    Animator transition;

    public GameObject LockedMessage;

    public GameObject PauseCanvas;

    private void Start()
    {

        trans = GameObject.Find("CrossFade");
        if (trans == null)
        {
            return;
        }
        else
        {
            transition = trans.GetComponent<Animator>();
        }

        if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "Hardcore")
        {
            string level = SceneManager.GetActiveScene().name;
            PlayerPrefs.SetString("SavedScene", level);

        }

        
    }

    int currentScene;
    public void Hardcore()
    {
        string level = "Hardcore";
        ClickSound();
        LoadNextLevel(level);
    }

    public void Game()
    {
        string level = "Game";
        ClickSound();
        LoadNextLevel(level);
    }

    public void Settings()
    {
        GetCurrentScene();
        string level = "Settings";
        ClickSound();
        LoadNextLevel(level);

    }

    public void Custom()
    {
        GetCurrentScene();
        string level = "CustomBalls";
        ClickSound();
        LoadNextLevel(level);

    }

    public void About()
    {
        GetCurrentScene();
        string level = "About";
        ClickSound();
        LoadNextLevel(level);

    }

    public void CustomBalls()
    {
        string level = "CustomBalls";
        ClickSound();
        LoadNextLevel(level);
    }

    public void CustomColors()
    {
        string level = "CustomColors";
        ClickSound();
        LoadNextLevel(level);
    }

    public void Locked()
    {
        LockedMessage.SetActive(true);
    }

    public void Back()
    {
        string level = PlayerPrefs.GetString("SavedScene", "Game");
        ClickSound();
        LoadNextLevel(level);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PauseCanvas.SetActive(true);
    }

    public void Play()
    {
        Time.timeScale = 1f;
        PauseCanvas.SetActive(false);
    }

    public void GetCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedScene", currentScene);
    }

    void ClickSound()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void LoadNextLevel(string level)
    {
        StartCoroutine(LoadLevel(level));
    }

    IEnumerator LoadLevel(string level)
    {
        if (transition != null)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(0.5f);
        }
        

        SceneManager.LoadScene(level);


    }
}
