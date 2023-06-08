using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField] public Slider slider;
    public void SetAmmo(int currentAmmo)
    {
        slider.value = currentAmmo;
    }
    public void SetMaxAmmo(int currentAmmo)
    {
        slider.maxValue= currentAmmo;
        slider.value= currentAmmo;
    }
}
