using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootBehaviour : MonoBehaviour, IBehavior
{
    //public PlayerHealthData player;
    public GameObject bullet;
    public Transform firePoint;
    private bool _isAttaking;
    public float shootDelay;
    private float shootTime = float.MinValue;
    public Transform _PlayerTransform { private get; set; }
    [SerializeField] private float _attackDistance;
    [SerializeField] public ParticleSystem muzzleSmoke;
    public void Behave()
    {
        if (_isAttaking) return;
        if(Vector3.Distance(transform.position, _PlayerTransform.position) < _attackDistance)
        {
            if (Time.time < shootDelay + shootTime) return;
            {
                Shoot();
            }
            shootTime = Time.time;
            transform.LookAt(_PlayerTransform.position);
        }
    }

    public float Evaluate()
    {
        if (_PlayerTransform == null) return 0;
        {
            return Vector3.Distance(transform.position, _PlayerTransform.position) < _attackDistance ? 1 : 0;
        }
    }

    public void Shoot()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        muzzleSmoke.Play();
    }
}
