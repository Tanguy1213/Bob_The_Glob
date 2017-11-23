using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float CurrentHP;
    [SerializeField]
    private float MaxHP;

    private float PercentOfHP;
    [SerializeField]
    private Image LifeBar;

    private EnemyController enemyController;


    private void Start()
    {
        enemyController = GetComponent<EnemyController>();
    }


    // Update is called once per frame
    void Update()
    {
        CurrentHP = enemyController.EnemyLife;
        PercentOfHP = CurrentHP / MaxHP;
        LifeBar.fillAmount = PercentOfHP;
    }

}
