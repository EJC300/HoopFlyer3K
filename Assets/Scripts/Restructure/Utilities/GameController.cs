using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class GameController : MonoBehaviour
{
    [SerializeField] private float viewDistance;
    [SerializeField] private PlayerController player;
    [SerializeField] private CameraLookAtCursor cameraLookAtCursor;
    [SerializeField] private Transform reticule;
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
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void Update()
    {
        player.MoveShip(GetMouseWorldPosition(), viewDistance);
        cameraLookAtCursor.LookAtMouse(reticule.position );
        ReticuleMovement();
    }
    private void LateUpdate()
    {
       player.transform.position = ClampToBounds(player.transform.position);
    }


}
