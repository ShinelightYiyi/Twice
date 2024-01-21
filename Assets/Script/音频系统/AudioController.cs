using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] Slider Sound;
    [SerializeField] AudioMixer soundMixer;
    
    public void SetVolume(float volume)
    {
        soundMixer.SetFloat("Sound", Mathf.Log10(volume) * 20);
    }

}
