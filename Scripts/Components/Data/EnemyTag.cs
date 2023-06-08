using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Entities;
using UnityEngine;
using Zenject;

public class EnemyTag : MonoBehaviour, IConvertGameObjectToEntity
{
    public MonoBehaviour EnemyDeathAction;
    public MonoBehaviour PlayerDamageAction;
    public int enemyHealth;
    public float enemySpeed;
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        dstManager.AddComponentData(entity, new EnemyData()
        {
            EnemyHealth = enemyHealth
        }); ;
        dstManager.AddComponentData(entity, new EnemySpeedData()
        {
            EnemySpeed = enemySpeed
        });
    }
    public struct EnemyData: IComponentData
    {
        public int EnemyHealth;
    }

    public struct EnemySpeedData: IComponentData
    {
        public float EnemySpeed;
    }
}