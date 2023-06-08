using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static UserInputData;

public class FindTargetSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.WithNone<HasTarget>().WithAll<EnemyTag>().ForEach((Entity entity, ref Translation translation) =>
        {
            Entity closestEntity = Entity.Null;
            float3 unitPosition = translation.Value;
            float3 closestTargetPosition = float3.zero;
            Entities.WithAll<UserInputData>().ForEach((Entity targetEntity, ref Translation targetTranslation) =>
            {
                if (closestEntity == Entity.Null)
                {
                    closestEntity = targetEntity;
                    closestTargetPosition = targetTranslation.Value;
                }
                else
                {
                    if (math.distance(unitPosition, targetTranslation.Value) < math.distance(unitPosition, closestTargetPosition))
                    {
                        closestEntity = targetEntity;
                        closestTargetPosition = targetTranslation.Value;
                    }
                }
            });
            if (closestEntity != Entity.Null)
            {
                PostUpdateCommands.AddComponent(entity, new HasTarget { TargetEntity = closestEntity });
            }
        });
    }
}
