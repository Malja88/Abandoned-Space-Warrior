using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using static UserInputData;

public class PlayerReloadSystem : ComponentSystem
{
    private EntityQuery reloadQuery;

    protected override void OnCreate()
    {
        reloadQuery = GetEntityQuery(ComponentType.ReadOnly<ReloadData>(), ComponentType.ReadOnly<InputData>(), ComponentType.ReadOnly<UserInputData>());
    }
    protected override void OnUpdate()
    {
        Entities.With(reloadQuery).ForEach((Entity entity, ref InputData inputData, UserInputData data) =>
        {
            if (inputData.Reload > 0 && data.ReloadAction != null && data.ReloadAction is IAbility ability)
            {
                ability.Execute();
            }
        });
    }
}
