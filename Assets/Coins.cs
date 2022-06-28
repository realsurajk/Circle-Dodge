using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Coins : MonoBehaviour
{

    public Text coinsAmount;

    public ScoreLineScript sc;

    // Start is called before the first frame update
    void Start()
    {
        coinsAmount.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    }

    public void CoinsUpdate()
    {
        coinsAmount.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoins(int score)
    {
        int coins = PlayerPrefs.GetInt("Coins");

        coins += score;
        PlayerPrefs.SetInt("Coins", coins);
    }
}
