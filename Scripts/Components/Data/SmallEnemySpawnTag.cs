using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Entities;
using UnityEngine;

public class SmallEnemySpawnTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour SmallEnemySpawnAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new SmallEnemySpawnData());
    }

    public struct SmallEnemySpawnData: IComponentData
    {
        
    }
}
