using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.PlayerLoop;
using Events;
namespace Input
{
    [CreateAssetMenu(fileName = "PlayerGameControls", menuName = "EventSOs/PlayerGameControls")]
    public class PlayerGameControls : ScriptableObject, PlayerInput.IMenusActions
    {
        public PlayerInput playerInput;
        public UnityAction Progress = delegate { };

        public UnityAction Back = delegate { };

        public UnityAction Exit = delegate { };

        public void OnBack(InputAction.CallbackContext context)
        {
            Back?.Invoke();
        }

        public void OnProgress(InputAction.CallbackContext context)
        {
            Progress?.Invoke();
        }

        private void OnEnable()
        {
            if (playerInput == null)
            {

                playerInput = new PlayerInput();
                playerInput.Enable();
                playerInput.Menus.Back.performed += OnBack;
                playerInput.Menus.ExitGame.performed += OnExitGame;
                playerInput.Menus.Progress.performed += OnProgress;


            }



        }

        public void OnDisable()
        {
           
            playerInput.Disable();
            playerInput.Menus.Back.performed -= OnBack;
            playerInput.Menus.ExitGame.performed -= OnExitGame;
            playerInput.Menus.Progress.performed -= OnProgress;

        }

        public void OnExitGame(InputAction.CallbackContext context)
        {
           Exit?.Invoke();
        }
    }
}