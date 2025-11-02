using Input;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace PlayerGamePlay {
 
    public class ScoreManager : MonoBehaviour
    {
      public  PlayerGameControls PlayerGameControls = default;

        public TimeScore score;

        public TMP_Text player;

        private Scene currentScene;
        private bool restart;

        private void OnEnable()
        {
            PlayerGameControls.Back += Restart;
        }
        private void OnDisable()
        {
            PlayerGameControls.Back -= Restart;
        }
        public void Awake()
        {
            if (player.gameObject.activeInHierarchy)
            {
                player.gameObject.SetActive(false);
            }
            currentScene = SceneManager.GetActiveScene();

        }

        public void Restart()
        {
            restart = !restart;
        }
        public void DisplayTime()
        {
            player.transform.gameObject.SetActive(true);
            player.text = score.TimeScoreString() + "Play Again Press Left Mouse Button";
        }

        //Since this is a web game I don't need to exit the game.

        private void Update()
        {
            score.IncrementTime();
            if(restart)
            {
                Debug.Log(restart);
                SceneManager.LoadScene(currentScene.buildIndex);
            }
        }

    }
}
