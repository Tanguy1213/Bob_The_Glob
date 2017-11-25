using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject SignPost;

   [SerializeField]
    private GameObject PauseCanvas;

    [SerializeField]
    private GameObject Player;

    private bool IsPauseActive = false;

    private void Start()
    {
        
    }
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

    public void ResumeButton()
    {
        IsPauseActive = !IsPauseActive;
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeButton();
            
        }

        if(IsPauseActive == true)
        {
            Time.timeScale = 0.0f;
            PauseCanvas.SetActive(true);
            Cursor.visible = true;
            Player.SetActive(false);
        }

        else
        {
            Time.timeScale = 1.0f;
            PauseCanvas.SetActive(false);
            Player.SetActive(true);
        }
    }
}