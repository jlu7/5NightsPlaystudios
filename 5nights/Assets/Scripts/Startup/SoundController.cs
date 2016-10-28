using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

public class SoundController : MonoBehaviour
{
    private static SoundController SC;

    public static SoundController GetInstance()
    {
        if (SC == null)
        {
            SC = new GameObject("SoundController").AddComponent<SoundController>();
        }
        return SC;
    }

    public void Initialize()
    {
    }

    public void Play(string Sound, bool isLooping = false, float volume = 1.0f)
    {
        AudioSource aud = SC.gameObject.AddComponent<AudioSource>();
        AudioClip soundEffect = Resources.Load<AudioClip>("Sounds/" + Sound);
        aud.volume = volume;
        aud.clip = soundEffect;
        aud.loop = isLooping;
        StartCoroutine(PlayOnce(aud));
    }

    public IEnumerator PlayOnce(AudioSource aud)
    {
        aud.Play();
        while (aud.isPlaying)
        {
            yield return null;
        }
        Destroy(aud);
    }

    public void StopSound(string soundName)
    {
        foreach (AudioSource aud in GetComponents<AudioSource>())
        {
            Debug.Log(aud.clip.name);
            if (aud.clip.name == soundName)
            {
                aud.Stop();
            }
        }
    }
}
