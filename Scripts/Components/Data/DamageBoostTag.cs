using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.VisualScripting;
using UnityEngine;

public class DamageBoostTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour DamageBoostAction;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new DamageBoost());
    }

    public struct DamageBoost: IComponentData
    {

    }
}
