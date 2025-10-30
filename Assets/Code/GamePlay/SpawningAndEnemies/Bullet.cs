using UnityEngine;
namespace SpawningAndEnemies
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject sparks;

        [SerializeField] private bool canKillEnemy;

        [SerializeField] private float Speed;

        private void Update()
        {
            transform.Translate(Vector3.forward * Speed);
        }
        //Kill(disable) enemy or damage player
        private void OnDisable()
        {
            Instantiate(sparks,transform.position,Quaternion.identity);
        }
    }
}