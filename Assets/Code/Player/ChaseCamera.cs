using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
  
    [SerializeField] private Transform Player;
    [SerializeField] private Transform PlayerShip;
    [SerializeField] private float CameraChaseSpeed;
    [SerializeField] private float CameraLookSpeed;
    private bool StartGame = false;
    private bool canChase;
    [SerializeField] Vector3 target;
    public void InitalizeCamera()
    {
        StartGame = true;
        canChase = true;
        
    }
    public void DisableCamera()
    {
      canChase = false;
    }
    void ChaseCameraMove()
    {

        var moveTarget = PlayerShip.position + target;

        //transform.position = QuasarMath.SmoothDamp(transform.position ,moveTarget,Time.deltaTime,CameraChaseSpeed);
        transform.position = moveTarget;
    }
    void LookAtCaret()
    {
        
        var lookAt = Quaternion.LookRotation(PlayerShip.position - transform.position,Vector3.up);
        transform.rotation = lookAt;
    }
    
    private void LateUpdate()
    {
        if (StartGame && canChase)
        {
            ChaseCameraMove();
            LookAtCaret();
        }
    }
}
