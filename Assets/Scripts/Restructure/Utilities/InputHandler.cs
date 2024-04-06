using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using Utilities;

public class InputHandler :Singleton<InputHandler>
{
    void OnPause(InputValue Pause)
    {

        if (Pause.isPressed)
        {

            GameStateManager.Instance.Pause();
        }
    }
  
    void OnNextLevel(InputValue NextLevel)
    {
        Scene scene = SceneManager.GetActiveScene();

        if (NextLevel.isPressed)
        {
            LevelManager.Instance.LoadScene(scene.buildIndex + 1);

        }
    }
  
}
