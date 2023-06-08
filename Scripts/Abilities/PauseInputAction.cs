using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInputAction : MonoBehaviour, IAbility
{
    [SerializeField] public GameObject pauseMenu;
    public void Execute()
    {
        Pause();
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
