using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoostPanelTimer : MonoBehaviour
{
    [SerializeField] public DamageBoostPanelFill fill;
    public float currentFill = 5;
    public float maxFill;
    void Update()
    {
        if (maxFill >= 5)
        {
            currentFill -= Time.deltaTime;
            fill.SetFill(currentFill);
        }
        else if (currentFill <= 0)
        {
            maxFill = 0;
            currentFill = 5;
            fill.SetFill(currentFill);
        }

    }
}
