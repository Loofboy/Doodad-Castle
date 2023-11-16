using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderSet : MonoBehaviour
{
    public Slider master;
    public Slider music;
    public Slider sound;
    public Slider voice;

    // Start is called before the first frame update
    void Start()
    {
        master.value = JSAM.AudioManager.MasterVolume;
        music.value = JSAM.AudioManager.MusicVolume;
        sound.value = JSAM.AudioManager.SoundVolume;
        voice.value = JSAM.AudioManager.VoiceVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
