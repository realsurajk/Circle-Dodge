using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DotScript : MonoBehaviour
{
    public float MovementSpeed = 400f;

    float DotMovement = 0f;

    public GameObject spawner;
    public GameObject score;
    public GameObject tapany;

    public SpriteRenderer dotSprite;

    public CircleCollider2D dotCollider;
    public CircleCollider2D scoreCollider;

    public ParticleSystem particle;

    public ScoreLineScript sc;

    public GameObject hsText;
    public GameObject hsScore;
    public GameObject UI;
    public GameObject Pause;

    public Material special;
    public Material specialHardcore;
    public Material def;

    public GameObject ins;

    public bool k = false;

    bool control = true;

    bool InsControl = true;

    bool AllowMovement = false;

    bool AllowRotation = true;

    float GameStartTime;

    private void Start()
    {
        string BallSpriteName = PlayerPrefs.GetString("BallSprite", "Dot");
        dotSprite.sprite = Resources.Load<Sprite>(BallSpriteName);

        string BallMatName = PlayerPrefs.GetString("BallColorSelected", "Normal");
        dotSprite.material = Resources.Load<Material>(BallMatName);

        GameStartTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {

        int i = 0;

        if (AllowRotation == true)
        {
        transform.Rotate(Vector3.forward, MovementSpeed * Time.fixedDeltaTime);

        }

        if (k == false && Time.time > 1f + GameStartTime)
        {
            if (Input.touchCount > 0 && Input.GetTouch(i).position.y < Screen.height * 0.8f && Input.GetTouch(i).position.y > Screen.height * 0.15f)
            {
                spawner.SetActive(true);
                hsText.SetActive(false);
                hsScore.SetActive(false);
                UI.SetActive(false);
                Pause.SetActive(true);
                AllowMovement = true;

                if (SceneManager.GetActiveScene().name == "Hardcore")
                {
                    GameObject.Find("Main Camera").GetComponent<CameraRotate>().enabled = true;
                }
                else if (InsControl)
                {
                    ins.SetActive(true);
                    StartCoroutine(DisableInstructions());
                    InsControl = false;
                }
            }
        }

        if (AllowMovement)
        {
            if (control)
            {
                while (i < Input.touchCount)
                {
                    if (Input.GetTouch(i).position.y < Screen.height * 0.9f || Input.GetTouch(i).position.x < Screen.width * 0.8f)
                    {
                        if (Input.GetTouch(i).position.x > Screen.width / 2)
                        {
                            DotMovement = 1f;
                        }

                        if (Input.GetTouch(i).position.x < Screen.width / 2)
                        {
                            DotMovement = -1f;
                        }
                        i++;
                    }
                    else
                    {
                        DotMovement = 0f;
                        i++;
                    }
                        
                }
            }
            else
            {
                while (i < Input.touchCount)
                {
                    if (Input.GetTouch(i).position.x > Screen.width / 2)
                    {
                        DotMovement = -1f;
                    }

                    if (Input.GetTouch(i).position.x < Screen.width / 2)
                    {
                        DotMovement = 1f;
                    }
                    i++;
                }
            }

            
        }

        if (Input.touchCount == 0)
        {
            DotMovement = 0f;
        }
    }
    private void FixedUpdate()
    {
        if (k == false)
        {

            transform.RotateAround(Vector3.zero, Vector3.forward, DotMovement * Time.fixedDeltaTime * -MovementSpeed);
            transform.Rotate(Vector3.forward, DotMovement * Time.fixedDeltaTime * MovementSpeed);
            
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.gameObject.name == "SpecialCollider")
        {
            if (control)
            {
                control = false;

                if (SceneManager.GetActiveScene().name == "Game")
                {
                    this.GetComponent<SpriteRenderer>().material = special;
                }
                else if (SceneManager.GetActiveScene().name == "Hardcore")
                {
                    this.GetComponent<SpriteRenderer>().material = specialHardcore;
                }
                
                FindObjectOfType<AudioManager>().Play("SpecialOn");
            }
            else
            {
                control = true;
                this.GetComponent<SpriteRenderer>().material = def;
                FindObjectOfType<AudioManager>().Play("SpecialOff");
            }
            
        }
        else
        {
            spawner.SetActive(false);

            k = true;

            scoreCollider.enabled = false;
            dotSprite.enabled = false;
            dotCollider.enabled = false;
            AllowMovement = false;
            AllowRotation = false;

            FindObjectOfType<AudioManager>().Play("Death");

            particle.Play();

            GameObject.Find("Main Camera").GetComponent<CameraShake>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<CameraShakeTrigger>().enabled = false;

            sc.HighScore();

            StartCoroutine(LoadLevel());
        }      
    }


    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator DisableInstructions()
    {
        yield return new WaitForSeconds(3f);
        ins.SetActive(false);
    }
}
