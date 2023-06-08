using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class BulletTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour DamagePlayerAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new BulletData()) ;
    }

    public struct BulletData: IComponentData
    {
        
    }
}
