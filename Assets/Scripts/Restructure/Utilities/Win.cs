using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : IState
{
    public void Exit()
    {
        //Stop Win Music
        //Hide Win Graphic
    }

    public void Initiliaze()
    {
        
    }

    public void Update()
    {
        //Play Win Music
        //Show Win Graphic
        GameStateManager.Instance.Pause();
    }
}
