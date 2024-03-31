using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FadeController : MonoBehaviour
{
    [SerializeField] private float speed;
    public static FadeController instance;
    [SerializeField] private Image fadeImage;
    private bool faded;
    Color color;
    private void Awake()
    {
       

        DontDestroyOnLoad(gameObject);
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;

        }

    }
    private void Update()
    {
        Fade();
    }
    private void Fade()
    {
         color = fadeImage.color;   
        if(!faded)
        {
            fadeImage.enabled = true;
            color.a = QuasarMath.SmoothDamp(color.a, 0.0f, Time.deltaTime, speed);
            fadeImage.color = color;    
        }
        else if(color.a < 0.02f)

        {
            faded = true;
            fadeImage.enabled = false;  
            color.a = 1.0f;
            fadeImage.color = color;
          
        }
        Debug.Log(faded);
    }

    public void FadeAndScene(int index)
    {
        if (faded)
        {
            SceneManager.LoadScene(index);
        }
    }
}
