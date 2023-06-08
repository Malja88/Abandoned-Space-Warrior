using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class FlyBulletTag : MonoBehaviour, IConvertGameObjectToEntity
{
    [HideInInspector] public float bulletCurrentLife;
    public float bulletMaxLife;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new BulletFlyData
        { 
            BulletCurrentLife = bulletCurrentLife,
            BulletMaxLife = bulletMaxLife
        });
    }

    public struct BulletFlyData: IComponentData
    {
        public float BulletCurrentLife;
        public float BulletMaxLife;
    }
}
