using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    [SerializeField] private float seconds;

    private void Update()
    {
        Destroy(this.gameObject, seconds);
    }
}
