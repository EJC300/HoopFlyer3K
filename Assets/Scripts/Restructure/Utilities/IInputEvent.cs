using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInputEvent
{


    public void RegisterInputAction();

    public void UnregisterInputAction();

    public void InvokeInputAction();
}
