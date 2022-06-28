using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotEnoughCoins : MonoBehaviour
{

    public CustomControl Custom;

    public Animator animator;

    // Start is called before the first frame update
    void OnEnable()
    {
        GameObject[] Balls = Custom.Balls;

        foreach (GameObject m in Balls)
        {
            Button ballButton = m.GetComponent<Button>();
            ballButton.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bool m = Input.GetMouseButtonUp(0);

        if (m)
        {
            animator.SetTrigger("mouseup");
            StartCoroutine(Disable());

            m = false;
        }
    }

    IEnumerator Disable()
    {
        yield return new WaitForSecondsRealtime(0.25f);

        GameObject[] Balls = Custom.Balls;

        foreach (GameObject m in Balls)
        {
            Button ballButton = m.GetComponent<Button>();
            ballButton.enabled = true;
        }

        gameObject.SetActive(false);
    }

}
