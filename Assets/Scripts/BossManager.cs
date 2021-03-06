﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{

    private GameManager gameManager;

    [Header("Boss")]
    [SerializeField]
    public int BossDamages;
    [SerializeField]
    public float BossLife;
    [SerializeField]
    private GameObject BossHealthBar;
    [SerializeField]
    private Animator BossAnimationController;
    [SerializeField]
    private GameObject DoorToClose;
    private SpriteRenderer BossSpriteRenderer;

    private bool BossIsAlive = true;
    public bool PlayerInRange = false;
    private float TimeToDestroyBoss = 4.0f;

    private bool isBlinking = false;
    private float BlinkingLoopTime = 0.1f;
    private float TimeToBlink = 0.5f;

    [Header("Guns")]
    [SerializeField]
    private Transform[] GunsTransformListP1;
    [SerializeField]
    private Transform[] GunsTransformListP2;
    [SerializeField]
    private float TimeToFire;
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private float BulletVelocity;
    private int TimeToDestroyBullet = 5;

    [Header("Sounds")]
    [SerializeField]
    private SoundsManager SoundsManager;
    [SerializeField]
    private GameObject WinSound;


    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        BossAnimationController = GetComponent<Animator>();
        BossSpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    { }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "PlayerBullet" && BossIsAlive == true) //Check collision between the boss and player's bullets
        {
            BossAnimationController.SetBool("isShooting", false);
            StartCoroutine(BossTakeDamages());
            Destroy(collision.gameObject);

            if (BossLife <= 0)
            {
                BossIsAlive = false;
                gameManager.BrainSpeaking.SetActive(true);
                DoorToClose.SetActive(false);
                BossAnimationController.SetBool("isAlive", false);
                BossDie();
                StopAllCoroutines();
            }
        }
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeToFire);

            if (BossLife % 2 == 0 && PlayerInRange == true)     //Used to switch fire state on hit on two
            {
                BossAnimationController.SetBool("isShooting", true);
                foreach (Transform t in GunsTransformListP1)
                {
                    SoundsManager.PlayEnemyShootSound();
                    GameObject bullet = Instantiate(BulletPrefab, t.position, t.rotation);
                    bullet.GetComponent<Rigidbody2D>().velocity = t.right * BulletVelocity;
                    Destroy(bullet, TimeToDestroyBullet);
                }
            }

            if (BossLife % 2 == 1 && PlayerInRange == true)      //Used to switch fire state on hit on two
            {
                BossAnimationController.SetBool("isShooting", true);
                foreach (Transform t in GunsTransformListP2)
                {
                    SoundsManager.PlayEnemyShootSound();
                    GameObject bullet = Instantiate(BulletPrefab, t.position, t.rotation);
                    bullet.GetComponent<Rigidbody2D>().velocity = t.right * BulletVelocity;
                    Destroy(bullet, TimeToDestroyBullet);
                }
            }

            if (PlayerInRange == true)
            {
                DoorToClose.SetActive(true);
                BossHealthBar.SetActive(true);
            }
        }
    }

    private IEnumerator BossTakeDamages()
    {
        BossLife -= gameManager.PlayerDamages;
        if (isBlinking == false)
        {
            isBlinking = true;
            StartCoroutine(Blinking());
            yield return new WaitForSeconds(TimeToBlink);
            isBlinking = false;
        }
    }

    private IEnumerator Blinking()
    {
        while (isBlinking)
        {
            BossSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(BlinkingLoopTime);
            BossSpriteRenderer.enabled = true;
            yield return new WaitForSeconds(BlinkingLoopTime);
        }
    }

    public void BossDie()
    {
        Destroy(gameObject, TimeToDestroyBoss);
        BossHealthBar.SetActive(false);
        WinSound.SetActive(true);
    }
}
