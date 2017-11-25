using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject SignPost;

    public void LoadFirstLevel(string FirstLevel)
    {
        SceneManager.LoadScene(FirstLevel);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadSignPost()
    {
        SignPost.SetActive(true);
    }
    public void CloseSignPost()
    {
        SignPost.SetActive(false);
    }
}