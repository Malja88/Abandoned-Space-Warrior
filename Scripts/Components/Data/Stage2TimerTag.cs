using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Stage2TimerTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour Stage2TimerAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Stage2TimerData());
    }

    public struct Stage2TimerData : IComponentData
    {

    }
}
