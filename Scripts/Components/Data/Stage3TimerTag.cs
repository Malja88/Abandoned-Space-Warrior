using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Stage3TimerTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour Stage3TimerAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Stage3TimerData());
    }

    public struct Stage3TimerData : IComponentData
    {

    }
}
