using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField] private AudioClip _bgmClip;

    private AudioSource _bgmSource;
    private AudioSource _sfxSource;

    private void Awake()
    {
        _bgmSource = transform.Find("BGM").GetComponent<AudioSource>();
        _sfxSource = transform.Find("SFX").GetComponent<AudioSource>();

        GameManager.Instance.GameStartEvent += StartBGM;
    }

    public void StartBGM()
    {
        _bgmSource.clip = _bgmClip;
        _bgmSource.Play();
    }

    public void PlayerFPX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }
}
