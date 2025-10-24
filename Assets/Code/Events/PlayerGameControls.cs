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
        public UnityAction Progress = delegate { };

        public UnityAction Back = delegate { };

        public UnityAction ScrollDown = delegate { };

        public UnityAction ScrollUp = delegate { };

        public UnityAction EnterKey = delegate { };
        public void OnBack(InputAction.CallbackContext context)
        {
            Back?.Invoke();
        }

        public void OnProgress(InputAction.CallbackContext context)
        {
            Progress?.Invoke();
        }

        public void OnScrollDown(InputAction.CallbackContext context)
        {
            ScrollDown?.Invoke();
        }

        public void OnScrollUp(InputAction.CallbackContext context)
        {
            ScrollUp?.Invoke();
        }

        public void OnEnterKey(InputAction.CallbackContext context)
        {
            EnterKey?.Invoke();
        }
    }
}