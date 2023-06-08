using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoostAbility : MonoBehaviour, IBonusAbility
{
    public PlayerShootData shootData;
    public new MeshRenderer[] renderer;
    [SerializeField] public DamageBoostPanelTimer timer;
    [SerializeField] public ParticleSystem particle;
    public int bonusTime = 5;
    public int shootDiffrerence = 2;
    [SerializeField] public StudioEventEmitter pickUpSXF;
    private void Start()
    {
        shootData = FindObjectOfType<PlayerShootData>();
        timer = FindObjectOfType<DamageBoostPanelTimer>();
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
        shootData.damage *= shootDiffrerence;
        Destroy(particle);
        yield return new WaitForSeconds(bonusTime);
        timer.maxFill = 0;
        shootData.damage /= shootDiffrerence;
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
