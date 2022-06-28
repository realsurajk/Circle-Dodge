using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestDotScript : MonoBehaviour
{
    public float MovementSpeed = 600f;

    float HorMovement = 0f;
    float VertMovement = 0f;

    // Update is called once per frame
    void Update()
    {
        HorMovement = Input.GetAxisRaw("Horizontal");
        VertMovement = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        transform.Translate(HorMovement, VertMovement, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
