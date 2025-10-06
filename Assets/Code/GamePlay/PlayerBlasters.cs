using UnityEngine;

public class PlayerBlasters : MonoBehaviour
{
    [SerializeField] private PlayerControls controls = default;
    private bool StartGame = false;
    private Blasters blasters;
    public void InitializeBlasters()
    {
        StartGame = true;
    }

    private void Start()
    {
        blasters = GetComponent<Blasters>();
    }

    private void OnEnable()
    {
        controls.MouseEventFire += Fire;
    }

    private void OnDisable()
    {
        controls.MouseEventFire -= Fire;
    }
    void Fire()
    {
        blasters.Fire(true);
    }
    void StopFire()
    {
        blasters.Fire(false);
    }
    
    private void Update()
    {
        if (StartGame)
        {
        
        //StopFire();
        }

    }
}
