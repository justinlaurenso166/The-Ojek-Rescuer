using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public Image splashImage1;
    public Image splashImage2;

    IEnumerator Start()
    {
        splashImage1.canvasRenderer.SetAlpha(0.0f);
        splashImage2.canvasRenderer.SetAlpha(0.0f);

        FadeIn(splashImage1);
        yield return new WaitForSeconds(2.5f);
        FadeOut(splashImage1);
        yield return new WaitForSeconds(2f);
        FadeIn(splashImage2);
        yield return new WaitForSeconds(2.5f);
        FadeOut(splashImage2);
        yield return new WaitForSeconds(2f);
        
        SceneManager.LoadScene("GameMenu");
    }

    void FadeIn(Image image)
    {
        image.CrossFadeAlpha(1.0f, 1.5f, false);
    }
    void FadeOut(Image image)
    {
        image.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
