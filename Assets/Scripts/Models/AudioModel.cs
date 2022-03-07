using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioModel : MonoBehaviour
{
    public AudioMixer Mixer;

    public AudioMixerSnapshot OnIdle;
    public AudioMixerSnapshot OnWalk;
    public AudioMixerSnapshot OnCollect;

    public List<AudioClip> CollectAudios;
    public AudioSource CollectSource;
    public AudioSource WalkSource;
    public AudioSource BackgroundSource;
}
