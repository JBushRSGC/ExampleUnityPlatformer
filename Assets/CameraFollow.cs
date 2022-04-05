using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);

        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime);
        
    }
}
