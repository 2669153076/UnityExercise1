using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CustomTextField : CustomGUIBase
{
    public event UnityAction<string> inputEvent;

    private string oldStr = "";

    protected override void DrawOffStyle()
    {
        content.text = GUI.TextField(pos.RectPos,content.text);
        
        if(oldStr != content.text)
        {
            inputEvent?.Invoke(content.text);
            oldStr = content.text;
        }
    }

    protected override void DrawOnStyle()
    {
        content.text = GUI.TextField(pos.RectPos, content.text,style);

        if (oldStr != content.text)
        {
            inputEvent?.Invoke(content.text);
            oldStr = content.text;
        }
    }
}
