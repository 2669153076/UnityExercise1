using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : TankBase
{
    public Weapon weapon;
    //����������λ��
    [Header("����������λ��")]public Transform weaponPos;

    private float inputHorizontal;
    private float inputVertical;
    // Start is called before the first frame update
    void Start()
    {
        GamePanel.Instance.UpdateHpBar(maxHp,curHp);
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * inputVertical * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * inputHorizontal * bodyRoundSpeed * Time.deltaTime);

        tankHead.transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * headRoundSpeed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public override void Fire()
    {
        if(weapon != null)
        {
            weapon.Fire();
        }
    }

    public override void GetHit(TankBase other)
    {
        base.GetHit(other);
        GamePanel.Instance.UpdateHpBar(maxHp,curHp);
    }

    /// <summary>
    /// �л�����
    /// </summary>
    /// <param name="weaponObj"></param>
    public void ChangeWeapon(GameObject weapon)
    {
        if (this.weapon != null)
        {
            Destroy(this.weapon.gameObject);
            this.weapon = null;
        }
        //�л����� �����丸���� ��֤����
        GameObject weaponObj = Instantiate(weapon,weaponPos,false);
        this.weapon = weaponObj.GetComponent<Weapon>();
        this.weapon.SetFather(this);
    }

    public override void Dead()
    {
        base.Dead();
        Time.timeScale = 0;
        DefeatPanel.Instance.ShowSelf();
    }
}
