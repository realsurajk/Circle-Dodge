using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float MovementSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, MovementSpeed * Time.fixedDeltaTime);

        //Quaternion rot = rect.rotation;
        //rot.z++;
        //rect.rotation = rot;
    }
}
