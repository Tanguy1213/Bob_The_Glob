using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    private float CurrentHP;
    [SerializeField]
    private float MaxHP;

    private float PercentOfHP;
    [SerializeField]
    private Image LifeBar;

    private BossManager BossManager;


    private void Start()
    {
        BossManager = FindObjectOfType<BossManager>();
    }


    // Update is called once per frame
    void Update()
    {
        CurrentHP = BossManager.BossLife;
        PercentOfHP = CurrentHP / MaxHP;
        LifeBar.fillAmount = PercentOfHP;
    }
}