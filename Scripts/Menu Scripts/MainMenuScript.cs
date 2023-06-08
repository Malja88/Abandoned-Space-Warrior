using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject transitionFade;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition()
    {
        transitionFade.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
