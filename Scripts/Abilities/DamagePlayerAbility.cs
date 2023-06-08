using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class DamagePlayerAbility : MonoBehaviour, IAbility
{
    public PlayerHealthData PlayerHealth { private get; set; }
    [SerializeField] public HealthBar healthBar;
    [SerializeField] public int enemyDamage;

    private void Awake()
    {
        healthBar = FindObjectOfType<HealthBar>();
    }
    public void Execute()
    {
        if(PlayerHealth != null)
        {
            StartCoroutine(StartPlayerDamage());
        }
        
    }
    public IEnumerator StartPlayerDamage()
    {
        yield return new WaitForSeconds(0.6f);
        PlayerHealth.currentHealth -= enemyDamage;
        healthBar.SetHealth(PlayerHealth.currentHealth);
        PlayerHealth.hitSparks.Play();
    }
}
