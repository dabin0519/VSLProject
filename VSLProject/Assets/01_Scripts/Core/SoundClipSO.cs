using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/SoundClip")]
public class SoundClipSO : ScriptableObject
{
    [Header("--Bgm--")]
    public AudioClip bgmClip;

    [Header("--SFX--")]
    public AudioClip hitClip;
}
