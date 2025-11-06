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
            Vector3 camPos = playerCamera.transform.position;
            camPos.y = 0;

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
            Vector3 orgin = Vector3.zero - playerCamera.position;
            OriginChangeListener.Respond(orgin);
        
        }
    }
}
