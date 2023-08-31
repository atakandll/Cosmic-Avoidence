using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonController : MonoBehaviour
{
    public void LoadLevelString(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void LoadLevelInt( int  levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart any level which player is.
    }
}
