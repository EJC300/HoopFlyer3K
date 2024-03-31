using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
   
    [SerializeField] private float viewDistance;
    [SerializeField] private PlayerController player;
    [SerializeField] private CameraLookAtCursor cameraLookAtCursor;
    [SerializeField] private Transform reticule;
    [SerializeField] private Text timeScore;
    public static GameController instance;
    public bool isLoaded { get; set; }
    private float timer;
    private float currentScore;
    [SerializeField] private float seconds;

    public float Timer { get => timer; set => timer = value; }
    public float CurrentScore { get => currentScore; set => currentScore = value; }

    private Vector3 GetMouseWorldPosition()
    {
        return  Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private Vector3 ClampToBounds(Vector3 oldPos)
    {
        Vector3 screenDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - (viewDistance), Screen.height - (viewDistance), viewDistance));
        Vector3 position = oldPos;
        position.x = Mathf.Clamp(position.x, -screenDimensions.x, screenDimensions.x);
        position.y = Mathf.Clamp(position.y, -screenDimensions.y, screenDimensions.y);

        return player.transform.InverseTransformDirection( position);
    }

  
    private void ReticuleMovement()
    {
        float viewDistanceMultiplier = 2f;
        reticule.localPosition  = player.transform.localPosition + new Vector3(GetMouseWorldPosition().x, GetMouseWorldPosition().y, viewDistance * viewDistanceMultiplier);
    }
    void CountDown()
    {

        if(timer > 0)
        {
            timer -= Time.deltaTime;
            
        }
        else
        {
            timer = 0;
            ResetGame();
          
        }
    }
    private void ResetGame()
    {
       FadeController.instance.FadeAndScene(SceneManager.GetActiveScene().buildIndex);

  
    }
    private void Awake()
    {
        timer = seconds;
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
         

            player.MoveShip(GetMouseWorldPosition(), viewDistance);
            cameraLookAtCursor.LookAtMouse(reticule.position);
            ReticuleMovement();
            CountDown();
            timeScore.text = Mathf.Round(timer).ToString();
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
