using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{


    private GameManager gameManager;

    [Header("Enemy")]
    [SerializeField]
    public int EnemyDamages;
    [SerializeField]
    public float EnemyLife;
    [SerializeField]
    private Animator EnemyAnimationController;
    float theScale;

    [Header("Gun")]
    [SerializeField]
    private Transform gunTransform;
    [SerializeField]
    private float timeToFire;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletVelocity;
    [SerializeField]
    GameObject Target;

    Vector2 direction;

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
        gameManager = FindObjectOfType<GameManager>();
        EnemyAnimationController = GetComponent<Animator>();
        StartCoroutine(Fire());
        theScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Lookingleft();
        direction = (Target.transform.position - transform.position).normalized;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "Enemy")
        {
            if (collision.tag == "PlayerBullet")
            {
                EnemyAnimationController.SetBool("isShooting", false);
                EnemyAnimationController.SetTrigger("CancelHurtAnimation");
                EnemyTakeDamages();
                Destroy(collision.gameObject);

                if (EnemyLife <= 0)
                {
                    EnemyAnimationController.SetBool("isAlive", false);
                    DestroyObject(gameObject, 1.5f);
                    EnemyDie();
                    StopAllCoroutines();
                }
            }
        }

    }
    public void EnemyTakeDamages()
    {
        EnemyLife -= gameManager.PlayerDamages;
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

            {

                EnemyAnimationController.SetBool("isShooting", true);
                yield return new WaitForSeconds(timeToFire);
                GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletVelocity;
                SoundsManager.PlayEnemyShootSound();
                Destroy(bullet, 3);
            }
        }


    }

    private void Lookingleft()
    {
        if (Target.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-theScale, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(theScale, transform.localScale.y);
        }

    }

}