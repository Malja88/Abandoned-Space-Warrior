using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBoostPanelFill : MonoBehaviour
{
    [SerializeField] public Slider slider;
    public void SetFill(float currentFill)
    {
        slider.value = currentFill;
    }
}
