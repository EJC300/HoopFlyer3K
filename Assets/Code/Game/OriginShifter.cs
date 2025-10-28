using UnityEngine;
using UnityEngine.SceneManagement;

public class OriginShifter : MonoBehaviour
{
    public OriginChangeListener OriginChangeListener;
    public Transform playerCamera;
    public float distanceThreshold = 100f;

   
    void LateUpdate()
    {
        if (playerCamera.transform.position.magnitude > distanceThreshold)
        {
            for (int z = 0; z < SceneManager.sceneCount; z++)
            {
                foreach (GameObject g in SceneManager.GetSceneAt(z).GetRootGameObjects())
                    g.transform.position -= playerCamera.position;
            }
            var trails = FindObjectsOfType<TrailRenderer>() as TrailRenderer[];
            foreach (var trail in trails)
            {
                Vector3[] positions = new Vector3[trail.positionCount];

                int positionCount = trail.GetPositions(positions);
                for (int i = 0; i < positionCount; ++i)
                    positions[i] -= playerCamera.position;

                trail.SetPositions(positions);
            }
            OriginChangeListener.Respond(playerCamera.position);
        
        }
    }
}
