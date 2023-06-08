using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class HealingAbility : MonoBehaviour, IAbility
{
    [HideInInspector] public PlayerHealthData playerHealth;
    [SerializeField] public HealthBar healthBar;
    [HideInInspector] public int healingPoints = 10;
    [SerializeField] public ParticleSystem particle;
    [SerializeField] public StudioEventEmitter pickUpSFX;
    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealthData>();
        healthBar = FindObjectOfType<HealthBar>();
    }
    public void Execute()
    {
        pickUpSFX.Play();
        if (playerHealth.currentHealth < 1000 && playerHealth.currentHealth <= 900)
        {
            playerHealth.currentHealth += healingPoints/10;
        }      
        healthBar.SetHealth(playerHealth.currentHealth);
        Destroy(gameObject);
        Destroy(particle);
    }
}
