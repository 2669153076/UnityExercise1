using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TankBase : MonoBehaviour
{
    //������������Ѫ��
    public int atk;
    public int def;
    public int maxHp;
    public int curHp;

    //��̨���
    public Transform tankHead;

    //�ٶ�
    public float moveSpeed;
    public float bodyRoundSpeed;
    public float headRoundSpeed;

    //������Ч
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
