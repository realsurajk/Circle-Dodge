using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    private string playStoreID = "3773761";

    public bool isTestAd;

    private GameObject AdButton;

    // Start is called before the first frame update
    void Start()
    {
        InitializeAd();
        AdButton = GameObject.Find("Ad");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeAd()
    {
        Advertisement.Initialize(playStoreID, isTestAd);

    }

    public void Ad()
    {
        if (!Advertisement.IsReady("rewardedVideo"))
        {
            return;
        }
        else
        {
            Advertisement.Show("rewardedVideo");
            CloseButton();
        }
    }

    public void CloseButton()
    {
        AdButton.SetActive(false);
    }
}
