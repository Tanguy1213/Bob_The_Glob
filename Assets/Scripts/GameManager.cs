using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {



    [SerializeField]
    public int EnemyLife = 10;
    [SerializeField]
    private Text enemyTextLifes;
    private const string ENEMY_TEXT_LIFES = "Enemy's lifes : ";

    [SerializeField]
    private int PlayerLife = 10;
    [SerializeField]
    private Text textLifes;
    private const string TEXT_LIFES = ": ";

    private int damages = 1;

    // Use this for initialization
    void Start ()
    {
        textLifes.text = TEXT_LIFES + PlayerLife;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnemyTakeDammage()
    {
        EnemyLife -= damages;
        if (EnemyLife <= 0)
        {
          
        }
        else
        {
            //enemyTextLifes.text = ENEMY_TEXT_LIFES + EnemyLife;
        }
    }

    public void TakeDamage()
    {
        PlayerLife -= damages;
        if (PlayerLife <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            textLifes.text = TEXT_LIFES + PlayerLife;
        }
    }

    public void EnemyDie()
    {
        EnemyLife--;
        if (EnemyLife <= 0)
        {
           
        }
        else
        {
            enemyTextLifes.text = ENEMY_TEXT_LIFES + EnemyLife;
        }
    }

    public void PlayerDie()
    {
        PlayerLife--;
        if (PlayerLife <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            textLifes.text = TEXT_LIFES + PlayerLife;
        }
    }

    public void AddHealth()
    {
        PlayerLife++;
        textLifes.text = TEXT_LIFES + PlayerLife;
    }
}

