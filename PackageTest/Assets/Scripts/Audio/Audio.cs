using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Slider _sliderSounds;

    [SerializeField] private AudioMixerGroup _music;
    [SerializeField] private AudioMixerGroup _sounds;

    private void Start() => _audioMixer.SetFloat(_music.name, _sliderMusic.value);

    public void ChangeMusicVolume() => SetAudioVolume(_sliderMusic, _music);
    public void ChangeSoundVolume() => SetAudioVolume(_sliderSounds, _sounds);
    
    private void SetAudioVolume(Slider slider, AudioMixerGroup audio)
    {
        float volume = slider.value;
        _audioMixer.SetFloat(audio.name, volume);
    }
}