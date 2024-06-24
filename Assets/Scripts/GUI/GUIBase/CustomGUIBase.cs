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
    //λ����Ϣ
    public CustomGUIPos pos;
    //��ʾ����
    public GUIContent content;
    //�Ƿ������Զ�����ʽ
    public E_CustomStyleOnOff OnOrOff = E_CustomStyleOnOff.Off;
    //��ʽ
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
