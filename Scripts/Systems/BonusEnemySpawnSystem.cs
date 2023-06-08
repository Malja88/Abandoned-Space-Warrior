using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BonusEnemySpawnSystem: ComponentSystem
{
    private EntityQuery bonusEnemy;
    protected override void OnCreate()
    {
        bonusEnemy = GetEntityQuery(ComponentType.ReadOnly<BonusEnemyTag>());
    }
    protected override void OnUpdate()
    {
        Entities.With(bonusEnemy).ForEach((Entity entity, BonusEnemySpawnAbility bonusAbility, BonusEnemyTag tag) =>
        {
            if (tag.BonusAction is IAbility ability && tag.BonusAction != null)
            {
                bonusAbility.timer += Time.DeltaTime;
                if (bonusAbility.timer >= bonusAbility.interval)
                {
                    ability.Execute();
                    bonusAbility.timer -= bonusAbility.interval;
                }
            }
        });
    }
}
