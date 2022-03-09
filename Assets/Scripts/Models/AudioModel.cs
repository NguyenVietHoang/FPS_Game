using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "New Audio Model", menuName = "Audio Model", order = 52)]
public class AudioModel : ScriptableObject
{
    public AudioMixer Mixer;

    public AudioMixerSnapshot OnIdle;
    public AudioMixerSnapshot OnWalk;
    public AudioMixerSnapshot OnCollect;

    public List<AudioClip> CollectAudios;
    public List<AudioClip> WalkClips;
    public List<AudioClip> BackgroundClips;
}
