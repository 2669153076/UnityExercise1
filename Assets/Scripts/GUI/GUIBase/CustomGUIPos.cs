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
    /// 计算控件中心点偏移
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

    //实际位置信息
    private Rect rectPos = new Rect(0,0,100,500);
    //屏幕对齐方式
    public E_AlignmentType screenAlignment = E_AlignmentType.Center;
    //控件对齐方式
    public E_AlignmentType centerAlignment = E_AlignmentType.Center;
    //偏移位置
    public Vector2 offsetPos;
    //控件的宽、高
    public float width=100;
    public float height=50;
    //用于计算的中心点成员变量
    private Rect centerPos;

}
