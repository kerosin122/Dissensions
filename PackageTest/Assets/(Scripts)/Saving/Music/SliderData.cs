using UnityEngine;

public class SliderData
{
    [SerializeField] private float _sliderMusic;
    [SerializeField] private float _sliderSound;

    public float SliderMusic
    {
        get { return _sliderMusic; }
        set { _sliderMusic = value; }
    }

    public float SliderSounds
    {
        get { return _sliderSound; }
        set { _sliderSound = value; }
    }
}