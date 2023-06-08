using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletFlyAbility : MonoBehaviour, IAbility
{
    public PhysicsVelocity body;
    public float speed;
    public float2 flyDirection;
    public float3 direction;
    private void Start()
    {
        direction = new float3(flyDirection.x, 0, flyDirection.y);
    }
    public void Execute()
    {
       
    }

}
