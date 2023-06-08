using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class HealTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour HealAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        if(HealAction!= null && HealAction is IAbility)
        {
            dstManager.AddComponentData(entity, new HealData());
        }
        dstManager.AddComponentData(entity, new HealSpawnData());
    }

    public struct HealData: IComponentData
    {
        
    }

    public struct HealSpawnData: IComponentData
    {

    }
}
