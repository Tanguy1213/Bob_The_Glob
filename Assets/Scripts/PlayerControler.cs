using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    [SerializeField]
    public float Speed = 5.0f;
    private Animator PlayerAnimationController;
    private SpriteRenderer render;
    private bool GoingRight = true;

    [Header("Fire gun")]
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform gunTransform;
    [SerializeField]
    private float forcebulletVelocity = 0.01f;
    [SerializeField]
    private float timeToFire = 2;
    private float lastTimeFire = 0;

    private GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        PlayerAnimationController = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GunFollowMouse();
        PlayerAnimationController.SetFloat("SpeedY", Mathf.Abs(Input.GetAxis("Vertical")));
        PlayerAnimationController.SetFloat("SpeedX", Mathf.Abs(Input.GetAxis("Horizontal")));

        transform.Translate(Vector2.right * Input.GetAxis("Horizontal") * Speed * Time.deltaTime);
        transform.Translate(Vector2.up * Input.GetAxis("Vertical") * Speed * Time.deltaTime);

        if (Input.GetAxis("Horizontal")> 0 && !GoingRight)
        {
            SwitchDirection();
        }
        if (Input.GetAxis("Horizontal") < 0 && GoingRight)
        {
            SwitchDirection();
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
            gameManager.AddHealth();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Key1")
        {
            Destroy(collision.gameObject);
   
        }
        if (collision.tag == "EnemyBullet")
        {
            gameManager.TakeDamage();
            Destroy(collision.gameObject);
        }
    }

    void SwitchDirection()
    {
        GoingRight = !GoingRight;
        Vector2 thescale = transform.localScale;
        thescale.x *= -1;
        transform.localScale = thescale;
    }

    private void Fire()
    {
        if (Time.realtimeSinceStartup - lastTimeFire > timeToFire)
        {
         
            GameObject bullet = Instantiate(bulletPrefab, gunTransform.position, gunTransform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = gunTransform.right * forcebulletVelocity;
            Destroy(bullet, 5);
            lastTimeFire = Time.realtimeSinceStartup;
            
        }
    }
    private void GunFollowMouse()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 diff = (mouse - gunTransform.position);

        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        gunTransform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
    
}
