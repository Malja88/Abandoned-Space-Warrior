using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public StudioEventEmitter stageMusic;
    [SerializeField] public StudioEventEmitter endOfStageMusic;
    [SerializeField] StudioEventEmitter buttonSFX;
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        buttonSFX.Play();
    }
    public void LoadMenu()
    {
        buttonSFX.Play();
        stageMusic.Stop();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        World.DefaultGameObjectInjectionWorld.EntityManager.DestroyEntity(World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(DestroyTag)));
        World.DefaultGameObjectInjectionWorld.EntityManager.DestroyEntity(World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(DestroyEnvironmentTag)));
    }
    public void NextStage()
    {
        buttonSFX.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        endOfStageMusic.Stop();
    }
    public void RestartStage()
    {
        buttonSFX.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        stageMusic.Stop();
        World.DefaultGameObjectInjectionWorld.EntityManager.DestroyEntity(World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(DestroyTag)));
    }
}
