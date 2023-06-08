using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using static UserInputData;

public class PlayerAnimationSystem : ComponentSystem
{
    private EntityQuery playerAnimQuery;

    protected override void OnCreate()
    {
        playerAnimQuery = GetEntityQuery(ComponentType.ReadOnly<AnimationData>(), ComponentType.ReadOnly<Animator>());
    }
    protected override void OnUpdate()
    {
        Entities.With(playerAnimQuery).ForEach((Entity entity, ref InputData data, UserInputData inputData, Animator animator) =>
        {
            if(animator != null)
            {
                animator.SetBool(inputData.moveAnimHash, Mathf.Abs(data.Move.x) > 0.01f || Mathf.Abs(data.Move.y) > 0.01f);
            }
            
            if (data.Shoot > 0 && animator != null)
            {
                animator.SetBool(inputData.shootInputHash, true);
            }
            else if (data.Shoot <= 0 && animator != null)
            {
                animator.SetBool(inputData.shootInputHash, false);
            }
        });
    }
}
