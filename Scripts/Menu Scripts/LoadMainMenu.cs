using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    [SerializeField] StudioEventEmitter buttonSFX;
    public void LoadMenu()
    {
        buttonSFX.Play();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        World.DefaultGameObjectInjectionWorld.EntityManager.DestroyEntity(World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(DestroyTag)));
        World.DefaultGameObjectInjectionWorld.EntityManager.DestroyEntity(World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(DestroyEnvironmentTag)));
    }
}
