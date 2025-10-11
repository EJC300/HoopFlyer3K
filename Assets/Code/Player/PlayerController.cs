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

    private void OnEnable()
    {
        controls.MouseEventMove += OnMouseMove;
    }

    private void OnDisable()
    {
        controls.MouseEventMove -= OnMouseMove;
    }

    
    public void InitializePlayer()
    {
        StartGame = true;
    }

    private void OnMouseMove(Vector2 value)
    {
        mouseMove = value;
    }
    private void ClampPosition(ref Vector3 target)
    {
      
     
        var size = 1.5f;
        var clampedPos = target;
        clampedPos.x = Mathf.Clamp(target.x, -Boundary.x + size, Boundary.x - size);
        clampedPos.y = Mathf.Clamp(target.y, -Boundary.y + size, Boundary.y -size);
        target = ( clampedPos);
    }

    private void LookAtCursor()
    {
        var lookAt = Quaternion.LookRotation((AimCaret.localPosition - player.position).normalized, Vector3.up);
        player.localRotation = lookAt;
    }
    private void MoveToWardsCursor()
    {
        var speed = 0.4f;
        var viewDistance = 25;
        player.localPosition = ( QuasarMath.SmoothDamp(player.localPosition, new Vector3( AimCaret.position.x,AimCaret.position.y,viewDistance), Time.deltaTime, speed));
    }
    private void AimByMouse()
    {
      
            var viewDistance = 100;
            var cursorInWorld = Camera.main.ScreenToWorldPoint(new Vector3(mouseMove.x, mouseMove.y, viewDistance));
            ClampPosition( ref cursorInWorld);
            AimCaret.transform.localPosition= cursorInWorld;
        
    }
    private void Start()
    {
        var viewDistance = 150;
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
