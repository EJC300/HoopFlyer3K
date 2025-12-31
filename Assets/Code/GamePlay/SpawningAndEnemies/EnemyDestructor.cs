using UnityEngine;

public class EnemyDestructor : MonoBehaviour
{
    [SerializeField] private GameObject husk;



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            Instantiate(husk, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

}
