using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{


    void Update()
    {
        transform.localPosition -= Vector3.forward * Time.deltaTime * 2f;
        
    }

    public void Reset()
    {
        transform.position = new Vector3(0f, 0f, -10.06f);
    }
}
