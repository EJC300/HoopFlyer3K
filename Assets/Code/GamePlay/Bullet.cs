using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private bool canKillEnemy;

    [SerializeField] private float Speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * Speed);
    }
    //Kill(disable) enemy or damage player
}
