using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AuidoMag 
{
    private static AuidoMag instance;
    public static AuidoMag Instance { get => instance ?? new AuidoMag(); }

    public void Play(string Path)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Music");
        AudioSource aui = go.GetComponent<AudioSource>();   
        AudioClip clip = Resources.Load<AudioClip>(Path);
        aui.clip = clip;
        aui.Play();
    }

    public void PlayOneShot(string Path)
    {
        GameObject go = GameObject.FindGameObjectWithTag("Sound");
        AudioSource aui = go.GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(Path);
        aui.clip = clip;
        aui.PlayOneShot(aui.clip);
    }

    public void Stop(string Path) 
    {
        GameObject go = GameObject.FindGameObjectWithTag("Music");
        AudioSource aui = go.GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(Path);
        aui.clip = clip;
        aui.Stop();
    }
}
