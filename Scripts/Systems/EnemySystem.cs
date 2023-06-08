using System.Runtime.CompilerServices;
using Unity.Entities;
using UnityEngine;
using static EnemyTag;

public class EnemySystem : ComponentSystem
{
    private EntityQuery smallEnemy;
    private EndFixedStepSimulationEntityCommandBufferSystem m_CommandBufferSystem;

    protected override void OnCreate()
    {
        m_CommandBufferSystem = World.GetOrCreateSystem<EndFixedStepSimulationEntityCommandBufferSystem>();
        smallEnemy = GetEntityQuery(ComponentType.ReadOnly<EnemyTag>());
    }
    protected override void OnUpdate()
    {
        var commandBuffer = m_CommandBufferSystem.CreateCommandBuffer();
        Entities.With(smallEnemy).ForEach((Entity entity, ref EnemyData tag, EnemyTag enemyTag) =>
        {
            if (tag.EnemyHealth <= 0 && enemyTag.EnemyDeathAction != null && enemyTag.EnemyDeathAction is IAbility ability)
            {
                ability.Execute();
                commandBuffer.DestroyEntity(entity);               
            }
        });
    }
}