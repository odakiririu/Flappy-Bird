using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCtrl : MonoBehaviour
{
    public static AudioCtrl Ins;
    private AudioSource audioSrc;
    private void Awake()
    {
        audioSrc = gameObject.AddComponent<AudioSource>();
        if (Ins == null)
        {
            Ins = this;
            DontDestroyOnLoad(this);
        }
        else if (Ins)
        {
            Destroy(this);
        }
    }
    public void PlayMusic(string musicName) /// nay la VFX nhe
    {
        audioSrc.PlayOneShot((AudioClip)Resources.Load("_Sounds/" + musicName, typeof(AudioClip)));
    }

}
