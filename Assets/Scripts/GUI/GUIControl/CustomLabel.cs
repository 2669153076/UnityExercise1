using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomLabel : CustomGUIBase
{
    protected override void DrawOffStyle()
    {
        GUI.Label(pos.RectPos, content);
    }

    protected override void DrawOnStyle()
    {
        GUI.Label(pos.RectPos,content,style);
    }

}
