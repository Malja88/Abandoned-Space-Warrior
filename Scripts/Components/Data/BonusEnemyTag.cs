using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BonusEnemyTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour BonusAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new BonusEnemyData());
    }

    public struct BonusEnemyData: IComponentData
    {

    }
}
