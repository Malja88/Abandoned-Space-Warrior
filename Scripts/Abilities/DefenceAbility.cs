using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Zenject;

public class DefenceAbility : MonoBehaviour, IBonusAbility
{
    public DamagePlayerAbility damageAbility;
    public new MeshRenderer[] renderer;
    [SerializeField] public DefenceBoostPanelTimer timer;
    [SerializeField] public ParticleSystem particle;
    [SerializeField] public StudioEventEmitter pickUpSXF;
    public int bonusTime = 5;
    public int shootDiffrerence = 2;
    private void Start()
    {
        damageAbility = FindObjectOfType<DamagePlayerAbility>();
        timer = FindObjectOfType<DefenceBoostPanelTimer>();
    }
    public void Collect()
    {      
        StartCoroutine(SpeedBonus());
    }
    IEnumerator SpeedBonus()
    {
        pickUpSXF.Play();
        timer.maxFill = 5;
        for (int i = 0; i < renderer.Length; i++)
        {
            renderer[i].enabled = false;
        }
        damageAbility.enemyDamage /= shootDiffrerence;
        Destroy(particle);      
        yield return new WaitForSeconds(bonusTime);
        timer.maxFill = 0;
        damageAbility.enemyDamage *= shootDiffrerence;
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
