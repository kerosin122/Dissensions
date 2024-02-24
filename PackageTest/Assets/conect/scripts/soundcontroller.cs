using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioMixerGroup music;
    [SerializeField] private Slider slidermusic;
    [SerializeField] private AudioMixerGroup sound;
    [SerializeField] private Slider slidersound;

    private void Start() => audioMixer.SetFloat(music.name, slidermusic.value);

    private void ChangeMusicVolume(float volume)
    {
        volume = slidermusic.value;
        audioMixer.SetFloat(music.name, volume);
    }

    private void ChangerSoundVolume(float volume)
    {
        volume = slidermusic.value;
        audioMixer.SetFloat(sound.name, volume);
    }
}