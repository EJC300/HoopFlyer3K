using UnityEngine;

public class Mover : MonoBehaviour
{
    //On Spawn set random Speed;
    [SerializeField]  float MaxSpeed = 5;
    private Vector3 size;
    Vector3 localScale = Vector3.zero;
    void InitializeMove()
    {
        
        MaxSpeed = Mathf.Clamp(MaxSpeed, 50f, MaxSpeed);
       
    }

    private void Awake()
    {
        size = transform.localScale;
       
    }
  
     
    private void OnEnable()
    {
     
        InitializeMove();
        localScale = Vector3.zero;
        transform.localScale = Vector3.zero;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * -MaxSpeed * Time.deltaTime);
       
           
       localScale = Vector3.Lerp(localScale, size,0.05f * Time.deltaTime);
       transform.localScale = localScale;
        
    }
}
