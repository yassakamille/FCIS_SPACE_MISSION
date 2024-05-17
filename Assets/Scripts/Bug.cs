using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    public float rotatespeed ; 
  

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, rotatespeed);  
    }
}

