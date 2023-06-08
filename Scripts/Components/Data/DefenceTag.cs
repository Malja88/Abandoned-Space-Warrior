using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class DefenceTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour DefenceAction;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new DefenceData());
    }

    public struct DefenceData: IComponentData
    {

    }
}
