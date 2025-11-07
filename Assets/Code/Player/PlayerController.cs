using UnityEngine;
using Events;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerControls controls = default;
    [SerializeField] private Transform AimCaret;
    
    [SerializeField] private Vector3 Boundary;

    [SerializeField] private Transform player;

    private bool StartGame = false;

    private Vector3 mouseMove;

    public FloatEventListener drainFuelFromBoostListener;

    public RigMover rigMover;

    private float PrevSpeed;

    private void OnEnable()
    {
        controls.MouseEventMove += OnMouseMove;
        controls.MouseEventBoostCancel += CancelBoost;
        controls.MouseEventBoost += Boost;
        Cursor.visible = false;
    }

    private void OnDisable()
    {
        controls.MouseEventMove -= OnMouseMove;
        controls.MouseEventBoostCancel -= CancelBoost;
        controls.MouseEventBoost -= Boost;
    }

    
    public void InitializePlayer()
    {
        StartGame = true;
    }
    public void DisablePlayer()
    {
        StartGame = false;
    }
    private void OnMouseMove(Vector2 value)
    {
        mouseMove = value;
    }

    public void CancelBoost()
    {
        
    }
    public void Boost()
    {
        rigMover.IncreaseSpeed();
    }
    private void ClampPosition(ref Vector3 target)
    {

        var minimum =25;
        var size = 0f;
        var clampedPos = target;
        clampedPos.x = Mathf.Clamp(target.x, -Boundary.x * minimum + size, Boundary.x * minimum - size);
        clampedPos.y = Mathf.Clamp(target.y, -Boundary.y * minimum + size, Boundary.y * minimum - size);
        target = ( clampedPos);
    }

    private void LookAtCursor()
    {
        var lookAt = Quaternion.LookRotation((AimCaret.localPosition - player.position).normalized, Vector3.up);
         player.localRotation = lookAt;
    }
    private void MoveToWardsCursor()
    {
        var speed = 5f;
        var viewDistance = 25;
        player.localPosition = ( QuasarMath.SmoothDamp(player.localPosition, new Vector3( AimCaret.position.x,AimCaret.position.y,viewDistance), Time.deltaTime, speed));
    }
    private void AimByMouse()
    {
      
            var viewDistance = 50;
            var cursorInWorld = Camera.main.ScreenToWorldPoint(new Vector3(mouseMove.x, mouseMove.y, viewDistance));
            ClampPosition( ref cursorInWorld);
            AimCaret.transform.localPosition= cursorInWorld;
        
    }
    private void Start()
    {
        var viewDistance = 25;
        Boundary = new Vector3(Screen.width, Screen.height, viewDistance );
        Boundary = Camera.main.ScreenToWorldPoint(Boundary);
    }
    private void Update()
    {
        if (StartGame)
        {
            AimByMouse();
            LookAtCursor();
            MoveToWardsCursor();
       
           
        }
    }

    private void FixedUpdate()
    {
        if (StartGame)
        {

        }
    }
}
