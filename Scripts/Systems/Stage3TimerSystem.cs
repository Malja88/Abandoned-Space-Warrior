using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Stage3TimerSystem : ComponentSystem
{
    private EntityQuery stage3TimerQuery;

    protected override void OnCreate()
    {
        stage3TimerQuery = GetEntityQuery(ComponentType.ReadOnly<Stage3TimerTag>());
    }
    protected override void OnUpdate()
    {
        Entities.With(stage3TimerQuery).ForEach((Entity entity, Stage3TimerTag tag, Stage3TimerAbility stage2Ability) =>
        {
            if (tag.Stage3TimerAction != null && tag.Stage3TimerAction is IAbility ability)
            {
                ability.Execute();
                if (stage2Ability.seconds >= 600)
                {
                    Entities.ForEach((Entity entity, DestroyEnvironmentTag tag) =>
                    {
                        EntityManager.DestroyEntity(entity);
                    });
                    Entities.ForEach((Entity entity, DestroyTag tag) =>
                    {
                        EntityManager.DestroyEntity(entity);
                    });
                    Entities.ForEach((Entity entity, SmallEnemySpawnTag tag) =>
                    {
                        EntityManager.DestroyEntity(entity);
                    });
                    Entities.ForEach((Entity entity, BigEnemySpawnTag tag) =>
                    {
                        EntityManager.DestroyEntity(entity);
                    });
                    Entities.ForEach((Entity entity, BonusEnemyTag tag) =>
                    {
                        EntityManager.DestroyEntity(entity);
                    });
                    Entities.ForEach((Entity entity, Stage2TimerTag tag) =>
                    {
                        EntityManager.DestroyEntity(entity);
                    });
                }
            }
        });
    }
}
