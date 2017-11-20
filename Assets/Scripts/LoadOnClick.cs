using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    public void LoadFirstLevel(string FirstLevel)
    {
        SceneManager.LoadScene(FirstLevel);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
   public void LoadSignPost(string SignPost)
    {
        SceneManager.LoadScene(SignPost);
        
    }
}