using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] gameMusic;
    private int previousSceneIndex = 0;

    private void Awake()
    {
        EventBus.OnVolumeChange.AddListener(ChangeVolume);
    }
    void Start()
    {
        if (DataManager.instance.musicNum == 0)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = gameMusic[0];
            audioSource.Play();
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        int sceneIndex = scene.buildIndex;

        if (sceneIndex == previousSceneIndex)
            return;
        if (gameMusic[0] && scene.buildIndex == 0)
            return;
        if (gameMusic[1] && scene.buildIndex == 1 && previousSceneIndex == 0)
            return;
            audioSource.clip = gameMusic[sceneIndex];
            audioSource.Play();

            previousSceneIndex = sceneIndex;
        
    }


    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}


