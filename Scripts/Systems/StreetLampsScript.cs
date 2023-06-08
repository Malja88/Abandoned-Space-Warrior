using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetLampsScript : MonoBehaviour
{
    [SerializeField] Light[] streetLights;
    private float timer;
    private int timeToSwitchOff = 360;
    private int timeToSwitchOn = 100;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeToSwitchOn && timer <= timeToSwitchOff)
        {
            for (int i = 0; i < streetLights.Length; i++)
            {
                streetLights[i].enabled = true;
            }
        }
        else if(timer >= timeToSwitchOff)
        {
            for (int i = 0; i < streetLights.Length; i++)
            {
                streetLights[i].enabled = false;
            }
            timer -= timeToSwitchOff;
        }
    }
}
