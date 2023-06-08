using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    [SerializeField] StudioEventEmitter buttonSfx;

    public void ButtonPress()
    {
        buttonSfx.Play();
    }
}
