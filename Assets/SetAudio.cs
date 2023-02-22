using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetAudio : MonoBehaviour
{
    public Button Btn_music;
    public Button Btn_VFX;
    public List<Sprite> off = new List<Sprite>();
    private void Awake()
    {
        Btn_music.onClick.AddListener(SetBtn_music);
        Btn_VFX.onClick.AddListener(SetBtn_VFX);
    }
    public void SetBtn_music()
    {
        AduioManager.instance.MusicPlayer.volume = AduioManager.instance.MusicPlayer.volume == 0 ? 1 : 0;
        Btn_music.gameObject.GetComponent<Image>().sprite = AduioManager.instance.MusicPlayer.volume == 1 ? off[0] : off[1];
    }
    public void SetBtn_VFX()
    {
        AduioManager.instance.SFXPlayer.volume = AduioManager.instance.SFXPlayer.volume == 0 ? 1 : 0;
        Btn_VFX.gameObject.GetComponent<Image>().sprite = AduioManager.instance.SFXPlayer.volume == 1 ? off[2] : off[3];
    }
}
