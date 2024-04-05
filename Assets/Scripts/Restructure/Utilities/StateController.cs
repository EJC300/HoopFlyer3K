using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]   
public class StateController
{
   private IState currentState;
 
    public void UpdateState()
    {
        
        if (currentState != null)
        {
            currentState.Update();
            
        
        }
    }
    public void ChangeState(IState nextState)
    {
      
       
            currentState.Exit();
            currentState = nextState;
            nextState.Initiliaze();
        
      
    }
    public void InitiliazeState(IState startIngState)
    {
        currentState = startIngState;
        currentState.Initiliaze();
    }
}
