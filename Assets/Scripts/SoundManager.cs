using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sfxSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayGameMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySingle(AudioClip clip) {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void PlayWithRandomPitch(AudioClip clip) {
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        sfxSource.pitch = randomPitch;
        sfxSource.clip = clip;
        sfxSource.Play();
    }
}
