using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerDeathSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity playerEntity, PlayerHealthData data) =>
        {
            if (data.PlayerHealthAction != null && data.PlayerHealthAction is IAbility ability && data.currentHealth <= 0)
            {
                ability.Execute();
                Entities.ForEach((Entity entity, DestroyTag tag) =>
                {
                    EntityManager.DestroyEntity(entity);
                });
            }
        });
    }
}
