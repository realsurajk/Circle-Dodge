using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArcScript : MonoBehaviour
{

    public Rigidbody2D rb;

    float shrinkSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb.rotation = Random.Range(0f, 360f);
        transform.localScale = Vector3.one * 7f;
        if (SceneManager.GetActiveScene().name == "Hardcore")
        {
            shrinkSpeed = 2f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;

        if (transform.localScale.x <= 0.05f)
        {
            Destroy(gameObject);
        }

        if (GameObject.Find("Dot").GetComponent<DotScript>().k == true)
        {
            Time.timeScale = 0.5f;
        }
    }
}
