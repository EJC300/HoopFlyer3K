using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHandler : Singleton<GameStateHandler>
{
    public StateMachine stateMachine;
    public PauseState pauseState;
    public PlayState playState;
    public ExitGameState exitGameState;

   
   

    private void Awake()
    {
       this.Initialize();
 
    
        exitGameState = new ExitGameState();
        pauseState = new PauseState();
        playState = new PlayState();
        stateMachine.Initialize(playState);
    }

    public void PauseGame()
    {

        stateMachine.TransitionTo(pauseState);
        stateMachine.Initialize(playState);

      

       
      
       

    }
   
    public void UnPauseGame()
    {
        stateMachine.TransitionTo(playState);
        stateMachine.Initialize(pauseState);
     
    }

    public void ExitGame()
    {
        stateMachine.TransitionTo(exitGameState);
        stateMachine.Initialize(playState);
    }

    public void ResumeGame()
    {
        stateMachine.TransitionTo(playState);
        stateMachine.Initialize(exitGameState);
    }
}
