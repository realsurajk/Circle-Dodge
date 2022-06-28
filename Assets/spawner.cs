using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawner : MonoBehaviour
{
    public GameObject[] arcPrefabs;

    public GameObject specialArc;

    public GameObject specialArcHardcore;

    public float spawnRate = 1f;

    private float nextTimeToSpawn = 0f;

    public int k = 1;

    int normalSetting = 100;
    int hardcoreSetting = 25;

    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (k == normalSetting && k != 0 && Time.time >= nextTimeToSpawn)
            {
                if (k == 50)
                {
                    normalSetting += 25;
                }
                else
                {
                    Instantiate(specialArc, Vector3.zero, Quaternion.identity);
                    nextTimeToSpawn = Time.time + 1f / spawnRate;
                    k++;
                }

            }

            else if (Time.time >= nextTimeToSpawn)
            {
                int rand = Random.Range(0, arcPrefabs.Length);
                Instantiate(arcPrefabs[rand], Vector3.zero, Quaternion.identity);
                nextTimeToSpawn = Time.time + 1.5f / spawnRate;
                k++;
            }
        }

        if (SceneManager.GetActiveScene().name == "Hardcore")
        {
            if (k == hardcoreSetting && k != 0 && Time.time >= nextTimeToSpawn)
            {
                if (k == 100)
                {
                    hardcoreSetting += 25;
                }
                else
                {
                    Instantiate(specialArcHardcore, Vector3.zero, Quaternion.identity);
                    nextTimeToSpawn = Time.time + 1f / spawnRate;
                    k++;
                    hardcoreSetting += 25;
                }

            }

            if (Time.time >= nextTimeToSpawn)
            {
                int rand = Random.Range(0, arcPrefabs.Length);
                Instantiate(arcPrefabs[rand], Vector3.zero, Quaternion.identity);
                nextTimeToSpawn = Time.time + 1f / spawnRate;
                k++;
            }
        }


    }
}
