using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float speed = 1f;

    public float maxDistance = 1f;

    private Transform playerTarget;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerTarget.position);
        float forwardFace = Vector3.Dot(Vector3.forward, (playerTarget.position - transform.position));
        if(distance > maxDistance && forwardFace < 0.0f )
        {
            transform.LookAt(playerTarget.position);
        }
        float speedMutliplier = Random.value;
        speedMutliplier = Mathf.Clamp(speedMutliplier,0.5f, 1f);
        transform.Translate(-transform.forward * speed * speedMutliplier);
    }
}
