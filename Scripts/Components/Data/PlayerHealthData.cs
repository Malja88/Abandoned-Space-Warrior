using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerHealthData : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour PlayerHealthAction;
    public int currentHealth;
    public ParticleSystem hitSparks;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new HealthData()
        { 
            PlayerHealth = currentHealth
        });
    }

    public struct HealthData: IComponentData
    {
        public int PlayerHealth;
    }
}
