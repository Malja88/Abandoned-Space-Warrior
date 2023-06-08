using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Zenject;

public class SmallEnemySpawnAbility : MonoBehaviour, IAbility
{
    private PlayerHealthData playerHealthData;
    private Transform playerTransform;
    public GameObject smallEnemy;
    public Transform spawnPoint;
    public float interval;
    [HideInInspector] public float timer;
    public void Execute()
    {
        SmallEnemySpawn();
    }

    public void SmallEnemySpawn()
    {
        var smallEnemySpawn = Instantiate(smallEnemy, spawnPoint.position, spawnPoint.localRotation);
        var smallEnemyObject = smallEnemySpawn.GetComponent<DamagePlayerAbility>();
        smallEnemyObject.PlayerHealth = playerHealthData;

        var attackBehaviour = smallEnemySpawn.GetComponent<AttackBehaviour>();
        attackBehaviour.PlayerTransform = playerTransform;
    }

    [Inject]
    public void Construct(PlayerHealthData playerHealthData, Transform playerTransform)
    {
        this.playerHealthData = playerHealthData;
        this.playerTransform = playerTransform;
    }
}
