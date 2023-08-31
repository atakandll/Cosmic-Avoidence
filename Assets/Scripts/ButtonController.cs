using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonController : MonoBehaviour
{
    public void LoadLevelString(string levelName)
    {
       FadeCanvas.instance.FaderLoadString(levelName);
    }
    public void LoadLevelInt( int  levelIndex)
    {
       FadeCanvas.instance.FaderLoadInt(levelIndex);
    }
    public void RestartLevel()
    {
        FadeCanvas.instance.FaderLoadInt(SceneManager.GetActiveScene().buildIndex);
    }
}
