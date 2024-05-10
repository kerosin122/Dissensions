using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace ScriptsAudio
{
    public class VolumeSetter : MonoBehaviour
    {
        private const int VALUE_WHICH_VOLUME_LOWERED = 5;

        [SerializeField] private AudioMixer _audioMixer;

        [SerializeField] private Slider _musicSlider;
        [SerializeField] private Slider _soundSlider;

        [SerializeField] private AudioMixerGroup _musicMixer;
        [SerializeField] private AudioMixerGroup _soundsMixer;

        private void Start() => _audioMixer.SetFloat(_musicMixer.name, _musicSlider.value);

        public void ChangeMusicVolume() => SetAudioVolume(_musicSlider, _musicMixer);
        public void ChangeSoundVolume() => SetAudioVolume(_soundSlider, _soundsMixer);

        public void MusicReduction() => SetAudioReduction(_musicSlider);
        public void SoundReduction() => SetAudioReduction(_soundSlider);

        private void SetAudioVolume(Slider slider, AudioMixerGroup audio)
        {
            float volume = slider.value;
            _audioMixer.SetFloat(audio.name, volume);
        }

        private void SetAudioReduction(Slider slider) => slider.value -= VALUE_WHICH_VOLUME_LOWERED;
    }
}