using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;
using static BulletTag;

public class BulletFlySystem : ComponentSystem
{
    private EntityQuery bulletFlyQuery;
    private EntityCommandBuffer _commandBuffer;
    private EndSimulationEntityCommandBufferSystem _commandBufferSystem;
    protected override void OnCreate()
    {
        _commandBufferSystem = World.GetExistingSystem<EndSimulationEntityCommandBufferSystem>();
        bulletFlyQuery = GetEntityQuery(ComponentType.ReadOnly<FlyBulletTag>(), ComponentType.ReadOnly<Transform>());
    }
    protected override void OnUpdate()
    {
        Entities.With(bulletFlyQuery).ForEach((Entity entity, ref PhysicsVelocity velocity, Transform transform, FlyBulletTag tag) =>
        {
            velocity.Linear = transform.forward.normalized * 30;

            _commandBuffer = _commandBufferSystem.CreateCommandBuffer();
            tag.bulletCurrentLife += Time.DeltaTime;
            if(tag.bulletCurrentLife > tag.bulletMaxLife)
            {
                _commandBuffer.DestroyEntity(entity);
                MonoBehaviour.Destroy(transform.gameObject);
            }
        });
    }
}
