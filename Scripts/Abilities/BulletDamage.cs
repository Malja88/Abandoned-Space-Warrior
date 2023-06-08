using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour, IAbility
{
    [HideInInspector] public PlayerHealthData playerHealth;
    [HideInInspector] public HealthBar healthBar;
    [SerializeField] public int bulletDamage;
    public void Execute()
    {
        playerHealth.hitSparks.Play();
        playerHealth.currentHealth -= bulletDamage;
        healthBar.SetHealth(playerHealth.currentHealth);
        if(gameObject !=null)
        {
            Destroy(gameObject);
        }       
    }

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealthData>();
        healthBar = FindObjectOfType<HealthBar>();
    }

}
