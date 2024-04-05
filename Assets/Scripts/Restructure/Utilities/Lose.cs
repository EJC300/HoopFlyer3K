using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : IState
{

    public void Exit()
    {
       //Hide Lose Graphic
       //Stop Lose Music
    }

    public void Initiliaze()
    {
      
    }

    public void Update()
    {
        //Play Lose Music
        //Show Lose Graphic
        GameStateManager.Instance.Pause();
    }
}
