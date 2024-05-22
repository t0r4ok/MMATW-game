using System.Collections;
using System.Collections.Generic;
using MMATW.Scripts.UI;
using UnityEngine;

public class MusicVolume : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;

    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource.GetComponent<AudioSource>();
    }

    void Update()
    {
        _audioSource.volume = _gameSettings.MusicVolume;
    }
}
