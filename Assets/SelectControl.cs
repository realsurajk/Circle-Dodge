using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "CustomBalls")
        {
            string BallSelected = PlayerPrefs.GetString("BallSelected", "Normal");
            Vector3 ballPos = GameObject.Find(BallSelected).transform.position;
            this.transform.position = ballPos;
        }
        else if (SceneManager.GetActiveScene().name == "CustomColors")
        {
            string BallSelected = PlayerPrefs.GetString("BallColorSelected", "Normal");
            Vector3 ballPos = GameObject.Find(BallSelected).transform.position;
            this.transform.position = ballPos;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectBox(GameObject Ball)
    {
        Vector3 ballPos = Ball.transform.position;
        this.transform.position = ballPos;
    }
}
