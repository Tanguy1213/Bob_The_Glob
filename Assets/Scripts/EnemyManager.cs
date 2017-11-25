using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{

    private GameManager GameManager;

    [Header("Enemy")]
    [SerializeField]
    public int EnemyDamages;
    [SerializeField]
    public float EnemyLife;
    [SerializeField]
    private Animator EnemyAnimationController;
    [SerializeField]
    private GameObject DoorToClose;

    float TheScale;
    Vector2 Direction;

    private bool CanAttack = false;

    

    [Header("Gun")]
    [SerializeField]
    private Transform GunTransform;
    [SerializeField]
    private float TimeToFire;
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private float BulletVelocity;
    [SerializeField]
    GameObject Target;


    [Header("Drops")]
    [SerializeField]
    public GameObject Drop1;
    [SerializeField]
    public GameObject Drop2;
    [SerializeField]
    public GameObject Drop3;


    [Header("Sounds")]
    [SerializeField]
    private SoundsManager SoundsManager;


    // Use this for initialization
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();
        EnemyAnimationController = GetComponent<Animator>();
        StartCoroutine(Fire());
        TheScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDirection();
        Direction = (Target.transform.position - transform.position).normalized;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.tag == "Enemy")
        {
            if (collision.tag == "PlayerBullet")
            {
                CanAttack = true;
                EnemyAnimationController.SetBool("isShooting", false);
                EnemyAnimationController.SetTrigger("CancelHurtAnimation");
                EnemyTakeDamages();
                Destroy(collision.gameObject);
                DoorToClose.SetActive(true);

                if (EnemyLife <= 0)
                {
                    EnemyAnimationController.SetBool("isAlive", false);
                    DestroyObject(gameObject, 1.5f);
                    EnemyDie();
                    StopAllCoroutines();
                    DoorToClose.SetActive(false);
                }
            }
        }
    }

    public void EnemyTakeDamages()
    {
        EnemyLife -= GameManager.PlayerDamages;
    }

    public void EnemyDie()
    {
        Drop1.SetActive(true);
        Drop2.SetActive(true);
        Drop3.SetActive(true);
    }

    private IEnumerator Fire()
    {

        while (true)
        {         
            yield return new WaitForSeconds(TimeToFire);
            
            if (CanAttack == true)
            {
                EnemyAnimationController.SetBool("isShooting", true);
                GameObject bullet = Instantiate(BulletPrefab, GunTransform.position, GunTransform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = Direction * BulletVelocity;
                SoundsManager.PlayEnemyShootSound();
                Destroy(bullet, 3);
            }
        }
    }

    private void EnemyDirection() //Check if the target is on right or on left to face it
    {
        if (Target.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-TheScale, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(TheScale, transform.localScale.y);
        }

    }

}