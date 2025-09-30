using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
   

    [SerializeField] private float viewDistance;
    [SerializeField] private PlayerController player;
    [SerializeField] private CameraLookAtCursor cameraLookAtCursor;
    [SerializeField] private Transform reticule;
    
    public static GameController instance;
    public delegate void GameOver();
    public static event GameOver OnGameOver;
    public delegate void PauseGame();
    public static event PauseGame OnPauseGame;

    public float seconds;
    public float minutes;
    public bool isLoaded { get; set; }

    public void CalculateTimeElapsed()
    {
        seconds = Time.timeSinceLevelLoad;
        if (seconds > 60)
        {
            minutes++;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return  Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private Vector3 ClampToBounds(Vector3 oldPos)
    {
        Vector3 screenDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, viewDistance));
        Vector3 position = oldPos;
        position.x = Mathf.Clamp(position.x, -screenDimensions.x, screenDimensions.x);
        position.y = Mathf.Clamp(position.y, -screenDimensions.y, screenDimensions.y);

        return player.transform.TransformDirection( position);
    }

  
    private void ReticuleMovement()
    {
        float viewDistanceMultiplier = 2f;
        reticule.localPosition  = player.transform.localPosition + new Vector3(GetMouseWorldPosition().x, GetMouseWorldPosition().y, viewDistance * viewDistanceMultiplier);
    }
  
  
    private void Awake()
    {
      
        if (instance == null)
        {
            instance = this;
        }
     
    }
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Scene scene = SceneManager.GetActiveScene();

        isLoaded = scene.isLoaded;
     
    }
     
    private void Update()
    {
        if ((isLoaded))
        {
         
            CalculateTimeElapsed();
            player.MoveShip(GetMouseWorldPosition(), viewDistance);
            cameraLookAtCursor.LookAtMouse(reticule.position);
            ReticuleMovement();
            OnGameOver?.Invoke();
           
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    private void LateUpdate()
    {
       
        
       player.transform.position = ClampToBounds(player.transform.position);
    }


}
