using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_AlignmentType
{
    Left, 
    Right,
    Up, 
    Down,
    LeftUp,
    RightUp, 
    LeftDown,
    RightDown,
    Center
}

[System.Serializable]
public class CustomGUIPos 
{
    /// <summary>
    /// ����ؼ����ĵ�ƫ��
    /// </summary>
    private void CalcCenterPos()
    {
        switch (centerAlignment)
        {
            case E_AlignmentType.Left:
                centerPos.x = 0;
                centerPos.y = -height/2;
                break;
            case E_AlignmentType.Right:
                centerPos.x = -width ;
                centerPos.y = -height/2;
                break;
            case E_AlignmentType.Up:
                centerPos.x = -width/2;
                centerPos.y = 0;
                break;
            case E_AlignmentType.Down:
                centerPos.x = -width/2;
                centerPos.y = -height;
                break;
            case E_AlignmentType.LeftUp:
                centerPos.x = 0;
                centerPos.y = 0;
                break;
            case E_AlignmentType.RightUp:
                centerPos.x = -width;
                centerPos.y = 0;
                break;
            case E_AlignmentType.LeftDown:
                centerPos.x = 0;
                centerPos.y = -height;
                break;
            case E_AlignmentType.RightDown:
                centerPos.x = -width;
                centerPos.y = -height;
                break;
            case E_AlignmentType.Center:
                centerPos.x = -width / 2;
                centerPos.y = -height / 2;
                break;
        }
    }

    private void CalcRectPos()
    {
        switch (screenAlignment)
        {
            case E_AlignmentType.Left:
                rectPos.x = 0 + centerPos.x + offsetPos.x;
                rectPos.y = Screen.height / 2 + centerPos.y - offsetPos.y;
                break;
            case E_AlignmentType.Right:
                rectPos.x = Screen.width + centerPos.x - offsetPos.x;
                rectPos.y = Screen.height / 2 + centerPos.y - offsetPos.y;
                break;
            case E_AlignmentType.Up:
                rectPos.x = Screen.width / 2 + centerPos.x + offsetPos.x;
                rectPos.y = 0 + centerPos.y + offsetPos.y;
                break;
            case E_AlignmentType.Down:
                rectPos.x = Screen.width / 2 + centerPos.x + offsetPos.x;
                rectPos.y = Screen.height + centerPos.y - offsetPos.y;
                break;
            case E_AlignmentType.LeftUp:
                rectPos.x = 0 + centerPos.x + offsetPos.x;
                rectPos.y = 0 + centerPos.y + offsetPos.y;
                break;
            case E_AlignmentType.RightUp:
                rectPos.x = Screen.width + centerPos.x - offsetPos.x;
                rectPos.y = 0 + centerPos.y + offsetPos.y;
                break;
            case E_AlignmentType.LeftDown:
                rectPos.x = 0 + centerPos.x + offsetPos.x;
                rectPos.y = Screen.height + centerPos.y - offsetPos.y;
                break;
            case E_AlignmentType.RightDown:
                rectPos.x = Screen.width + centerPos.x - offsetPos.x;
                rectPos.y = Screen.height + centerPos.y - offsetPos.y;
                break;
            case E_AlignmentType.Center:
                rectPos.x = Screen.width / 2 + centerPos.x + offsetPos.x;
                rectPos.y = Screen.height / 2 + centerPos.y - offsetPos.y;
                break;
        }
    }

    public Rect RectPos
    {
        get
        {
            CalcCenterPos();
            CalcRectPos();
            rectPos.width = width;
            rectPos.height = height;
            return rectPos;
        }
    }

    //ʵ��λ����Ϣ
    private Rect rectPos = new Rect(0,0,100,500);
    //��Ļ���뷽ʽ
    public E_AlignmentType screenAlignment = E_AlignmentType.Center;
    //�ؼ����뷽ʽ
    public E_AlignmentType centerAlignment = E_AlignmentType.Center;
    //ƫ��λ��
    public Vector2 offsetPos;
    //�ؼ��Ŀ���
    public float width=100;
    public float height=50;
    //���ڼ�������ĵ��Ա����
    private Rect centerPos;

}
