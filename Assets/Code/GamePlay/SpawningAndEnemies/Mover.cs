using UnityEngine;

public class Mover : MonoBehaviour
{
    //On Spawn set random Speed;
    [SerializeField]  float MaxSpeed = 5;
    void InitializeMove()
    {
        MaxSpeed = MaxSpeed * Random.value;
    }

    private void OnEnable()
    {
        InitializeMove();
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * MaxSpeed);
    }
}
