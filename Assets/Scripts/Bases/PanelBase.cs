using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase<T> : MonoBehaviour where T: class
{
    //两个关键的静态成员

    //私有的静态成员变量(声明)
    private static T instance;

    //公共的静态成员属性或者方法(获取)
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
