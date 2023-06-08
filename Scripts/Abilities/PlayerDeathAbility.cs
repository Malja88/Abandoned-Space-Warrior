using FMODUnity;
using FMODUnityResonance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathAbility : MonoBehaviour, IAbility
{
    public PlayerHealthData healthData;
    public ParticleSystem playerExplosion;
    public new SkinnedMeshRenderer[] renderer;
    [SerializeField] public StudioEventEmitter playerDeathSXF;
    [SerializeField] public GameObject gameOverScreen;
    [SerializeField] public StudioEventEmitter stageMusic;
    [SerializeField] public ParticleSystem steps;
    [SerializeField] GameObject transitionFade;
    public void Execute()
    {
        if (healthData.currentHealth <= 0)
        {
            Destroy(steps);
            for (int i = 0; i < renderer.Length; i++)
            {
                renderer[i].enabled = false;
            }
            StartCoroutine(Death());
        }
    }

    public IEnumerator Death()
    {
        playerDeathSXF.Play();
        playerExplosion.Play();
        yield return new WaitForSeconds(3);
        transitionFade.SetActive(true);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        gameOverScreen.SetActive(true);
        stageMusic.Stop();
    }
}
