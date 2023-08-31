using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class FadeCanvas : MonoBehaviour
{
    public static FadeCanvas instance;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Image loadingBar;

    [SerializeField] private float changeValue;
    [SerializeField] private float waitTime;
    [SerializeField] private bool fadeStarted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        StartCoroutine(FadeIn()); // en ba�ta siyahl�k gidicek yava� yava�
    }
    public void FaderLoadString(string levelName)
    {
        StartCoroutine(FadeOutString(levelName));
    }
    public void FaderLoadInt(int levelIndex)
    {
        StartCoroutine(FadeOutInt(levelIndex));
    }
    IEnumerator FadeIn() // turn blackScreen trasnparent
    {
        loadingScreen.SetActive(false);

        fadeStarted = false;

        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= changeValue;
            yield return new WaitForSeconds(waitTime);
        }
    }
    IEnumerator FadeOutString(string levelName) // karart�p sonra a�ma ama string
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

        //SceneManager.LoadScene(levelName);

        // Belirtilen sahnenin y�klenmesi i�lemi ba�lat�l�r ve i�lemi takip etmek i�in AsyncOperation nesnesi olu�turulur.
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);

        // Sahnenin y�kleme i�lemi tamamland���nda otomatik olarak sahneyi aktive etme se�ene�i kapat�l�r.

        ao.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        loadingBar.fillAmount = 0;

        while (ao.isDone == false) //y�kleme i�lemi tamamlanana kadar devam eder.
        {
            // Y�kleme i�lemi devam etti�i s�rece, y�kleme �ubu�unun dolulu�unu y�klenme ilerlemesine g�re g�nceller.
            loadingBar.fillAmount = ao.progress / 0.9f;

            if (ao.progress == 0.9f) // 0.9 olunca da y�kleme ger�ekle�ir
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }

        /*
         * Bu �ekilde, y�kleme i�lemi y�zde %90'a kadar y�klendikten sonra sahne aktive edilir 
         * ve y�kleme �ubu�u ilerlemesi do�ru �ekilde g�sterilir.
         * 
         * 
        */

        StartCoroutine(FadeIn()); // siyah geldikten sonra gidicek.

    }
    IEnumerator FadeOutInt(int levelIndex) // karart�p sonra geri a�ma int
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
        // Belirtilen sahnenin y�klenmesi i�lemi ba�lat�l�r ve i�lemi takip etmek i�in AsyncOperation nesnesi olu�turulur.
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelIndex);

        // Sahnenin y�kleme i�lemi tamamland���nda otomatik olarak sahneyi aktive etme se�ene�i kapat�l�r.

        ao.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        loadingBar.fillAmount = 0;

        while (ao.isDone == false) //y�kleme i�lemi tamamlanana kadar devam eder.
        {
            // Y�kleme i�lemi devam etti�i s�rece, y�kleme �ubu�unun dolulu�unu y�klenme ilerlemesine g�re g�nceller.
            loadingBar.fillAmount = ao.progress / 0.9f;

            if (ao.progress == 0.9f) // 0.9 olunca da y�kleme ger�ekle�ir
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }

        /*
         * Bu �ekilde, y�kleme i�lemi y�zde %90'a kadar y�klendikten sonra sahne aktive edilir 
         * ve y�kleme �ubu�u ilerlemesi do�ru �ekilde g�sterilir.
         * 
         * 
        */

        StartCoroutine(FadeIn()); // siyah geldikten sonra gidicek.
    }

}
