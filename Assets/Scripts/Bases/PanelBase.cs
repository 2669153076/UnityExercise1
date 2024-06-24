using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase<T> : MonoBehaviour where T: class
{
    //�����ؼ��ľ�̬��Ա

    //˽�еľ�̬��Ա����(����)
    private static T instance;

    //�����ľ�̬��Ա���Ի��߷���(��ȡ)
    public static T Instance => instance;

    private void Awake()
    {
        instance = this as T;
    }

    public virtual void ShowSelf()
    {
        gameObject.SetActive(true);
    }

    public virtual void HideSelf()
    {
        gameObject.SetActive(false);
    }
}
