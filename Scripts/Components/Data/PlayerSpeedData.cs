using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerSpeedData : MonoBehaviour, IConvertGameObjectToEntity
{
    public int playerSpeed;
    public ParticleSystem stepDust;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new SpeedData()
       {
            Speed = playerSpeed
       });
    }

    public struct SpeedData: IComponentData
    {
        public int Speed;
    }
}
