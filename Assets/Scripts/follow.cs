using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class follow : MonoBehaviour
{
    public Transform targetObj;
    public int speed = 8;
    // Start is called before the first fraæ update
  
void Update() {
        transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, speed * Time.deltaTime);
        }
}
