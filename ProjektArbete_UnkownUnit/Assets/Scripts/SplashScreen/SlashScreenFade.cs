using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SlashScreenFade : MonoBehaviour
{
    public Image SplashImage;
    public string LoadLevel;

    IEnumerator Start()
    {
        SplashImage.canvasRenderer.SetAlpha(0.0f);
        yield return new WaitForSeconds(1.0f);
        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(LoadLevel);
    }

    private void FadeIn()
    {
        SplashImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    private void FadeOut()
    {
        SplashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
