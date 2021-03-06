﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Player")]
    [SerializeField]
    private Sprite[] SpritesDirection;
    [SerializeField]
    public float Speed = 5.0f;

    [Header("Environement interraction")]
    [SerializeField]
    GameObject Key1Canvas;
    [SerializeField]
    GameObject AttackBoost1Canvas;
    [SerializeField]
    GameObject Door1;
    [Space]
    [SerializeField]
    GameObject Key2Canvas;
    [SerializeField]
    GameObject AttackBoost2Canvas;
    [SerializeField]
    GameObject Door2;

    [Header("Fire gun")]
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private Transform GunTransform;
    [SerializeField]
    private float ForcebulletVelocity = 0.01f;
    [SerializeField]
    private float TimeToFire = 2;
    private float LastTimeFire = 0;
    private int TimeToDestroyBullet = 5;

    [Header("Sounds")]
    [SerializeField]
    private SoundsManager SoundsManager;


    private GameManager GameManager;
    private EnemyManager EnemyController;
    private BossManager BossManager;
    private SpriteRenderer SpriteRenderer;

    // Use this for initialization
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BossManager = FindObjectOfType<BossManager>();
        GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GunFollowMouse();

        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * Speed * Time.deltaTime);
        transform.Translate(Vector2.up * Input.GetAxis("Vertical") * Speed * Time.deltaTime);

        if (Input.GetAxis("Horizontal") > 0)
        {
            SpriteRenderer.sprite = SpritesDirection[0];
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            SpriteRenderer.sprite = SpritesDirection[1];
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            SpriteRenderer.sprite = SpritesDirection[3];
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            SpriteRenderer.sprite = SpritesDirection[2];
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Lifes")
        {
            SoundsManager.PlayLifeSound();
            GameManager.AddHealth();
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Key1")
        {
            SoundsManager.PlayDoorSound();
            Destroy(collision.gameObject);
            Key1Canvas.SetActive(true);
            Destroy(Door1);
        }

        if (collision.tag == "Key2")
        {
            SoundsManager.PlayDoorSound();
            Destroy(collision.gameObject);
            Key2Canvas.SetActive(true);
            Destroy(Door2);
        }

        if (collision.tag == "EnemyBullet")
        {
            GameManager.TakeDamage();
            Destroy(collision.gameObject);
        }

        if (collision.tag == "AttackBoost")
        {
            SoundsManager.PlayBoostSound();
            GameManager.AddAttack();
            AttackBoost1Canvas.SetActive(true);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "AttackBoost2")
        {
            SoundsManager.PlayBoostSound();
            GameManager.AddAttack();
            AttackBoost2Canvas.SetActive(true);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "BossAggroZone")
        {
            SoundsManager.PlayDoorSound();
            BossManager.PlayerInRange = true;
        }
    }

    private void Fire()
    {
        if (Time.realtimeSinceStartup - LastTimeFire > TimeToFire)
        {
            GameObject bullet = Instantiate(BulletPrefab, GunTransform.position, GunTransform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = GunTransform.right * ForcebulletVelocity;
            Destroy(bullet, TimeToDestroyBullet);
            LastTimeFire = Time.realtimeSinceStartup;
            SoundsManager.PlayShootSound();
        }
    }

    private void GunFollowMouse()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = (mouse - GunTransform.position);

        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        GunTransform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
