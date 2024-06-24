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
        //初始化游戏数据
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData), "Music") as MusicData;
        //如果第一次进入游戏 没有音效数据 那么所有的数据为false或0
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

    //提供在排行榜中添加数据的方法
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
