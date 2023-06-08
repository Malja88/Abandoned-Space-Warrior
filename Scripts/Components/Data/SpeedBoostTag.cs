using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpeedBoostTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour SpeedBoostAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new SpeedBoostData()
        {
            
        }) ;
    }

    public struct SpeedBoostData: IComponentData
    {

    }
}
