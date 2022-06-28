using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hardcoreUnlock : MonoBehaviour
{

    public GameObject lockedHardcore;
    public GameObject unlockedHardcore;

    void Start()
    {

        int highScore = PlayerPrefs.GetInt("HighScore");
        
        if (highScore < 25)
        {
            lockedHardcore.SetActive(true);
            unlockedHardcore.SetActive(false);
        }
        else
        {
            lockedHardcore.SetActive(false);
            unlockedHardcore.SetActive(true);
        }
        
    }
}
