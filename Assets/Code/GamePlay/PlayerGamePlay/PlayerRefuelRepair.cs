using UnityEngine;

public class PlayerRefuelRepair : MonoBehaviour
{

    public float FuelAmount;
    public GameObject flash;
    AudioSource popSound;
    
    private void Start()
    {
        popSound = GetComponent<AudioSource>();
    }
 
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!popSound.isPlaying)
            {
                popSound.Play();
                Instantiate(flash, other.transform.position, Quaternion.identity);
            }
            Transform obj = other.transform.parent.parent;
            if (obj != null && obj.TryGetComponent(out PlayerFuelController playerFuelController))
            {
                playerFuelController.FuelListener.Respond(FuelAmount);
            }

            if (obj != null && obj.TryGetComponent(out PlayerHealthController playerHealthController))
            {
               playerHealthController.Repair();
            }
        }
    }
}
