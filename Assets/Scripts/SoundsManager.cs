using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{

    private AudioSource audioSource;

    [Header("PlayerSounds")]
    [SerializeField]
    private AudioClip[] PlayerShootSounds;
    [SerializeField]
    private AudioClip PickUpKeySound;

    [Header("EnemySounds")]
    [SerializeField]
    private AudioClip EnemyShoot;

 

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayShootSound()
    {
        int indexSoundRandom = Random.Range(0, PlayerShootSounds.Length);
        audioSource.clip = PlayerShootSounds[indexSoundRandom];
        audioSource.Play();
    }
    public void PlayDoorSound()
    {
        audioSource.clip = PickUpKeySound;
        audioSource.Play();
    }
    public void PlayEnemyShootSound()
    {
        audioSource.clip = EnemyShoot;
        audioSource.volume = 1;
        audioSource.Play();       
    }
}
