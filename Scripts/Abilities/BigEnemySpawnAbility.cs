using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BigEnemySpawnAbility : MonoBehaviour, IAbility
{
    private PlayerHealthData playerHealthData;
    private Transform playerTransform;
    public GameObject bigEnemy;
    public Transform spawnPoint;
    public float interval;
    [HideInInspector] public float timer;
    public void Execute()
    {
        BigEnemySpawn();
    }

    public void BigEnemySpawn()
    {
        var bigEnemySpawn = Instantiate(bigEnemy, spawnPoint.position, spawnPoint.localRotation);

        var bigEnemyObject = bigEnemySpawn.GetComponent<DamagePlayerAbility>();
        bigEnemyObject.PlayerHealth = playerHealthData;

        var attackBehavior = bigEnemySpawn.GetComponent<AttackBehaviour>();
        attackBehavior.PlayerTransform= playerTransform;
    }

    [Inject]
    public void Construct(PlayerHealthData playerHealthData, Transform playerTransform)
    {
        this.playerHealthData = playerHealthData;
        this.playerTransform = playerTransform;
    }
}
