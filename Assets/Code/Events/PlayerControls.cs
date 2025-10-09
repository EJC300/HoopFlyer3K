using System;
using Unity.Burst;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.PlayerLoop;
namespace Events
{
    [CreateAssetMenu(fileName = "PlayerControlsGameplay", menuName = "EventSOs/PlayerControlsGameplay")]
    public class PlayerControls : ScriptableObject, PlayerInput.IPlayerGameplayActions
    {
        public PlayerInput playerInput;


        public UnityAction<Vector2> MouseEventMove = delegate { };

        public UnityAction MouseEventFire = delegate { };

        public UnityAction MouseEventFireCancled = delegate { };

        public UnityAction MouseEventBoost = delegate { };

        public void OnMouseBoost(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                MouseEventBoost.Invoke();
            }
        }


        public void OnMouseFire(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                MouseEventFire.Invoke();
            }





        }
        public void OnMouseFireOff(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                MouseEventFireCancled.Invoke();
            }





        }
        public void OnMouseMove(InputAction.CallbackContext context)
        {

            MouseEventMove.Invoke(context.ReadValue<Vector2>());


        }

        private void OnEnable()
        {
            if (playerInput == null)
            {

                playerInput = new PlayerInput();
                playerInput.Enable();
                playerInput.PlayerGameplay.MouseFire.performed += OnMouseFire;
                playerInput.PlayerGameplay.MouseFire.canceled += OnMouseFireOff;
                playerInput.PlayerGameplay.MouseMove.performed += OnMouseMove;


            }

     

        }

        public void OnDisable()
        {
            playerInput.PlayerGameplay.MouseFire.performed -= OnMouseFire;
            playerInput.PlayerGameplay.MouseFire.canceled -= OnMouseFireOff;
            playerInput.PlayerGameplay.MouseMove.performed -= OnMouseMove;
            playerInput.Disable();

        }



    }
}