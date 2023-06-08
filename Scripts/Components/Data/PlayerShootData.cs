using FMODUnity;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootData : MonoBehaviour, IAbility
{
    [Header("Transform Info")]
    public Transform firePoint;

    [Header("Variables")]
    public float shootDelay;
    public int maxAmmo;
    private float shootTime = float.MinValue;
    [HideInInspector] public int currentAmmo;
    public int damage;

    [Header("Particles")]
    [SerializeField] public ParticleSystem laser;
    [SerializeField] public ParticleSystem glow;

    [Header("Fill Bar")]
    [SerializeField] public AmmoBar ammoBar;

    [Header("Audio")]
    [SerializeField] public StudioEventEmitter shootSFX;

    private void Start()
    {
        currentAmmo = maxAmmo;
        ammoBar.SetMaxAmmo(maxAmmo);
    }
    public void Execute()
    {
        if (Time.time < shootDelay + shootTime) return;
        {
            Shoot();
            if (currentAmmo <= 0)
            {
                shootDelay = 1000;
            }
        }
        shootTime = Time.time;
    }
    public void Shoot()
    {
        glow.Play();
        shootSFX.Play();
        currentAmmo--;
        ammoBar.SetAmmo(currentAmmo);
        laser.Play();
    }
}
