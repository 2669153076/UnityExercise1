using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomToggle : CustomGUIBase
{
    public event UnityAction<bool> selectEvent;

    public bool isSel;
    private bool isOldSel;


    protected override void DrawOffStyle()
    {
        isSel = GUI.Toggle(pos.RectPos, isSel, content);
        if(isOldSel!=isSel)
        {
            selectEvent?.Invoke(isSel);
            isOldSel = isSel;
        }

    }

    protected override void DrawOnStyle()
    {
        isSel = GUI.Toggle(pos.RectPos, isSel, content, style);

        if(isOldSel != isSel)
        {
            selectEvent?.Invoke(isSel);
            isOldSel=isSel;
        }
    }
}
