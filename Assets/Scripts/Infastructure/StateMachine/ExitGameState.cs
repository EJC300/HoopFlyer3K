using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameState: IState
{


    public void EnterState()
    {
      
            int buildIndex = LevelHandler.Instance.CurrentScene.buildIndex;
            if (buildIndex == 0)
            {
            LevelHandler.Instance.ExitMenu.SetActive(true);

            return;
            }
        }
    

    public void ExitState()
    {
     
       LevelHandler.Instance.ExitMenu.SetActive(false);
            //null
       
    }

    public void UpdateState()
    {
     
        
            //null
            return;
        
    }
}
