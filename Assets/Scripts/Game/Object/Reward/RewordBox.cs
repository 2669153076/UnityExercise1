using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewordBox : MonoBehaviour
{
    public GameObject[] RewardGameObject;

    public GameObject effect;
    private AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        int rangeInt = Random.Range(0, 100);
        if (rangeInt < 35)
        {
            rangeInt = Random.Range(0, RewardGameObject.Length);
            Instantiate(RewardGameObject[rangeInt],transform.position,transform.rotation);
        }
        if (effect != null)
        {
            GameObject eff = Instantiate(effect, transform.position, transform.rotation);
            audio = eff.GetComponent<AudioSource>();
            audio.volume = GameDataMgr.Instance.musicData.musicValue;
            audio.mute = !GameDataMgr.Instance.musicData.isPlayingSound;
        }

        Destroy(gameObject);
    }
}
