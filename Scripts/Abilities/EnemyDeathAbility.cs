using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeathAbility : MonoBehaviour, IAbility
{
    [SerializeField] public SkinnedMeshRenderer[] renderer;
    [SerializeField] public MeshRenderer[] meshRenderer;
    [SerializeField] public ParticleSystem particle;
    [SerializeField] public StudioEventEmitter deathSFX;
    private void Start()
    {
        deathSFX = FindObjectOfType<StudioEventEmitter>();
    }
    public void Execute()
    {
        for (int i = 0; i < renderer.Length; i++)
        {
            renderer[i].enabled = false;
        }
        for(int j = 0; j < meshRenderer.Length; j++)
        {
            meshRenderer[j].enabled = false;
        }
        Destroy(gameObject,1);
        particle.Play();
        deathSFX.Play();
    }
}
