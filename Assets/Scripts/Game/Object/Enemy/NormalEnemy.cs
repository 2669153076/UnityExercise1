using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class NormalEnemy : TankBase
{
    //̹�������ƶ�
    private Transform targetPos;
    public Transform[] randomPos;

    //̹�˶����Լ���Ŀ�� 
    public Transform lookAtTarget;

    //Ŀ�굽��һ����Χ�ں� ���һ��ʱ�� ����Ŀ��
    public float fireDistance = 5;
    public float fireTime = 1;
    private float nowTime = 0;

    //�����
    public Transform[] shootPos;
    //�ӵ�Ԥ����
    public GameObject bullet;

    [Header("Ѫ�����")]
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

        //�����С ʱ ��Ϊ������Ŀ�ĵ� �������һ����
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
            //1.�ѵ��˵�ǰλ�� ת��Ϊ��Ļλ�� 
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            screenPos.z = 0;
            //2.����Ļλ�� תΪ GUIλ��
            screenPos.y = Screen.height - screenPos.y;
            //3.����
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
