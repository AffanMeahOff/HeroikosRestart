using System.Collections;
using UnityEngine;

public class ScreenFade : MonoBehaviour
{
    public CanvasGroup fadeGroup;

    void Start()
    {
        fadeGroup.alpha = 0;
    }

    public void FadeToBlack()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        while (fadeGroup.alpha < 1)
        {
            fadeGroup.alpha += Time.deltaTime / 2f;
            yield return null;
        }
    }
}

