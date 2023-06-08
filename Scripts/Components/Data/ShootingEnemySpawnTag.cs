using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class ShootingEnemySpawnTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour ShootingEnemyAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new ShootEnemyData());
    }

    public struct ShootEnemyData: IComponentData
    {

    }
}
