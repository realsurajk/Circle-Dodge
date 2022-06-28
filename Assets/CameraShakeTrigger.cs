using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeTrigger : MonoBehaviour
{

    public CameraShake cameraShake;


    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            cameraShake.Reset();
        }
    }
}
