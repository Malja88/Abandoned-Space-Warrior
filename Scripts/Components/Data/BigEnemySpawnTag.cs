using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BigEnemySpawnTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour BigEnemySpawnAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new BigEnemyData());
    }

    public struct BigEnemyData: IComponentData
    {

    }
}
