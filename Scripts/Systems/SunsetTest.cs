using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunsetTest : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime/7);        
    }
}
