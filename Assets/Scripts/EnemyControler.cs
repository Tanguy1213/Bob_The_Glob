using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    [SerializeField]
    private Transform gunTransform;
    [SerializeField]
    private float timeToFire;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletVelocity = 10;

    [SerializeField]
    GameObject player;

    Vector2 direction;

    private Animator EnemyAnimationController;

    private string isShooting;

    [SerializeField]
    private GameManager gameManager;

    float theScale;
    // Use this for initialization
    void Start()
    {
        EnemyAnimationController = GetComponent<Animator>();
        StartCoroutine(Fire());
        theScale = transform.localScale.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        Lookingleft();
        direction = (player.transform.position - transform.position).normalized;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet") 
        {
            gameManager.EnemyTakeDammage();
            Destroy(collision.gameObject);
        }
      
    }

    private IEnumerator Fire()
    {
        EnemyAnimationController.SetBool("isShooting", false);
        while (true)
        {

            EnemyAnimationController.SetBool("isShooting", true);
            yield return new WaitForSeconds(timeToFire);
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = direction* bulletVelocity;
            Destroy(bullet, 3);
        }
        

    }
    private void Lookingleft()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-theScale, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(theScale, transform.localScale.y);
        }
 
    }
    
}