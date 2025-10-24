using UnityEngine;
using Events;
using System.Collections;
using UnityEngine.Windows;
using Input;

namespace PlayerGamePlay {
    public class GameManager : MonoBehaviour
    {
        public Transform PauseMenu;
        public PlayerGameControls PlayerGameControls = default;
        public VoidEventListener StartGameListener;
        public VoidEventListener SpawnEntities;
        public bool started = false;
        [SerializeField] private float SpawnRate;

        public void OnEnable()
        {
            PlayerGameControls.Progress += StartGame;
            PlayerGameControls.Back += ExitGame;
        }

        public void OnDisable()
        {
            PlayerGameControls.Progress -= StartGame;
            PlayerGameControls.Back -= ExitGame;
        }
        public void StartGame()
        {
           
            
                started = true;
                PauseMenu.gameObject.SetActive(false);
                
              
            
        }
        public void ExitGame()
        {
            Application.Quit();
        }
        private void Update()
        {
            if (started)
            {
                SpawnEntities.Respond();

            }
        }
       
     
    }
}
