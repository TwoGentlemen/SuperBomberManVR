using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip notSpawnAudio;
    [SerializeField] private AudioClip spawnBomb;
    [SerializeField] private AudioClip babax;



    /// <summary>
    /// The method that causes the sound to play "you can't spawn a bomb in this place"
    /// </summary>
    public void PlayNotSpawnAudio()
    {
        audioSource.clip = notSpawnAudio;
        audioSource.Play();
    }

    public void PlaySpawnBomb()
    {
        audioSource.clip = spawnBomb;
        audioSource.Play();
    }

    public AudioClip GetAydioBabax()
    {
        return babax;
    }
}
