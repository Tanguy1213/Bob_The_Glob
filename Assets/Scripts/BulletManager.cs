using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {

    
    GameManager gameManager;

    // Use this for initialization
    void Start () {

        gameManager = FindObjectOfType<GameManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall" && gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall" && gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }

    }

}
