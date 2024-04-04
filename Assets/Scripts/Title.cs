using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private FadeController fade;
  
    private void Update()
    {
    
        if (Input.GetMouseButton(0))
        {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           
        }

        if (Input.GetKey(KeyCode.Escape))
        {
           Application.Quit();
        }
    }
}
