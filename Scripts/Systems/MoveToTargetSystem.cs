using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using static UserInputData;
using static EnemyTag;

public class MoveToTargetSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity unitEntity, Transform transform, ref Rotation rotation, ref HasTarget hasTarget, ref Translation translation) =>
        {
            Translation targetTranslation = EntityManager.GetComponentData<Translation>(hasTarget.TargetEntity);
            var enemy = EntityManager.GetComponentData<EnemySpeedData>(unitEntity);

            float3 direction = math.normalize((targetTranslation.Value + new float3(1,0,0)) - translation.Value);
            translation.Value += direction * enemy.EnemySpeed * Time.DeltaTime;

            Quaternion enemyRotation = Quaternion.LookRotation(direction, Vector3.up);
            rotation.Value = enemyRotation;
        });
    }
}
