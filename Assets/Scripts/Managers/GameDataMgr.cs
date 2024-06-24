using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr 
{
    private static GameDataMgr instance = new GameDataMgr();
    public static GameDataMgr Instance => instance;

    public MusicData musicData;
    public RankList rankDataList;

    private GameDataMgr()
    {
        //��ʼ����Ϸ����
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        //�����һ�ν�����Ϸ û����Ч���� ��ô���е�����Ϊfalse��0
        if (!musicData.noFirstLoad)
        {
            musicData.noFirstLoad = true;
            musicData.isPlayingMusic = true;
            musicData.isPlayingSound = true;
            musicData.musicValue = 1;
            musicData.soundValue = 1;
            PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
        }

        rankDataList = PlayerPrefsDataMgr.Instance.LoadData(typeof(RankList), "Rank") as RankList;

    
    }

    public void OpenOrCloseMusic(bool isOpen)
    {
        musicData.isPlayingMusic=isOpen;
        BackMusicMgr.Instance.ChangeMute(isOpen);
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    public void OpenOrCloseSound(bool isOpen)
    {
        musicData.isPlayingSound=isOpen;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    public void ChangeMusicValue(float value)
    {
        musicData.musicValue=value;
        BackMusicMgr.Instance.ChangeValue(value);
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }
    public void ChangeSoundValue(float value)
    {
        musicData.soundValue = value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "Music");
    }

    //�ṩ�����а���������ݵķ���
    public void AddRankData(string name,int score,float time)
    {
        rankDataList.list.Add(new RankData(name, score, time));

        rankDataList.list.Sort((a, b) => a.time < b.time ? -1 : 1);
        for (int i = rankDataList.list.Count - 1; i >= 7; i--)
        {
            rankDataList.list.RemoveAt(i);
        }
        PlayerPrefsDataMgr.Instance.SaveData(rankDataList, "Rank");
    }
}
