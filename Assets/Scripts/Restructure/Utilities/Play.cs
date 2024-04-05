using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : IState
{
    private float currentGamepeed;
    public void Exit()
    {
       
    }

    public void Initiliaze()
    {
       currentGamepeed = 1.0f;
    }

    public void Update()
    {
        Time.timeScale = currentGamepeed;
    }
}
   

