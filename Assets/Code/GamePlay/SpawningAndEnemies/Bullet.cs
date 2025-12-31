using UnityEngine;
namespace SpawningAndEnemies
{
    [RequireComponent (typeof(AudioSource))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject sparks;

        [SerializeField] private bool canKillEnemy;

        [SerializeField] private float Speed;

        private AudioSource bulletSound;


        private void OnEnable()
        {
            bulletSound = GetComponent<AudioSource> ();
            bulletSound.Play ();
        }
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