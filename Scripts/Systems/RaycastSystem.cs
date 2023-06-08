//using TMG.UnitSelection;
//using Unity.Entities;
//using Unity.Mathematics;
//using Unity.Physics;
//using Unity.Physics.Systems;
//using Unity.Transforms;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.XR;
//using static UserInputData;
//using RaycastHit = Unity.Physics.RaycastHit;

//public class RaycastSystem : ComponentSystem
//{
//    private BuildPhysicsWorld _physicsWorld;
//    private CollisionWorld _collisionWorld;
//    protected override void OnCreate()
//    {
//        _physicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
//    }

//    protected override void OnUpdate()
//    {
//        Entities.ForEach((Entity entity, Transform transform, ref RotationData rotationData, ref Rotation rotation, ref Translation translation) =>
//        {
//            CanRotate(out var hit);
//            var direction = hit.Position - translation.Value;
//            var rot = Quaternion.LookRotation(direction);
//            rotation.Value = new Quaternion(0, rot.y, 0, rot.w).normalized;
//        });
//    }

//    private void CanRotate(out RaycastHit hit)
//    {
//        _collisionWorld = _physicsWorld.PhysicsWorld.CollisionWorld;
//        var mousePosition = Input.mousePosition;
//        var ray = Camera.main.ScreenPointToRay(mousePosition);
//        var rayStart = ray.origin;
//        var rayEnd = ray.GetPoint(100);
//        Raycast(rayStart, rayEnd, out hit);

//    }

//    private void Raycast(float3 rayStart, float3 rayEnd, out RaycastHit hit)
//    {
//        var raycastInput = new RaycastInput
//        {
//            Start = rayStart,
//            End = rayEnd,
//            Filter = new CollisionFilter
//            {
//                BelongsTo = (uint) CollisionLayers.Ray,
//                CollidesWith = (uint) CollisionLayers.Floor
//            }
//        };

//        _collisionWorld.CastRay(raycastInput, out hit);
//    }
//}
