using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusicMgr : MonoBehaviour
{
    private static BackMusicMgr instance;

    public static BackMusicMgr Instance => instance;

    private AudioSource audioSource;

    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();

        ChangeValue(GameDataMgr.Instance.musicData.musicValue);
        ChangeMute(GameDataMgr.Instance.musicData.isPlayingMusic);
    }

    public void ChangeValue(float value)
    {
        audioSource.volume = value;
    }

    public void ChangeMute(bool isMute)
    {
        audioSource.mute = isMute;
    }
}
