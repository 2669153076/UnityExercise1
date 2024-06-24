using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomButton : CustomGUIBase
{
    public event UnityAction clickEvent;

    protected override void DrawOffStyle()
    {
        if(GUI.Button(pos.RectPos, content))
        {
            clickEvent?.Invoke();
        }
    }

    protected override void DrawOnStyle()
    {
        if(GUI.Button(pos.RectPos, content, style))
        {
            clickEvent?.Invoke();
        }
    }
    
}
