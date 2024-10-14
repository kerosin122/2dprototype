using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class  SoundSliderManage: MonoBehaviour
{   [SerializeField]
    private AudioMixer audioMixer; // Ссылка на AudioMixer
    [SerializeField]
    private Slider soundSlider1; // Первый слайдер звука
    [SerializeField]
    private Slider soundSlider2; // Второй слайдер звука
    [SerializeField]

    private string mixerGroup1Parameter; // Параметр для первого AudioMixer Group
    [SerializeField]
    private string mixerGroup2Parameter; // Параметр для второго AudioMixer Group

    private void Start()
    {
        // Загрузка сохраненных значений при запуске игры
        soundSlider1.value = PlayerPrefs.GetFloat("SoundSlider1Value"); 
        soundSlider2.value = PlayerPrefs.GetFloat("SoundSlider2Value"); 
    }

    public void OnSoundSliderChanged()
    {
        // Сохранение значений при изменении слайдеров
        PlayerPrefs.SetFloat("SoundSlider1Value", soundSlider1.value);
        PlayerPrefs.SetFloat("SoundSlider2Value", soundSlider2.value);
        audioMixer.SetFloat(mixerGroup1Parameter,soundSlider1.value);
        audioMixer.SetFloat(mixerGroup2Parameter, soundSlider2.value);
       
    }
     public void Save()
    {
        
    
        PlayerPrefs.Save(); // Сохранение изменений
    }

  
}
