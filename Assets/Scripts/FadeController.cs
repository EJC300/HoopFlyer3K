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
    [SerializeField] private Image fadeImage;
    public static FadeController instance;
  


    private void Start()
    {
        StartCoroutine(Fade());
    }
    public IEnumerator Fade()
    {
        Color color = fadeImage.color;

        while(color.a >= 0)
        {
            color.a = QuasarMath.SmoothDamp(color.a, 0,Time.deltaTime,speed);
            fadeImage.color = color;
            yield return null;

        }
   
        fadeImage.enabled = false;  
    }

 
}
