using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class GameStateManager : Singleton<GameStateManager>
{
    [SerializeField] private GameObject pauseWindow;
    private Scene GetScene
    {
        get { return SceneManager.GetActiveScene(); }
    }
    private Play playState;
    private Pause pauseState;
    private Exit exitState;
    private Win winState;
    private Lose loseState;
    private StateController gameStateController;
    public StateController GetStateController { get { return gameStateController; } }
    public override void Awake()
    {
        winState = new Win();
        loseState = new Lose(); 
        playState = new Play();
        pauseState = new Pause();
        exitState = new Exit();
        gameStateController = new StateController();    
        pauseState.SetPauseWindow(pauseWindow);
    }

    public void Pause()
    {
        gameStateController.ChangeState(pauseState);
      
    }
    public void Play()
    {
        gameStateController.ChangeState(playState);
  
        
    }
    public void Exit()
    {
        gameStateController.ChangeState(exitState);
      
    }
    public void WinGame()
    {
        gameStateController.ChangeState(winState);
    }
    public void LoseGame()
    {
        gameStateController.ChangeState(loseState);
    }
    private void Start()
    {
        gameStateController.InitiliazeState(playState);
    }
    private void Update()
    {
    
        

            gameStateController.UpdateState();
        
    }
}
