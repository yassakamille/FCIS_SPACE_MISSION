using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{

    public Transform target;
   

    public void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
