using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]   
public class StateMachine
{
    private IState currentState;

  
    public void Initialize(IState newState)
    {
      
            currentState = newState;
            newState.EnterState();

        
    }
    public void TransitionTo(IState nextState)
    {
        currentState.ExitState();

        currentState = nextState;
        nextState.EnterState();  
    }
    public void Update(IState newState)
    {


        if (currentState != null)
        {



            currentState.UpdateState();
        }
    }



}
