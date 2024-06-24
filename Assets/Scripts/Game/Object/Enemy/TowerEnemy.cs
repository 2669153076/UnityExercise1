using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemy : TankBase
{

    //开火间隔时间
    public float fireTime = 1;
    private float nowTime = 0;
    //发射位置
    public Transform[] shootPos;
    //子弹
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nowTime += Time.deltaTime;
        if (nowTime > fireTime)
        {
            Fire();
            nowTime = 0;
        }
    }

    public override void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);
            Bullet bulletObj = obj.GetComponent<Bullet>();
            bulletObj.SetFather(this);
        }
    }

    public override void GetHit(TankBase other)
    {
        //固定炮塔不会受伤
    }
}
