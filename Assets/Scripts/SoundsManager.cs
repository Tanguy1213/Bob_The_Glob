using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{

    private AudioSource AudioSource;

    [Header("PlayerSounds")]
    [SerializeField]
    private AudioClip[] PlayerShootSounds;
    [SerializeField]
    private AudioClip PickUpKeySound;
    [SerializeField]
    private AudioClip PickUpBoost;
    [SerializeField]
    private AudioClip PickUpLife;

    [Header("EnemySounds")]
    [SerializeField]
    private AudioClip EnemyShoot;

    [Header("WinSound")]
    [SerializeField]
    private AudioClip WinSound;



    // Use this for initialization
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayShootSound()
    {
        int indexSoundRandom = Random.Range(0, PlayerShootSounds.Length); //Use to play randomly a sound
        AudioSource.clip = PlayerShootSounds[indexSoundRandom];
        AudioSource.volume = 1;
        AudioSource.Play();
    }

    public void PlayDoorSound()
    {
        AudioSource.clip = PickUpKeySound;
        AudioSource.volume = 1;
        AudioSource.Play();
    }

    public void PlayEnemyShootSound()
    {
        AudioSource.clip = EnemyShoot;
        AudioSource.volume = 0.1f;
        AudioSource.Play();
    }

    public void PlayBoostSound()
    {
        AudioSource.clip = PickUpBoost;
        AudioSource.volume = 1;
        AudioSource.Play();
    }

    public void PlayLifeSound()
    {
        AudioSource.clip = PickUpLife;
        AudioSource.volume = 10;
        AudioSource.Play();
    }

    public void PlayWinSound()
    {
        AudioSource.clip = WinSound;
        AudioSource.volume = 1;
        AudioSource.Play();
    }
}
