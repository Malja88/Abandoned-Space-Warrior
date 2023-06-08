using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Stage2TimerSystem : ComponentSystem
{
    private EntityQuery stage2TimerQuery;

    protected override void OnCreate()
    {
        stage2TimerQuery = GetEntityQuery(ComponentType.ReadOnly<Stage2TimerTag>());
    }
    protected override void OnUpdate()
    {
        Entities.With(stage2TimerQuery).ForEach((Entity entity, Stage2TimerTag tag, Stage2TimerAbility stage2Ability) =>
        {
            if (tag.Stage2TimerAction != null && tag.Stage2TimerAction is IAbility ability)
            {
                ability.Execute();
                if (stage2Ability.seconds >= 420)
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
