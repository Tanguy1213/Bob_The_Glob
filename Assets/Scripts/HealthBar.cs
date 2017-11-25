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

    private EnemyManager EnemyManager;


    private void Start()
    {
        EnemyManager = GetComponent<EnemyManager>();
    }


    // Update is called once per frame
    void Update()
    {
        CurrentHP = EnemyManager.EnemyLife;
        PercentOfHP = CurrentHP / MaxHP;
        LifeBar.fillAmount = PercentOfHP;
    }
}
