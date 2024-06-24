using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class NormalEnemy : TankBase
{
    //坦克来回移动
    private Transform targetPos;
    public Transform[] randomPos;

    //坦克盯着自己的目标 
    public Transform lookAtTarget;

    //目标到达一定范围内后 间隔一段时间 攻击目标
    public float fireDistance = 5;
    public float fireTime = 1;
    private float nowTime = 0;

    //开火点
    public Transform[] shootPos;
    //子弹预制体
    public GameObject bullet;

    [Header("血条相关")]
    public Texture maxHpTexture;
    public Texture curHpTexture;
    public Rect maxHpRect;
    public Rect curHpRect;
    private float hpBarShowTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetPos);
        transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);

        //距离过小 时 认为到达了目的地 重新随机一个点
        if (Vector3.Distance(transform.position, targetPos.position) < 0.05f)
            RandomPos();
        if(lookAtTarget != null)
        {
            tankHead.LookAt(lookAtTarget);
            if(Vector3.Distance(this.transform.position,lookAtTarget.position)<=fireDistance)
            {
                nowTime += Time.deltaTime;
                if(nowTime>fireTime)
                {
                    Fire();
                    nowTime = 0;
                }
            }
        }
    }

    private void RandomPos()
    {
        if (randomPos.Length == 0)
        {
            return;
        }
        targetPos = randomPos[Random.Range(0, randomPos.Length)];
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

    public override void Dead()
    {
        base.Dead();
        GamePanel.Instance.AddScore(10);
    }

    private void OnGUI()
    {
        if (hpBarShowTime > 0)
        {
            hpBarShowTime -= Time.deltaTime;
            //1.把敌人当前位置 转换为屏幕位置 
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            screenPos.z = 0;
            //2.把屏幕位置 转为 GUI位置
            screenPos.y = Screen.height - screenPos.y;
            //3.绘制
            maxHpRect.width = maxHp*Screen.width/640;
            maxHpRect.height = 5*Screen.height/675;
            maxHpRect.x = screenPos.x;
            maxHpRect.y = screenPos.y - maxHpRect.height;
            GUI.DrawTexture(maxHpRect, maxHpTexture);
            curHpRect.width = curHp* Screen.width / 640;
            curHpRect.height = 5 * Screen.height / 675;
            curHpRect.x = screenPos.x;
            curHpRect.y = screenPos.y - curHpRect.height;
            GUI.DrawTexture(curHpRect, curHpTexture);
        }
    }

    public override void GetHit(TankBase other)
    {
        base.GetHit(other);
        hpBarShowTime = 2;
    }
}
