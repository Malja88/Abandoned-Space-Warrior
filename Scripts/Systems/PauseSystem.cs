using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using static PauseTag;

public class PauseSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, PauseTag tag, ref PauseData data) =>
        {
            if (data.Pause > 0 && tag.PauseAction != null && tag.PauseAction is IAbility ability)
            {
                ability.Execute();
            }
        });
    }
}
