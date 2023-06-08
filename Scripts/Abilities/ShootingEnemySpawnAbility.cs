using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShootingEnemySpawnAbility : MonoBehaviour, IAbility
{
    private Transform playerTransform;
    private PlayerHealthData playerHealthData;
    public GameObject shootingEnemy;
    public Transform spawnPoint;
    public float interval;
    [HideInInspector] public float timer;
    public void Execute()
    {
        ShootingEnemySpawn();
    }

    public void ShootingEnemySpawn()
    {
       var shootingSoldier = Instantiate(shootingEnemy, spawnPoint.position, spawnPoint.localRotation);

       var soldier = shootingSoldier.GetComponent<DamagePlayerAbility>();
       soldier.PlayerHealth = playerHealthData;

       var shootBehaviour = shootingSoldier.GetComponent<ShootBehaviour>();
       shootBehaviour._PlayerTransform = playerTransform;
    }

    [Inject]
    public void Construct(PlayerHealthData playerHealthData, Transform playerTransform)
    {
        this.playerHealthData = playerHealthData;
        this.playerTransform = playerTransform;
    }
}
