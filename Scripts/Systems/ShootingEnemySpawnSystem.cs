using Unity.Entities;
using UnityEngine;

public class ShootingEnemySpawnSystem : ComponentSystem
{
    private EntityQuery shootingEnemySpawn;

    protected override void OnCreate()
    {
        shootingEnemySpawn = GetEntityQuery(ComponentType.ReadOnly<ShootingEnemySpawnTag>());
    }
    protected override void OnUpdate()
    {
        Entities.With(shootingEnemySpawn).ForEach((Entity entity, ShootingEnemySpawnTag tag, ShootingEnemySpawnAbility spawnAbility) =>
        {
            if (tag.ShootingEnemyAction is IAbility ability && tag.ShootingEnemyAction != null)
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
