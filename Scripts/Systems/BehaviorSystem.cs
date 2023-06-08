using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BehaviorSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, BehaviorManager manager) =>
        {
            if(manager.activeBehavior != null)
            {
                manager.activeBehavior.Behave();
            }
        });
    }
}
