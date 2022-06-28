using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CustomControl : MonoBehaviour
{
    public GameObject[] Balls;

    public SelectControl SelectControl;

    public GameObject NEC;

    public GameObject Coins;

    public MainMenu M;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject m in Balls)
        {
            string ballName = m.name;

            PlayerPrefs.SetString("Normal", "Sold");

            if (PlayerPrefs.GetString(ballName) == "Sold")
            {
                GameObject Ball = m;
                Sold(m);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        
        GameObject Ball = EventSystem.current.currentSelectedGameObject;

        string ballName = Ball.name;

        if (Ball.name != "Normal")
        {
            PriceCheck(Ball, ballName);
        }
        else
        {
            Select(Ball, ballName);
        }

        ClickSound();
        
    }

    public void PriceCheck(GameObject Ball, string ballName)
    {
        int coins = PlayerPrefs.GetInt("Coins");

        string costString = Ball.transform.GetChild(1).transform.GetChild(0).GetComponent<Text>().text;
        int costInt = Convert.ToInt32(costString);

        if (PlayerPrefs.GetString(ballName) == "Sold")
        {
            Select(Ball, ballName);
        }
        else
        {
            if (coins < costInt)
            {
                NotEnoughCoins();
            }
            else
            {
                Buy(Ball, ballName, costInt);
            }
        }
    }

    public void NotEnoughCoins()
    {
        NEC.SetActive(true);
    }

    public void Buy(GameObject Ball, string ballName, int costInt)
    {

        Image BallImage = Ball.transform.GetChild(0).gameObject.GetComponent<Image>();
        Image BackgroundImage = Ball.GetComponent<Image>();

            int coins = PlayerPrefs.GetInt("Coins");

            Color BallColor = BallImage.color;
            Color BackgroundColor = BackgroundImage.color;
            GameObject CoinImage = Ball.transform.GetChild(1).gameObject;

            coins -= costInt;

            if (SceneManager.GetActiveScene().name == "CustomBalls")
            {
                BallColor = Color.white;
            }
            
            BackgroundColor.a = 0;

            BallImage.color = BallColor;
            BackgroundImage.color = BackgroundColor;
            CoinImage.SetActive(false);

            Select(Ball, ballName);

            PlayerPrefs.SetInt("Coins", coins);
            PlayerPrefs.SetString(ballName, "Sold");

            Coins.GetComponent<Coins>().CoinsUpdate();
    }

    public void Sold(GameObject Ball)
    {
        Color BallColor = Ball.transform.GetChild(0).gameObject.GetComponent<Image>().color;
        Color BackgroundColor = Ball.GetComponent<Image>().color;
        GameObject CoinImage = Ball.transform.GetChild(1).gameObject;

        if (SceneManager.GetActiveScene().name == "CustomBalls")
        {
            BallColor = Color.white;
        }

        BackgroundColor.a = 0;

        Ball.transform.GetChild(0).gameObject.GetComponent<Image>().color = BallColor;
        Ball.GetComponent<Image>().color = BackgroundColor;
        CoinImage.SetActive(false);
    }

    public void Select(GameObject Ball, string ballName)
    {
        Image BallImage = Ball.transform.GetChild(0).gameObject.GetComponent<Image>();

        Sprite BallSprite = BallImage.sprite;
        string BallSpriteName = BallSprite.name;

        Color BallColor = BallImage.color;

        if (SceneManager.GetActiveScene().name == "CustomBalls")
        {
            PlayerPrefs.SetString("BallSelected", Ball.name);
            PlayerPrefs.SetString("BallSprite", BallSpriteName);
        }
        else if (SceneManager.GetActiveScene().name == "CustomColors")
        {
            PlayerPrefs.SetString("BallColorSelected", Ball.name);
        }

        SelectControl.SelectBox(Ball);
    }

    public void CustomBalls()
    {
        M.CustomBalls();
    }

    public void CustomColors()
    {
        M.CustomColors();
    }

    void ClickSound()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
