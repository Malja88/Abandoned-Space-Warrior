using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PauseTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour PauseAction;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new PauseData());
    }

    public struct PauseData: IComponentData
    {
        public float Pause;
    }
}
