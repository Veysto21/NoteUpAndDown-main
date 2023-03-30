using UnityEngine.Audio;
using System;
using UnityEngine;
using Unity.VisualScripting;
//using VRTK;





public partial class SAudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static SAudioManager instance;
    //AudioManager

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }


        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }

    internal void PlaySound(AudioClip clip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(clip, position);
    }

    /*public void OnSnapDrop(SnapDropZoneEventArgs eventData)
    {
        PlaySoundOnStart soundPlayer = eventData.SnapToNearestLine.GetComponent<PlaySoundOnStart>();
        if (soundPlayer != null)
        {
            PlaySound(soundPlayer.clip);
        }
    }*/
}
