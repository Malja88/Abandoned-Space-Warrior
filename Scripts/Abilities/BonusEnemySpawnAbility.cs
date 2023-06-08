using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEnemySpawnAbility : MonoBehaviour, IAbility
{
    public GameObject bonusEnemy;
    public Transform spawnPoint;
    public float interval;
    [HideInInspector] public float timer;

    public void Execute()
    {
        SpawnBonusEnemy();
    }

    public void SpawnBonusEnemy()
    {
        Instantiate(bonusEnemy, spawnPoint.position, spawnPoint.rotation);
    }
}
