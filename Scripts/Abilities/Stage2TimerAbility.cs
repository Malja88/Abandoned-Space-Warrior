using FMODUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage2TimerAbility : MonoBehaviour, IAbility
{
    [SerializeField] public Text timer;
    [HideInInspector] public float seconds;
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject[] spawmPoints2;
    [SerializeField] GameObject[] spawnPoints3;
    [SerializeField] GameObject nextRoundScreen;
    [SerializeField] GameObject player;
    [SerializeField] StudioEventEmitter stageMusic;
    [SerializeField] StudioEventEmitter endOfStageMusic;
    [SerializeField] GameObject stageTransition;
    private TimeSpan timeSpan;
    public void Execute()
    {
        TimerCount();
    }
    private void Start()
    {
        timer.text = "Time : 00:00.00";
    }
    public void TimerCount()
    {
        seconds += Time.deltaTime;
        timeSpan = TimeSpan.FromSeconds(seconds);
        string timePlaying = "Time : " + timeSpan.ToString("mm':'ss'.'ff");
        timer.text = timePlaying;

        if (seconds >= 120)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                spawnPoints[i].SetActive(true);
            }
        }
        if (seconds >= 240)
        {
            for (int j = 0; j < spawmPoints2.Length; j++)
            {
                spawmPoints2[j].SetActive(true);
            }
        }
        if (seconds >= 360)
        {
            for (int k = 0; k < spawnPoints3.Length; k++)
            {
                spawnPoints3[k].SetActive(true);
            }
        }
        if (seconds >= 420)
        {
            stageTransition.SetActive(true);
            StartCoroutine(Transition());
        }
    }
    IEnumerator Transition()
    {
        yield return new WaitForSeconds(1.3f);
        nextRoundScreen.SetActive(true);
        player.SetActive(false);
        stageMusic.Stop();
        endOfStageMusic.Play();
    }
}
