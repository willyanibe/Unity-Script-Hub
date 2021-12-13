using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Billboard : MonoBehaviour
{
    void Update() 
    {

    }

     void LateUpdate() {
        Quaternion r1 = Quaternion.LookRotation(transform.position - Camera.main.transform.position, Vector3.up);
        Vector3 euler2 = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(r1.eulerAngles.x, euler2.y, euler2.z);
    }
}