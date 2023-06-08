using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Stage1TimerSystem : ComponentSystem
{
    private EntityQuery stageTimerQuery;

    protected override void OnCreate()
    {
        stageTimerQuery = GetEntityQuery(ComponentType.ReadOnly<Stage1TimerTag>());
    }
    protected override void OnUpdate()
    {
        Entities.With(stageTimerQuery).ForEach((Entity entity, Stage1TimerTag tag, Stage1TimerAbility stageAbility) =>
        {
            if(tag.StageTimerAction!= null && tag.StageTimerAction is IAbility ability)
            {
                ability.Execute();
                if (stageAbility.seconds >= 300)
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
                    Entities.ForEach((Entity entity, Stage1TimerTag tag) =>
                    {
                        EntityManager.DestroyEntity(entity);
                    });
                }
            }
        });
    }

}
