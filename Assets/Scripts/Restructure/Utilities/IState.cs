using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void Initiliaze();

    public void Update();

    public void Exit();
   
}
