using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class EvaluateSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, BehaviorManager manager) =>
        {
            float highScore = float.MinValue;
            manager.activeBehavior = null;
            foreach (var behavior in manager.behaviours)
            {
                if (behavior is IBehavior ai)
                {
                    var currentScore = ai.Evaluate();                  
                   if (currentScore > highScore)
                   {
                     highScore = currentScore;
                     manager.activeBehavior = ai;
                   }                  
                }
            }
        });
    }
}
