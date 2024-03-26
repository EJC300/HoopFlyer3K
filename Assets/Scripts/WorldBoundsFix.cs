using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldBoundsFix : MonoBehaviour
{
    [SerializeField] private float distanceThreshold;
    [SerializeField] private Transform playerRig;

    private void LateUpdate()
    {
        if (playerRig.transform.position.magnitude > distanceThreshold)
        {
            for (int z = 0; z < SceneManager.sceneCount; z++)
            {
                foreach (GameObject g in SceneManager.GetSceneAt(z).GetRootGameObjects())
                    g.transform.position -= playerRig.position;
            }
            var trails = FindObjectsOfType<TrailRenderer>() as TrailRenderer[];
            foreach (var trail in trails)
            {
                Vector3[] positions = new Vector3[trail.positionCount];

                int positionCount = trail.GetPositions(positions);
                for (int i = 0; i < positionCount; ++i)
                    positions[i] -= playerRig.position;

                trail.SetPositions(positions);
            }
        }
    }
}
