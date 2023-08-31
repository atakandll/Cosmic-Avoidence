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
        StartCoroutine(FadeIn()); // en baþta siyahlýk gidicek yavaþ yavaþ
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
    IEnumerator FadeOutString(string levelName) // karartýp sonra açma ama string
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

        // Belirtilen sahnenin yüklenmesi iþlemi baþlatýlýr ve iþlemi takip etmek için AsyncOperation nesnesi oluþturulur.
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName);

        // Sahnenin yükleme iþlemi tamamlandýðýnda otomatik olarak sahneyi aktive etme seçeneði kapatýlýr.

        ao.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        loadingBar.fillAmount = 0;

        while (ao.isDone == false) //yükleme iþlemi tamamlanana kadar devam eder.
        {
            // Yükleme iþlemi devam ettiði sürece, yükleme çubuðunun doluluðunu yüklenme ilerlemesine göre günceller.
            loadingBar.fillAmount = ao.progress / 0.9f;

            if (ao.progress == 0.9f) // 0.9 olunca da yükleme gerçekleþir
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }

        /*
         * Bu þekilde, yükleme iþlemi yüzde %90'a kadar yüklendikten sonra sahne aktive edilir 
         * ve yükleme çubuðu ilerlemesi doðru þekilde gösterilir.
         * 
         * 
        */

        StartCoroutine(FadeIn()); // siyah geldikten sonra gidicek.

    }
    IEnumerator FadeOutInt(int levelIndex) // karartýp sonra geri açma int
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
        // Belirtilen sahnenin yüklenmesi iþlemi baþlatýlýr ve iþlemi takip etmek için AsyncOperation nesnesi oluþturulur.
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelIndex);

        // Sahnenin yükleme iþlemi tamamlandýðýnda otomatik olarak sahneyi aktive etme seçeneði kapatýlýr.

        ao.allowSceneActivation = false;

        loadingScreen.SetActive(true);

        loadingBar.fillAmount = 0;

        while (ao.isDone == false) //yükleme iþlemi tamamlanana kadar devam eder.
        {
            // Yükleme iþlemi devam ettiði sürece, yükleme çubuðunun doluluðunu yüklenme ilerlemesine göre günceller.
            loadingBar.fillAmount = ao.progress / 0.9f;

            if (ao.progress == 0.9f) // 0.9 olunca da yükleme gerçekleþir
            {
                ao.allowSceneActivation = true;
            }
            yield return null;
        }

        /*
         * Bu þekilde, yükleme iþlemi yüzde %90'a kadar yüklendikten sonra sahne aktive edilir 
         * ve yükleme çubuðu ilerlemesi doðru þekilde gösterilir.
         * 
         * 
        */

        StartCoroutine(FadeIn()); // siyah geldikten sonra gidicek.
    }

}
