using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AduioManager : MonoBehaviour
{
    public static AduioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    //git测试
    public AudioSource MusicPlayer;//背景音乐
    public AudioSource SFXPlayer;//音效
    private void Start()
    {
        //MusicPlayer.volume = StartDate.Instance.MusicVolume;
        //SFXPlayer.volume = StartDate.Instance.SFXVolume;
        ControlMusic(MusicPlayer.volume);
        ControlSFX(SFXPlayer.volume);
    }
    public void PlayerSFX(AudioData audioData) //播放音效
    {

        SFXPlayer.PlayOneShot(audioData.AudioClip, audioData.volume);

    }
    public void PlayerMusic()//播放音乐
    {
        MusicPlayer.PlayOneShot(MusicPlayer.clip, MusicPlayer.volume);
    }
    public void PlayerMusic(AudioData audioData)//播放背景音乐
    {
        MusicPlayer.PlayOneShot(audioData.AudioClip, audioData.volume);
    }
    public void ControlSFX(float volume) //设置音效
    {

        SFXPlayer.volume = volume;

        SaveSettingMessage();
    }
    public void ControlMusic(float volume)//设置背景音乐
    {
        MusicPlayer.volume = volume;

        SaveSettingMessage();

    }


    void SaveSettingMessage() //保存设置信息
    {
        //StartDate.Instance.MusicVolume = AduioManager.instance.MusicPlayer.volume;
        //StartDate.Instance.SFXVolume = AduioManager.instance.SFXPlayer.volume;

        //StartDate.Instance.SaveSetting();
    }


}
[System.Serializable]
public class AudioData
{
    [Header("音频文件")]
    public AudioClip AudioClip;
    [Header("音量大小")]
    public float volume;
}
