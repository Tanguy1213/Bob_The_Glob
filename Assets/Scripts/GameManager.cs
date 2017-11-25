using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Player")]
    [SerializeField]
    GameObject Player;
    [SerializeField]
    public int PlayerDamages;
    [SerializeField]
    private int PlayerLife;
    [SerializeField]
    private Text TextLifes;
    private const string TEXT_LIFES = ": ";

    [SerializeField]
    public GameObject BrainSpeaking;

    private EnemyManager EnemyManager;

    // Use this for initialization
    void Start()
    {
        EnemyManager = FindObjectOfType<EnemyManager>();
        TextLifes.text = TEXT_LIFES + PlayerLife;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage()
    {
        PlayerLife -= EnemyManager.EnemyDamages;
        if (PlayerLife <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            TextLifes.text = TEXT_LIFES + PlayerLife;
        }
    }

    public void AddHealth()
    {
        PlayerLife++;
        TextLifes.text = TEXT_LIFES + PlayerLife;
    }

    public void AddAttack()
    {
        PlayerDamages++;
    }
}

