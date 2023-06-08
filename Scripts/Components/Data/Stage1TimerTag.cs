using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class Stage1TimerTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour StageTimerAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new Stage1TimerData());
    }

    public struct Stage1TimerData: IComponentData
    {

    }
}
