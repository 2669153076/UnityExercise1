using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReward : MonoBehaviour
{
    public GameObject[] weapenObject;

    public GameObject getEffect;

    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int index = Random.Range(0,weapenObject.Length);
            //得到撞到的玩家身上挂载的脚本
            Player player = other.GetComponent<Player>();
            //切换武器
            player.ChangeWeapon(weapenObject[index]);

            GameObject eff = Instantiate(getEffect,transform.position,transform.rotation);
            audioSource = eff.GetComponent<AudioSource>();
            audioSource.volume = GameDataMgr.Instance.musicData.soundValue;
            audioSource.mute = !GameDataMgr.Instance.musicData.isPlayingSound;


            Destroy(gameObject);
        }
    }
}
