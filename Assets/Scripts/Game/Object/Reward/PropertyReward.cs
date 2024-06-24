using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PropertyType
{
    Hp,
    MaxHp,
    Atk,
    Def
}

public class PropertyReward : MonoBehaviour
{
    [Header("º”≥… Ù–‘")]public E_PropertyType propertyType;

    public int changeValue = 0;

    public GameObject effect;
    private AudioSource effectAudio;

    private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            switch (propertyType)
            {
                case E_PropertyType.Hp:
                    player.curHp += changeValue;
                    if (player.curHp > player.maxHp)
                        player.curHp = player.maxHp;
                    GamePanel.Instance.UpdateHpBar(player.maxHp, player.curHp);
                    break;
                case E_PropertyType.MaxHp:
                    player.maxHp += changeValue;
                    GamePanel.Instance.UpdateHpBar(player.maxHp, player.curHp);
                    break;
                case E_PropertyType.Atk:
                    player.atk += changeValue;
                    break;
                case E_PropertyType.Def:
                    player.def += changeValue;
                    break;
            }

            GameObject eff = Instantiate(effect,transform.position,transform.rotation);
            effectAudio = eff.GetComponent<AudioSource>();
            effectAudio.volume = GameDataMgr.Instance.musicData.soundValue;
            effectAudio.mute = !GameDataMgr.Instance.musicData.isPlayingSound;

            Destroy(gameObject);
        }
    }
}
