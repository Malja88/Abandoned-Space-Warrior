using Unity.Entities;
using UnityEngine;

public class SmallEnemySpawnSystem : ComponentSystem
{
    private EntityQuery smallEnemySpawn;

    protected override void OnCreate()
    {
        smallEnemySpawn = GetEntityQuery(ComponentType.ReadOnly<SmallEnemySpawnTag>());
    }
    protected override void OnUpdate()
    {
        Entities.With(smallEnemySpawn).ForEach((Entity entity, SmallEnemySpawnTag tag, SmallEnemySpawnAbility spawnAbility) =>
        {
            if(tag.SmallEnemySpawnAction is IAbility ability && tag.SmallEnemySpawnAction != null)
            {
                spawnAbility.timer += Time.DeltaTime;
                if(spawnAbility.timer >= spawnAbility.interval)
                {
                    ability.Execute();
                    spawnAbility.timer -= spawnAbility.interval;
                }
            }
            
        });
    }
}
