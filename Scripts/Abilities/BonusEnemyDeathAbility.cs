using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEnemyDeathAbility : MonoBehaviour, IAbility
{
    [SerializeField] public new SkinnedMeshRenderer renderer;
    [SerializeField] public ParticleSystem particle;
    [SerializeField] public GameObject[] boost;
    public void Execute()
    {
        renderer.enabled = false;
        particle.Play();
        StartCoroutine(SpawnBoost());
        Destroy(gameObject, 2);
    }

    public void InstantiateBoostIcons()
    {
        Instantiate(boost[Random.Range(0, boost.Length)], transform.position, transform.rotation);
    }

    public IEnumerator SpawnBoost()
    {
        yield return new WaitForSeconds(1);
        InstantiateBoostIcons();
    }
}
