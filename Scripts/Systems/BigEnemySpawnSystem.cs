using Unity.Entities;
using UnityEngine;

public class BigEnemySpawnSystem : ComponentSystem
{
    private EntityQuery bigEnemySpawn;

    protected override void OnCreate()
    {
        bigEnemySpawn = GetEntityQuery(ComponentType.ReadOnly<BigEnemySpawnTag>());
    }
    protected override void OnUpdate()
    {
        Entities.With(bigEnemySpawn).ForEach((Entity entity, BigEnemySpawnTag tag, BigEnemySpawnAbility spawnAbility) =>
        {
            if (tag.BigEnemySpawnAction is IAbility ability && tag.BigEnemySpawnAction != null)
            {
                spawnAbility.timer += Time.DeltaTime;
                if (spawnAbility.timer >= spawnAbility.interval)
                {
                    ability.Execute();
                    spawnAbility.timer -= spawnAbility.interval;
                }
            }

        });
    }
}
