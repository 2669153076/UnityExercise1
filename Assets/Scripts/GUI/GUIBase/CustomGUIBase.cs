using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_CustomStyleOnOff
{
    On,
    Off
}

public abstract class CustomGUIBase : MonoBehaviour
{
    //位置信息
    public CustomGUIPos pos;
    //显示内容
    public GUIContent content;
    //是否启用自定义样式
    public E_CustomStyleOnOff OnOrOff = E_CustomStyleOnOff.Off;
    //样式
    public GUIStyle style;

    public void DrawGUI()
    {
        switch (OnOrOff)
        {
            case E_CustomStyleOnOff.On:
                DrawOnStyle();
                break;
            case E_CustomStyleOnOff.Off:
                DrawOffStyle();
                break;
        }
    }

    protected abstract void DrawOnStyle();
    protected abstract void DrawOffStyle();

}
