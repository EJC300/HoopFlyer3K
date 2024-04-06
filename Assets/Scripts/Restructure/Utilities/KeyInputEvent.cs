using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class KeyInputEvent: IInputEvent
{
    private InputAction keyAction;


    private bool pressed;

    public bool Pressed { get => pressed; set => pressed = value; }

    public KeyInputEvent (string actionName, string actionMapName, InputActionAsset inputActions)
    {
        if (keyAction == null)
        {
            keyAction = inputActions.FindActionMap(actionMapName).FindAction(actionName);
        }
    }

    public void InvokeInputAction()
    {
       
       
     //  keyAction.performed += context => pressed = true;
      // keyAction.canceled += context => pressed = false;
      
    }

    public void RegisterInputAction()
    {
      
         //  keyAction.Enable();
        
    }

    public void UnregisterInputAction()
    {
        
        //  keyAction.Disable(); 
        
    }
}
