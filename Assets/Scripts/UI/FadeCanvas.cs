using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FadeCanvas : MonoBehaviour
{
    public static FadeCanvas instance;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float changeValue;
    [SerializeField] private float waitTime;
    [SerializeField] private bool fadeStarted = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    public void FaderLoadString(string levelName)
    {
        StartCoroutine(FadeOut(levelName));
    }
    public void FaderLoadInt(int levelIndex)
    {
        StartCoroutine(FadeOutInt(levelIndex));
    }
    IEnumerator FadeIn() // turn blackScreen trasnparent
    {
        fadeStarted = false;

        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
    }
    IEnumerator FadeOut(string levelName) // turn blackScreen
    {
        if(fadeStarted)
        {
            yield break;
        }
        fadeStarted = true;


        if (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);

        }
        SceneManager.LoadScene(levelName);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(FadeIn());

    }
    IEnumerator FadeOutInt(int levelIndex)
    {
        if (fadeStarted)
        {
            yield break;
        }
        fadeStarted = true;


        if (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += changeValue;
            yield return new WaitForSeconds(waitTime);

        }
        SceneManager.LoadScene(levelIndex);
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(FadeIn());
    }

}
