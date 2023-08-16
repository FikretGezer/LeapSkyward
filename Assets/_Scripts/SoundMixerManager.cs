using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Sprite musicOn, musicOff;
    [SerializeField] private Sprite effectsOn, effectsOff;

    [SerializeField] private Image musicButton, soundFXButton;

    [HideInInspector] public float musicVolume = 1f;
    [HideInInspector] public float soundFXVolume = 1f;

    private void Awake() {
        if(PlayerPrefs.HasKey("SoundFXVolume"))
        {
            var value = PlayerPrefs.GetFloat("SoundFXVolume");
            SetSoundFXVolume(value);
            if(value > 0.0001f) soundFXButton.sprite = effectsOn;
            else soundFXButton.sprite = effectsOff;
        }
        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            var value = PlayerPrefs.GetFloat("MusicVolume");
            SetMusicVolume(value);
            if(value > 0.0001f) musicButton.sprite = musicOn;
            else musicButton.sprite = musicOff;
        }
    }
    public void SetMasterVolume(float volume)
    {
        var vlm = Mathf.Log(volume) * 20f;
        audioMixer.SetFloat("MasterVolume", vlm);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log(volume) * 20f);
    }
    public void SetSoundFXVolume(float volume)
    {
        audioMixer.SetFloat("SoundFXVolume", Mathf.Log(volume) * 20f);
    }
    public void MusicOnOff()
    {
        if(musicVolume > 0.0001f)
        {
            musicVolume = 0.0001f;
            musicButton.sprite = musicOff;
            SetMusicVolume(musicVolume);
        }
        else
        {
            musicVolume = 1f;
            musicButton.sprite = musicOn;
            SetMusicVolume(musicVolume);
        }
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }
    public void SoundFXOnOff()
    {
        if(soundFXVolume > 0.0001f)
        {
            soundFXVolume = 0.0001f;
            soundFXButton.sprite = effectsOff;
            SetSoundFXVolume(soundFXVolume);
        }
        else
        {
            soundFXVolume = 1f;
            soundFXButton.sprite = effectsOn;
            SetSoundFXVolume(soundFXVolume);
        }
        PlayerPrefs.SetFloat("SoundFXVolume", soundFXVolume);
    }
}
