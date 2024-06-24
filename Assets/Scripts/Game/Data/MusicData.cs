using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 存储音乐设置相关信息
/// </summary>
public class MusicData 
{
    public bool isPlayingMusic;
    public bool isPlayingSound;

    public float musicValue;
    public float soundValue;

    //是否是第一次加载      默认为false
    public bool noFirstLoad;
}
