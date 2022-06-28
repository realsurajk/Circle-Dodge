using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndScore : MonoBehaviour
{

    public Text Score;
    public Text HighScore;


    // Start is called before the first frame update
    void Start()
    {
        Score.text = PlayerPrefs.GetInt("Score", 0).ToString();
        HighScore.text = PlayerPrefs.GetInt("Score", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
