using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Sprite musicOn, musicOff;
    [SerializeField] private Sprite soundFXOn, soundFXOff;

    [SerializeField] private Image musicButton, soundFXButton;

    [SerializeField] private AudioSource musicSource, soundFXSource;
    [SerializeField] private Slider _masterVolumeSlider;

    [HideInInspector] public float musicVolume = 1f;
    [HideInInspector] public float soundFXVolume = 1f;



    private void Awake() {
        if(PlayerPrefs.HasKey("isMusicMuted"))
        {
            var isMuted = PlayerPrefs.GetInt("isMusicMuted");
            if(isMuted == 0)
            {
                musicSource.mute = false;
                musicButton.sprite = musicOn;
            }
            else
            {
                musicSource.mute = true;
                musicButton.sprite = musicOff;
            } 
        }
        if(PlayerPrefs.HasKey("isSoundFXMuted"))
        {
            var isMuted = PlayerPrefs.GetInt("isSoundFXMuted");
            if(isMuted == 0)
            {
                soundFXSource.mute = false;
                soundFXButton.sprite = soundFXOn;
            }
            else
            {
                soundFXSource.mute = true;
                soundFXButton.sprite = soundFXOff;
            } 
        }
    }
    private void Start() {
        if(PlayerPrefs.HasKey("MasterVolumeP"))
        {
            var volume = PlayerPrefs.GetFloat("MasterVolumeP");    
            _masterVolumeSlider.value = volume;  
            SetMasterVolume(volume);    
        }
    }
    public void SetMasterVolume(float volume)
    {
        var vlm = Mathf.Log(volume) * 20f;  
        audioMixer.SetFloat("MasterVolume", vlm);
        PlayerPrefs.SetFloat("MasterVolumeP", volume);
    }
    public void MuteMusic()
    {
        var isMuted = musicSource.mute;
        if(isMuted){
            musicSource.mute = false;
            musicButton.sprite = musicOn;
            PlayerPrefs.SetInt("isMusicMuted", 0);
        }
        else{
            musicSource.mute = true;
            musicButton.sprite = musicOff;
            PlayerPrefs.SetInt("isMusicMuted", 1);
        }
    }
    public void MuteSoundFX()
    {
        var isMuted = soundFXSource.mute;
        if(isMuted){
            soundFXSource.mute = false;
            soundFXButton.sprite = soundFXOn;
            PlayerPrefs.SetInt("isSoundFXMuted", 0);
        }
        else{
            soundFXSource.mute = true;
            soundFXButton.sprite = soundFXOff;
            PlayerPrefs.SetInt("isSoundFXMuted", 1);
        }
    }
}
