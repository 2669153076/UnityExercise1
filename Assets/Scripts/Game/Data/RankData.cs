using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���а�����Ϣ
/// </summary>
public class RankData 
{
    public string name;
    public int score;
    public float time;

    public RankData()
    {

    }

    public RankData(string name, int score, float time)
    {
        this.name = name;
        this.score = score;
        this.time = time;
    }
}

/// <summary>
/// ���а��б�
/// </summary>
public class RankList
{
    public List<RankData> list;
}
