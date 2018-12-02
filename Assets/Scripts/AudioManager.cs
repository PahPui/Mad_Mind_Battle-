using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {

    public static AudioManager instance { set; get; }

    public AudioMixer MasterMixer;

    public float MusicLVL;
    public Slider Music;
    public float SoundLVL;
    public Slider Sound;

    void Awake()
    {
        instance = this;

        MusicLVL = PlayerPrefs.GetFloat("MusicLVL", -5);
        SoundLVL = PlayerPrefs.GetFloat("SFXLVL", 0);

        //Music.value = MusicLVL;
        //Sound.value = SoundLVL;

        SetMusicLVL(MusicLVL);
        SetSFXLVL(SoundLVL);
    }

    public void SetMusicLVL(float lvl)
    {
        MusicLVL = lvl;
        PlayerPrefs.SetFloat("MusicLVL", lvl);
        MasterMixer.SetFloat("MusicVol", lvl);
    }

    public void GetMusicLVL()
    {
        Music.value = MusicLVL;
    }

    public void SetSFXLVL(float lvl)
    {
        SoundLVL = lvl;
        PlayerPrefs.SetFloat("SFXLVL", lvl);
        MasterMixer.SetFloat("SFXVol", lvl);
    }

    public void GetSFXLVL()
    {
        Sound.value = SoundLVL;
    }

    public void SaveSetting()
    {
        PlayerPrefs.Save();
    }
}
