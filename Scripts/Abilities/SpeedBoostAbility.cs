using FMODUnity;
using System.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpeedBoostAbility : MonoBehaviour, IBonusAbility
{
    public PlayerSpeedData data;
    public new MeshRenderer[] renderer;
    [SerializeField] public SpeedBoostPanelTimer timer;
    [SerializeField] public ParticleSystem particle;
    [SerializeField] public StudioEventEmitter pickUpSXF;
    public int bonusTime = 5;
    public int speedDiffrerence = 2;
    private void Start()
    {
        data = FindObjectOfType<PlayerSpeedData>();
        timer = FindObjectOfType<SpeedBoostPanelTimer>();
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
        data.playerSpeed *= speedDiffrerence;
        Destroy(particle);
        yield return new WaitForSeconds(bonusTime);
        timer.maxFill = 0;
        data.playerSpeed /= speedDiffrerence;
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
