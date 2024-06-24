using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_CustomSliderType
{
    Horizontal,
    Vertical
}

public class CustomSlider : CustomGUIBase
{
    public E_CustomSliderType sliderType = E_CustomSliderType.Horizontal;
    public float minValue = 0;
    public float maxValue = 1;
    public float nowValue;
    public event UnityAction<float> onValueChanged;
    public GUIStyle thumbStyle;

    private float oldValue;

    protected override void DrawOffStyle()
    {
        switch (sliderType)
        {
            case E_CustomSliderType.Horizontal:
                nowValue = GUI.HorizontalSlider(pos.RectPos, nowValue, minValue, maxValue);
                break;
            case E_CustomSliderType.Vertical:
                nowValue = GUI.VerticalSlider(pos.RectPos, nowValue, minValue, maxValue);
                break;
        }
        if (oldValue != nowValue)
        {
            onValueChanged?.Invoke(nowValue);
            oldValue = nowValue;
        }
    }

    protected override void DrawOnStyle()
    {
        switch (sliderType)
        {
            case E_CustomSliderType.Horizontal:
                nowValue = GUI.HorizontalSlider(pos.RectPos, nowValue, minValue, maxValue, style, thumbStyle);
                break;
            case E_CustomSliderType.Vertical:
                nowValue = GUI.VerticalSlider(pos.RectPos, nowValue, minValue, maxValue, style, thumbStyle);
                break;
        }
        if (oldValue != nowValue)
        {
            onValueChanged?.Invoke(nowValue);
            oldValue = nowValue;
        }
    }
}
