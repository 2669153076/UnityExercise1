using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBase : MonoBehaviour
{
    //攻击、防御、血量
    public int atk;
    public int def;
    public int maxHp;
    public int curHp;

    //炮台相关
    public Transform tankHead;

    //速度
    public float moveSpeed;
    public float bodyRoundSpeed;
    public float headRoundSpeed;

    //死亡特效
    public GameObject deadEffect;


    public abstract void Fire();

    public virtual void GetHit(TankBase other) 
    {
        if(other.atk - def < 0)
        {
            return;
        }
        curHp -= other.atk -def;
        if(curHp <= 0)
        {
            Dead();
        }
    }

    public virtual void Dead()
    {
        Destroy(gameObject);
        if(deadEffect != null)
        {
            GameObject effobj = Instantiate(deadEffect,transform.position,transform.rotation);
            
            AudioSource audioSource = effobj.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isPlayingSound;
            audioSource.Play();
        }
    }

    

}
