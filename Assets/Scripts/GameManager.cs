using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Player")]
    [SerializeField]
    GameObject player;
    [SerializeField]
    public int PlayerDamages;
    [SerializeField]
    private int PlayerLife;
    [SerializeField]
    private Text textLifes;
    private const string TEXT_LIFES = ": ";

    private EnemyController enemyController;
    // Use this for initialization
    void Start()
    {
        enemyController = FindObjectOfType<EnemyController>();
        textLifes.text = TEXT_LIFES + PlayerLife;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage()
    {
        PlayerLife -= enemyController.EnemyDamages;
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

    public void AddAttack()
    {
        PlayerDamages++;
    }

}

