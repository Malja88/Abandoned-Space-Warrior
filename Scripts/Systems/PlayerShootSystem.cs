using Unity.Entities;
using Unity.Physics.Systems;
using Unity.Physics;
using UnityEngine;
using static UserInputData;
using TMG.UnitSelection;
using Unity.Mathematics;

public partial class PlayerShootSystem : SystemBase
{
    private BuildPhysicsWorld _physicsWorld;
    private CollisionWorld _collisionWorld;
    protected override void OnCreate()
    {
        _physicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
    }
    protected override void OnUpdate()
    {
        Entities.ForEach((Entity entity, PlayerShootData data, UserInputData userData, ref InputData inputData) =>
        {
            if (inputData.Shoot > 0 && data.shootDelay <= 0.3f && userData.ShootAction != null && userData.ShootAction is IAbility ability && (Mathf.Abs(inputData.Move.x) > 0 || Mathf.Abs(inputData.Move.y) > 0))
            {
                ability.Execute();
                ShootAbility(out var hit, data);
                if (hit.Entity != Entity.Null)
                {
                    var enemy = EntityManager.GetComponentData<EnemyTag.EnemyData>(hit.Entity);
                    enemy.EnemyHealth -= data.damage;
                    EntityManager.SetComponentData(hit.Entity, enemy);

                }
            }
        }).WithoutBurst().Run();
    }
    private void ShootAbility(out Unity.Physics.RaycastHit hit, PlayerShootData data)
    {
        _collisionWorld = _physicsWorld.PhysicsWorld.CollisionWorld;
        var ray = data.firePoint.position;
        var rayStart = ray;
        var rayEnd = data.firePoint.forward.normalized * 800;
        RaycastAll(rayStart, rayEnd, out hit);
    }
    private void RaycastAll(float3 rayStart, float3 rayEnd, out Unity.Physics.RaycastHit hit)
    {
        var raycastInput = new RaycastInput
        {
            Start = rayStart,
            End = rayEnd,
            Filter = new CollisionFilter
            {
                BelongsTo = (uint)CollisionLayers.RayShoot,
                CollidesWith = (uint)(CollisionLayers.Enemy)
            }
        };

        _collisionWorld.CastRay(raycastInput, out hit);
    }
}
