using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void EndOfGame()
    {
        Application.Quit();
    }
    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneIDS.levelSceneID);
    }
    public void ReturnToMap(){
        SceneManager.LoadSceneAsync(SceneIDS.MapSceneID);
    }
}
