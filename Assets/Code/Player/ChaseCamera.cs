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

        var moveTarget = PlayerShip.position +  target;

        //transform.position = QuasarMath.SmoothDamp(transform.position ,moveTarget,Time.deltaTime,CameraChaseSpeed);
        transform.position = moveTarget;
    }
    void LookAtCaret()
    {

        var lookAt = Quaternion.FromToRotation(Player.position- transform.position,Player.forward);
        //transform.GetChild(0).localRotation = lookAt;
    }
    
    private void LateUpdate()
    {
        if (StartGame && canChase && PlayerShip != null)
        {
            LookAtCaret();
            ChaseCameraMove();

        }
    }
}
