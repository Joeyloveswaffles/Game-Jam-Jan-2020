using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Settings : MonoBehaviour
{
    public enum soundSettingSets
    {
        Stereo, Headphones, SurrondSound, Custom, Default
    }

    public soundSettingSets soundSettingPreset;

    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;

    public bool defaultValues;

    // Start is called before the first frame update
    void Start()
    {
        
        if (defaultValues)
        {
            masterVolume = 100.0f;
            musicVolume = 100.0f;
            sfxVolume = 100.0f;
            soundSettingPreset = soundSettingSets.Default;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkSoundSettings()
    {

    }

    private void OnDestroy()
    {
        Debug.LogWarning("Sound settings was destory");
    }


}
