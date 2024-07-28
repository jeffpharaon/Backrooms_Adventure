using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMonstr : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source => GetComponent<AudioSource>();

    public void PlaySound(AudioClip clip, float volume = 1f, bool destroyed = false, float p1 = 1f)
    {
        source.pitch = p1;
        source.PlayOneShot(clip, volume);
    }
}
