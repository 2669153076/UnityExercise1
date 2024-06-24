using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;

    public Transform[] shootPos;

    //ÎäÆ÷µÄÓµÓÐÕß
    public TankBase fatherObj;

    public void Fire()
    {
        for (int i = 0; i < shootPos.Length; i++)
        {
            GameObject obj = Instantiate(bullet, shootPos[i].position, shootPos[i].rotation);

            Bullet bulletObj = obj.GetComponent<Bullet>();
            bulletObj.SetFather(fatherObj);
        }
    }

    public void SetFather(TankBase obj)
    {
        fatherObj = obj;
    }
}
