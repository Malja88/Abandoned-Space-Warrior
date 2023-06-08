using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceBoostPanelTimer : MonoBehaviour
{
    [SerializeField] public DefenceBoostPanelFill fill;
    public float currentFill = 10;
    public float maxFill;
    void Update()
    {
        if (maxFill >= 10)
        {
            currentFill -= Time.deltaTime;
            fill.SetFill(currentFill);
        }
        else if (currentFill <= 0)
        {
            maxFill = 0;
            currentFill = 10;
            fill.SetFill(currentFill);
        }

    }
}
