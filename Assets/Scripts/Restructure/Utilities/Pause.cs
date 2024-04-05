using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : IState
{
    private float currentGameSpeed { set; get; }
    private GameObject pauseWindow;
   

    public void SetPauseWindow(GameObject pauseWindow)
    {
        this.pauseWindow = pauseWindow;
    }
    public void Exit()
    {
        currentGameSpeed = 0;
        //Unpause Audio
        //Modal Window set inactive
        if (pauseWindow.activeInHierarchy)
        {
            pauseWindow.gameObject.SetActive(false);
        }
    }

    public void Initiliaze()
    {
        if (currentGameSpeed != Time.timeScale)
        {
            currentGameSpeed = Time.timeScale;
        }
        Time.timeScale = currentGameSpeed;
        
    }


    public void Update()
    {
        currentGameSpeed = 0;
        Time.timeScale = currentGameSpeed;
        //Pause Audio
        //Modal Window set active
        if (!pauseWindow.activeInHierarchy && SceneManager.GetActiveScene().buildIndex > 1)
        {
            pauseWindow.gameObject.SetActive(true);
        }
    }
}
