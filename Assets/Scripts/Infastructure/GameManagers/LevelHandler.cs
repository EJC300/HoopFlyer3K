using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class LevelHandler : Singleton<LevelHandler>
{
    private Scene currentScene;

    public Scene CurrentScene { get { return currentScene; } }
    [SerializeField] private GameObject fadeObj;
    [SerializeField] private GameObject pauseMenu,exitMenu;

    private FadeImage fadeImage { get; set; }
   
    private Canvas sceneCanvas { get; set; }
    public GameObject PauseMenu { get => pauseMenu; set => pauseMenu = value; }
    public GameObject ExitMenu { get => exitMenu; set => exitMenu = value; }

    private void Awake()
    {

        sceneCanvas = GameObject.FindAnyObjectByType<Canvas>();
        if (fadeImage == null)
        {
            GameObject go = Instantiate(fadeObj,sceneCanvas.transform.position,Quaternion.identity);
            go.transform.SetParent(sceneCanvas.transform);
           
            fadeImage = go.AddComponent<FadeImage>();
            
        }
        if(currentScene == null)
        {
            currentScene = SceneManager.GetActiveScene();
        }
        fadeImage.LoadScene(currentScene.buildIndex, Direction.FadeIn);
    }

    private void OnDisable()
    {
       
        

      
        
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadLevel(int index)
    {
       if(currentScene.buildIndex !=  index)
        {
            SceneManager.LoadSceneAsync(index);
            
            if(currentScene.isLoaded)
            {
                fadeImage.LoadScene(index,Direction.FadeIn);
            }
            
        }
       
    }
}
