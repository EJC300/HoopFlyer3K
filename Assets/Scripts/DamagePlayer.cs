using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        float damage = 1.5f;
        Debug.Log("Damage");
        if (other.collider.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.Damage(damage);
            
        }
    }



}
