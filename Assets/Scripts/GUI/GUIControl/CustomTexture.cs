using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTexture : CustomGUIBase
{
    public ScaleMode scaleMode = ScaleMode.StretchToFill;

    protected override void DrawOffStyle()
    {
        GUI.DrawTexture(pos.RectPos, content.image);
    }

    protected override void DrawOnStyle()
    {
        GUI.DrawTexture(pos.RectPos, content.image,scaleMode);
    }
}
