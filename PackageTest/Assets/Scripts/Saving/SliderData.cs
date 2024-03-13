using UnityEngine;

public class SliderData
{
    [SerializeField] private float slider1Value;
    [SerializeField] private float slider2Value;

    public float Slider1Value
    {
        get { return slider1Value; }
        set { slider1Value = value; }
    }

    public float Slider2Value
    {
        get { return slider2Value; }
        set { slider2Value = value; }
    }
}