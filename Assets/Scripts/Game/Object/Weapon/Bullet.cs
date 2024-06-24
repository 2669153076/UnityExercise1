using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 50;

    //Ë­·¢ÉäµÄ
    public TankBase fatherObj;

    public GameObject effect;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        print(fatherObj.name);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Ground") || other.CompareTag("RewardBox")||(other.CompareTag("Player")&&fatherObj.CompareTag("Enemy"))||(other.CompareTag("Enemy")&&fatherObj.CompareTag("Player")))
        {
            TankBase obj = other.GetComponent<TankBase>();
            if (obj != null)
            {
                obj.GetHit(fatherObj);
            }
            if (effect != null)
            {
                GameObject eff = Instantiate(effect, transform.position, transform.rotation);
                audio=eff.GetComponent<AudioSource>();
                audio.volume = GameDataMgr.Instance.musicData.soundValue;
                audio.mute = !GameDataMgr.Instance.musicData.isPlayingSound;
            }
            Destroy(gameObject);

        }

    }

    public void SetFather(TankBase obj)
    {
        fatherObj = obj;
    }

}
