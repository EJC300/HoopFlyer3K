using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IState
{


    public void EnterState()
    {
      
            int buildIndex = LevelHandler.Instance.CurrentScene.buildIndex;
            if (buildIndex > 0)
            {
                /*
                 * enable pause screen
                 * switch input to ui input
                 * 
                 */
                Time.timeScale = 0;
                LevelHandler.Instance.PauseMenu.SetActive(true);   
            }
         
           
        }
    

    public void ExitState()
    {
     
                /*
                 * disable pause screen
                 * switch input ui to input
                 * 
                 */
                Time.timeScale = 1;

                 LevelHandler.Instance.PauseMenu.SetActive(false);


    }

    

    public void UpdateState()
    {
       
            //null
            return;
        
    }
}
