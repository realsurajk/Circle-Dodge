using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreLineScript : MonoBehaviour
{

    public Text score;
    public Text highScore;
    public GameObject HScore;

    public int k = 0;
    public int s = 0;

    public CameraRotate cr;
    public CameraShake cs;
    public CameraShakeTrigger cst;

    public Coins co;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        }

        if (SceneManager.GetActiveScene().name == "Hardcore")
        {
            highScore.text = PlayerPrefs.GetInt("HighScoreHardcore", 0).ToString();
        }
    }

    public void HighScore()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (k > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", k);
                highScore.text = k.ToString();
                FindObjectOfType<AudioManager>().Play("HighScore");
                HScore.SetActive(true);
            }

            PlayerPrefs.SetInt("Score", k);

            co.AddCoins(k);
        }

        if (SceneManager.GetActiveScene().name == "Hardcore")
        {
            if (s > PlayerPrefs.GetInt("HighScoreHardcore", 0))
            {
                PlayerPrefs.SetInt("HighScoreHardcore", s);
                highScore.text = s.ToString();
                FindObjectOfType<AudioManager>().Play("HighScore");
                HScore.SetActive(true);
            }

            PlayerPrefs.SetInt("Score", s);

            co.AddCoins(s);
        }
    }

    public void Coins()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (collisionInfo.gameObject.name == "Collider" || collisionInfo.gameObject.name == "SpecialCollider")
            {
                k++;
                score.text = (k.ToString("0"));
            }
        }

        if (SceneManager.GetActiveScene().name == "Hardcore")
        {
            if (collisionInfo.gameObject.name == "Collider" || collisionInfo.gameObject.name == "SpecialCollider")
            {
                s++;
                score.text = (s.ToString("0"));
            }
        }

    }

    private void Update()
    {


        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (k == 50)
            {
                cr.enabled = true;
            }
            if (k == 100)
            {
                cs.enabled = true;
                cst.enabled = true;
            }
        }

        if (SceneManager.GetActiveScene().name == "Hardcore")
        {
            if (s == 50)
            {
                cs.enabled = true;
                cst.enabled = true;
            }
        }


    }
}
