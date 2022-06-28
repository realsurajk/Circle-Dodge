using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{

    AudioManager AudioManager;
    MusicManager MusicManager;

    public GameObject Music;
    public GameObject MusicOff;

    public GameObject Sound;
    public GameObject SoundOff;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        MusicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();

        if (PlayerPrefs.GetFloat("Music", 0.5f) == 0.5f)
        {
            Music.SetActive(true);
            MusicOff.SetActive(false);
        }
        else if (PlayerPrefs.GetFloat("Music", 0.5f) == 0f)
        {
            Music.SetActive(false);
            MusicOff.SetActive(true);
        }

        if (PlayerPrefs.GetFloat("SFX", 0.5f) == 0.5f)
        {
            Sound.SetActive(true);
            SoundOff.SetActive(false);
        }
        else if (PlayerPrefs.GetFloat("SFX", 0.5f) == 0f)
        {
            Sound.SetActive(false);
            SoundOff.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicControl()
    {
        if (PlayerPrefs.GetFloat("Music", 0.5f) == 0.5f) 
        {
            PlayerPrefs.SetFloat("Music", 0f);
            MusicManager.StopMusic("Music");

            Music.SetActive(false);
            MusicOff.SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("Music", 0.5f) == 0f)
        {
            PlayerPrefs.SetFloat("Music", 0.5f);
            MusicManager.PlayMusic("Music");

            Music.SetActive(true);
            MusicOff.SetActive(false);
        }
    }

    public void SFXControl()
    {
        if (PlayerPrefs.GetFloat("SFX", 0.5f) == 0.5f) 
        {
            PlayerPrefs.SetFloat("SFX", 0f);

            Sound.SetActive(false);
            SoundOff.SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("SFX", 0.5f) == 0f)
        {
            PlayerPrefs.SetFloat("SFX", 0.5f);

            Sound.SetActive(true);
            SoundOff.SetActive(false);
        }
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();

        PlayerPrefs.SetFloat("Music", 0.5f);
        MusicManager.PlayMusic("Music");

        Music.SetActive(true);
        MusicOff.SetActive(false);

        PlayerPrefs.SetFloat("SFX", 0.5f);

        Sound.SetActive(true);
        SoundOff.SetActive(false);
    }
}
