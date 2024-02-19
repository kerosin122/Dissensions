using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer; // Переменная микшера для управления
    public AudioMixerGroup music;
    public Slider slidermusic;
        public AudioMixerGroup sound;
    public Slider slidersound;
  
    
        private void Start()
    {
        audioMixer.SetFloat(music.name, slidermusic.value);

    }
 
         public void SetMusicVolume (float volume) // Функция управления громкостью фоновой музыки
    {    
        volume=slidermusic.value; 
        audioMixer.SetFloat(music.name, volume);
                 // MusicVolume раскрывает параметры музыки для нас
    }
 
         public void SetSoundEffectVolume (float volume) // Функция управления громкостью звуковых эффектов
    {    volume=slidermusic.value;
         
        audioMixer.SetFloat(sound.name, volume);
                 // EffectVolume предоставляет нам параметры SoundEffect
    }
}