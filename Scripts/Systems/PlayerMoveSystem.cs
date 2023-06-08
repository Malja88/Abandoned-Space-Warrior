using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.UIElements;
using static PlayerSpeedData;
using static UserInputData;

public class PlayerMoveSystem : ComponentSystem
{
    private EntityQuery playerMoveQuery;
    protected override void OnCreate()
    {
        playerMoveQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>(), ComponentType.ReadOnly<PlayerSpeedData>(), ComponentType.ReadOnly<Translation>());
    }
    protected override void OnUpdate()
    {
        Entities.With(playerMoveQuery).ForEach((Entity entity, PlayerSpeedData data, ref InputData inputData, ref Translation translation, ref Rotation rotation) =>
        {
            translation.Value += new float3(inputData.Move.x, 0, inputData.Move.y) * data.playerSpeed * Time.DeltaTime;
            
            var dir = new Vector3(inputData.Move.x, 0, inputData.Move.y);
            if (dir == Vector3.zero) return;

            var playerRotation = rotation.Value;
            var newRotation = Quaternion.LookRotation(Vector3.Normalize(dir));
            if (newRotation == playerRotation) return;
            rotation.Value = Quaternion.Lerp(playerRotation, newRotation, Time.DeltaTime * 12);

            if (Mathf.Abs(inputData.Move.x) > 0 || Mathf.Abs(inputData.Move.y) > 0)
            {
                if(data.stepDust != null)
                {
                    data.stepDust.Play();
                }              
            }
            else
            {
                if(data.stepDust != null)
                {
                    data.stepDust.Stop();
                }              
            }
        });
    }
}
